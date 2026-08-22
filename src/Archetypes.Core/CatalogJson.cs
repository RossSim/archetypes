using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using PersonalityEngine.Providers.Erikson;
using PersonalityEngine.Providers.Ocean;
using PersonalityEngine.Providers.Piaget;

namespace Archetypes;

/// <summary>
/// Parses trusted catalog JSON into <see cref="MindPreset"/>.
/// Documents are DTO-shaped; this is not a polymorphic deserializer.
/// Markdown under <c>presets/</c> remains the authoring source.
/// </summary>
public static class CatalogJson
{
    public const string ResourcePrefix = "archetypes.preset.";

    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
        AllowTrailingCommas = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        WriteIndented = true
    };

    public static string Serialize(MindPreset preset)
    {
        if (preset is null)
            throw new ArgumentNullException(nameof(preset));
        return JsonSerializer.Serialize(ToDocument(preset), Options) + Environment.NewLine;
    }

    public static MindPreset Parse(string json)
    {
        if (string.IsNullOrWhiteSpace(json))
            throw new ArgumentException("JSON is empty.", nameof(json));

        var doc = JsonSerializer.Deserialize<PresetDocument>(json, Options)
            ?? throw new ArgumentException("JSON deserialized to null.", nameof(json));
        return FromDocument(doc);
    }

    public static MindPreset Load(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("Preset id is required.", nameof(id));

        var resource = ResourcePrefix + id + ".json";
        using var stream = typeof(CatalogJson).Assembly.GetManifestResourceStream(resource)
            ?? throw new ArgumentException("Unknown catalog id: " + id, nameof(id));
        using var reader = new StreamReader(stream);
        return Parse(reader.ReadToEnd());
    }

    public static IReadOnlyList<MindPreset> LoadAll()
    {
        var assembly = typeof(CatalogJson).Assembly;
        var list = new List<MindPreset>();
        foreach (var name in assembly.GetManifestResourceNames())
        {
            if (!name.StartsWith(ResourcePrefix, StringComparison.Ordinal) || !name.EndsWith(".json", StringComparison.Ordinal))
                continue;
            using var stream = assembly.GetManifestResourceStream(name)!;
            using var reader = new StreamReader(stream);
            list.Add(Parse(reader.ReadToEnd()));
        }

        list.Sort((a, b) => string.CompareOrdinal(a.Id, b.Id));
        return list;
    }

    public static string ResourceName(string id) => ResourcePrefix + id + ".json";

    public static string DirectoryFor(string category) =>
        category switch
        {
            "profession" => "professions",
            "clan" => "clans",
            "temperament" => "temperament",
            _ => throw new ArgumentException("Unknown category: " + category, nameof(category))
        };

    private static PresetDocument ToDocument(MindPreset preset) =>
        new()
        {
            Id = preset.Id,
            Category = preset.Category,
            Traits = new TraitsDocument
            {
                Openness = Round(preset.Traits.Openness),
                Conscientiousness = Round(preset.Traits.Conscientiousness),
                Extraversion = Round(preset.Traits.Extraversion),
                Agreeableness = Round(preset.Traits.Agreeableness),
                Neuroticism = Round(preset.Traits.Neuroticism)
            },
            CognitiveStage = preset.Stage?.ToString(),
            IdentityStage = preset.IdentityStage?.ToString(),
            OperantSeeds = preset.OperantSeeds is { Count: > 0 } seeds
                ? new Dictionary<string, float>(seeds, StringComparer.Ordinal)
                : null,
            EnabledProviderIds = preset.EnabledProviderIds,
            Rationale = preset.Rationale.Select(c => new CitationDocument { Knob = c.Knob, Source = c.Source }).ToArray(),
            Bands = preset.Bands is { } bands
                ? new BandsDocument
                {
                    Openness = BandName(bands.Openness),
                    Conscientiousness = BandName(bands.Conscientiousness),
                    Extraversion = BandName(bands.Extraversion),
                    Agreeableness = BandName(bands.Agreeableness),
                    Neuroticism = BandName(bands.Neuroticism)
                }
                : null
        };

    private static MindPreset FromDocument(PresetDocument doc)
    {
        if (string.IsNullOrWhiteSpace(doc.Id))
            throw new ArgumentException("Catalog JSON requires id.");
        if (string.IsNullOrWhiteSpace(doc.Category))
            throw new ArgumentException("Catalog JSON requires category.");
        if (doc.Traits is null)
            throw new ArgumentException("Catalog JSON requires traits.");
        if (doc.EnabledProviderIds is null || doc.EnabledProviderIds.Length == 0)
            throw new ArgumentException("Catalog JSON requires enabledProviderIds.");

        IReadOnlyDictionary<string, float>? operants = null;
        if (doc.OperantSeeds is { Count: > 0 })
            operants = new Dictionary<string, float>(doc.OperantSeeds, StringComparer.Ordinal);

        var rationale = (doc.Rationale ?? Array.Empty<CitationDocument>())
            .Select(c => new CitationRef(c.Knob ?? "", c.Source ?? ""))
            .ToArray();

        return new MindPreset(
            doc.Id,
            doc.Category,
            new OceanTraits(
                doc.Traits.Openness,
                doc.Traits.Conscientiousness,
                doc.Traits.Extraversion,
                doc.Traits.Agreeableness,
                doc.Traits.Neuroticism),
            ParseStage(doc.CognitiveStage),
            ParseIdentity(doc.IdentityStage),
            operants,
            doc.EnabledProviderIds,
            rationale,
            ParseBands(doc.Bands));
    }

    private static CognitiveStage? ParseStage(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;
        return Enum.TryParse<CognitiveStage>(value, ignoreCase: true, out var stage)
            ? stage
            : throw new ArgumentException("Unknown cognitiveStage: " + value);
    }

    private static PsychosocialStage? ParseIdentity(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;
        return Enum.TryParse<PsychosocialStage>(value, ignoreCase: true, out var stage)
            ? stage
            : throw new ArgumentException("Unknown identityStage: " + value);
    }

    private static OceanBands? ParseBands(BandsDocument? bands)
    {
        if (bands is null)
            return null;
        return new OceanBands(
            ParseBand(bands.Openness),
            ParseBand(bands.Conscientiousness),
            ParseBand(bands.Extraversion),
            ParseBand(bands.Agreeableness),
            ParseBand(bands.Neuroticism));
    }

    private static TraitBand ParseBand(string? name) =>
        name?.ToLowerInvariant() switch
        {
            "low" => TraitBand.Low,
            "mid" => TraitBand.Mid,
            "high" => TraitBand.High,
            _ => throw new ArgumentException("Unknown trait band: " + name)
        };

    private static string BandName(TraitBand band)
    {
        if (band.Equals(TraitBand.Low)) return "low";
        if (band.Equals(TraitBand.Mid)) return "mid";
        if (band.Equals(TraitBand.High)) return "high";
        throw new ArgumentException("Band is not a named catalog range.");
    }

    private static float Round(float value) => MathF.Round(value, 3);

    private sealed class PresetDocument
    {
        public string? Id { get; set; }
        public string? Category { get; set; }
        public TraitsDocument? Traits { get; set; }
        public string? CognitiveStage { get; set; }
        public string? IdentityStage { get; set; }
        public Dictionary<string, float>? OperantSeeds { get; set; }
        public string[]? EnabledProviderIds { get; set; }
        public CitationDocument[]? Rationale { get; set; }
        public BandsDocument? Bands { get; set; }
    }

    private sealed class TraitsDocument
    {
        public float Openness { get; set; }
        public float Conscientiousness { get; set; }
        public float Extraversion { get; set; }
        public float Agreeableness { get; set; }
        public float Neuroticism { get; set; }
    }

    private sealed class BandsDocument
    {
        public string? Openness { get; set; }
        public string? Conscientiousness { get; set; }
        public string? Extraversion { get; set; }
        public string? Agreeableness { get; set; }
        public string? Neuroticism { get; set; }
    }

    private sealed class CitationDocument
    {
        public string? Knob { get; set; }
        public string? Source { get; set; }
    }
}
