using PersonalityEngine.Providers.Ocean;
using PersonalityEngine.Providers.Piaget;

namespace Archetypes;

/// <summary>
/// C# encoding of the first catalog rows. Markdown under <c>presets/</c> is the authoring source.
/// Keep these midpoints, operants, and provider lists in sync with those files.
/// </summary>
public static class Catalog
{
    public static readonly string[] AlmaAndSkinner =
    {
        "ocean",
        "ocean-to-pad",
        "pad-mood",
        "occ",
        "occ-to-pad",
        "skinner-operant"
    };

    public static MindPreset VillageSmith { get; } = new(
        "village-smith",
        "profession",
        new OceanTraits(0.45f, 0.78f, 0.35f, 0.50f, 0.32f),
        Stage: null,
        IdentityStage: null,
        OperantSeeds: Operants(("forge", 0.75f), ("repair", 0.70f), ("quench", 0.55f), ("haggle", 0.35f), ("idle", 0.20f)),
        EnabledProviderIds: AlmaAndSkinner,
        Rationale: new[]
        {
            new CitationRef("traits", "McCrae & Costa (2008)."),
            new CitationRef("conscientiousness", "Barrick & Mount (1991); Hurtz & Donovan (2000). Direction across occupations."),
            new CitationRef("other-traits", "project convention"),
            new CitationRef("operantSeeds", "Skinner (1953). Strengths and action ids: project convention."),
            new CitationRef("providers", "Gebhard (2005); Skinner (1953); Ferster & Skinner (1957).")
        },
        Bands: new OceanBands(TraitBand.Mid, TraitBand.High, TraitBand.Low, TraitBand.Mid, TraitBand.Low));

    public static MindPreset WildernessScout { get; } = new(
        "wilderness-scout",
        "profession",
        new OceanTraits(0.72f, 0.62f, 0.48f, 0.42f, 0.48f),
        Stage: null,
        IdentityStage: null,
        OperantSeeds: Operants(("scout", 0.75f), ("track", 0.70f), ("explore", 0.65f), ("forage", 0.55f), ("report", 0.50f)),
        EnabledProviderIds: Concat(AlmaAndSkinner, "peterson-metatraits", "peterson-maps"),
        Rationale: new[]
        {
            new CitationRef("traits", "McCrae & Costa (2008)."),
            new CitationRef("openness", "Barrick & Mount (1991) Openness and training proficiency. Exact midpoint: project convention."),
            new CitationRef("operantSeeds", "Skinner (1953). Strengths and action ids: project convention."),
            new CitationRef("peterson-maps", "DeYoung, Peterson & Higgins (2002); Peterson (1999). Enabling for a scout: project convention.")
        },
        Bands: new OceanBands(TraitBand.High, TraitBand.Mid, TraitBand.Mid, TraitBand.Mid, TraitBand.Mid));

    public static MindPreset RecordsClerk { get; } = new(
        "records-clerk",
        "profession",
        new OceanTraits(0.42f, 0.80f, 0.40f, 0.55f, 0.45f),
        Stage: null,
        IdentityStage: null,
        OperantSeeds: Operants(("file", 0.75f), ("copy", 0.70f), ("tally", 0.65f), ("recall-record", 0.60f), ("repeat-protocol", 0.55f)),
        EnabledProviderIds: AlmaAndSkinner,
        Rationale: new[]
        {
            new CitationRef("traits", "McCrae & Costa (2008)."),
            new CitationRef("conscientiousness", "Barrick & Mount (1991); Hurtz & Donovan (2000)."),
            new CitationRef("operantSeeds", "Skinner (1953). Strengths and action ids: project convention.")
        },
        Bands: new OceanBands(TraitBand.Mid, TraitBand.High, TraitBand.Low, TraitBand.Mid, TraitBand.Mid));

    public static MindPreset PhilobrainScholar { get; } = new(
        "philobrain-scholar",
        "clan",
        new OceanTraits(0.80f, 0.52f, 0.50f, 0.48f, 0.42f),
        Stage: CognitiveStage.FormalOperational,
        IdentityStage: null,
        OperantSeeds: Operants(("explore", 0.72f), ("hypothesize", 0.70f), ("debate", 0.62f), ("study", 0.58f), ("teach", 0.45f)),
        EnabledProviderIds: Concat(AlmaAndSkinner, "piaget-equilibration", "peterson-metatraits", "peterson-maps"),
        Rationale: new[]
        {
            new CitationRef("traits", "McCrae & Costa (2008). High Openness midpoint: project convention."),
            new CitationRef("cognitiveStage", "Inhelder & Piaget (1958); Piaget (1950). Choosing FormalOperational for the clan: project convention."),
            new CitationRef("operantSeeds", "Skinner (1953). Strengths and action ids: project convention."),
            new CitationRef("piaget-equilibration", "Piaget (1950, 1985); Inhelder & Piaget (1958).")
        },
        Bands: new OceanBands(TraitBand.High, TraitBand.Mid, TraitBand.Mid, TraitBand.Mid, TraitBand.Mid));

    public static MindPreset TrogWarrior { get; } = new(
        "trog-warrior",
        "clan",
        new OceanTraits(0.32f, 0.74f, 0.55f, 0.40f, 0.40f),
        Stage: CognitiveStage.ConcreteOperational,
        IdentityStage: null,
        OperantSeeds: Operants(("strike", 0.75f), ("guard", 0.70f), ("repeat-protocol", 0.68f), ("charge", 0.50f), ("idle", 0.22f)),
        EnabledProviderIds: Concat(AlmaAndSkinner, "piaget-equilibration"),
        Rationale: new[]
        {
            new CitationRef("traits", "McCrae & Costa (2008). Low Openness is not a Piaget stage and not an IQ. Exact midpoint: project convention."),
            new CitationRef("cognitiveStage", "Piaget (1950); Inhelder & Piaget (1958). ConcreteOperational for the clan: project convention."),
            new CitationRef("operantSeeds", "Skinner (1953). Strengths and action ids: project convention.")
        },
        Bands: new OceanBands(TraitBand.Low, TraitBand.High, TraitBand.Mid, TraitBand.Mid, TraitBand.Mid));

    public static IReadOnlyList<MindPreset> Seeds { get; } =
        new[] { VillageSmith, WildernessScout, RecordsClerk, PhilobrainScholar, TrogWarrior };

    private static IReadOnlyDictionary<string, float> Operants(params (string Id, float Strength)[] pairs)
    {
        var bag = new Dictionary<string, float>(StringComparer.Ordinal);
        foreach (var (id, strength) in pairs)
            bag[id] = strength;
        return bag;
    }

    private static string[] Concat(string[] head, params string[] tail)
    {
        var all = new string[head.Length + tail.Length];
        head.CopyTo(all, 0);
        tail.CopyTo(all, head.Length);
        return all;
    }
}
