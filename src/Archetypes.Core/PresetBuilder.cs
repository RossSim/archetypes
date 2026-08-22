using PersonalityEngine;
using PersonalityEngine.Providers.Erikson;
using PersonalityEngine.Providers.Occ;
using PersonalityEngine.Providers.Ocean;
using PersonalityEngine.Providers.Pad;
using PersonalityEngine.Providers.Peterson;
using PersonalityEngine.Providers.Piaget;
using PersonalityEngine.Providers.Skinner;

namespace Archetypes;

/// <summary>
/// Maps a <see cref="MindPreset"/> into an <see cref="AffectEngine"/>.
/// Personality Engine has no enable-by-id or jitter API; both are host-side here.
/// </summary>
public static class PresetBuilder
{
    public const float NamedJitter = 0.05f;
    public const float AmbientJitter = 0.12f;

    private static readonly string[] AlmaOrder =
    {
        "ocean",
        "ocean-to-pad",
        "occ",
        "occ-to-pad",
        "pad-mood",
        "peterson-metatraits",
        "peterson-maps",
        "skinner-operant",
        "piaget-equilibration",
        "erikson-psychosocial"
    };

    private static readonly HashSet<string> KnownIds = new(AlmaOrder, StringComparer.Ordinal);

    private static readonly HashSet<string> AmbientSkip = new(StringComparer.Ordinal)
    {
        "occ",
        "occ-to-pad",
        "peterson-metatraits",
        "peterson-maps",
        "skinner-operant",
        "erikson-psychosocial"
    };

    public static AffectEngine Build(MindPreset preset, BuildOptions? options = null)
    {
        if (preset is null)
            throw new ArgumentNullException(nameof(preset));

        options ??= new BuildOptions();
        var enabled = FilterEnabled(preset, options.Tier);
        var traits = ApplyJitter(preset, options);
        var providers = new List<IAffectProvider>();
        var weighters = new List<IActionWeighter>();

        foreach (var id in AlmaOrder)
        {
            if (!enabled.Contains(id))
                continue;

            switch (id)
            {
                case "ocean":
                    providers.Add(new OceanPersonality(traits));
                    break;
                case "ocean-to-pad":
                    providers.Add(new OceanToPadMapping());
                    break;
                case "occ":
                    providers.Add(new OccEmotion());
                    break;
                case "occ-to-pad":
                    providers.Add(new OccToPadMapping());
                    break;
                case "pad-mood":
                    providers.Add(new PadMood { DecayRate = 0.5f });
                    break;
                case "peterson-metatraits":
                    providers.Add(new StabilityPlasticityProvider(traits));
                    break;
                case "peterson-maps":
                    providers.Add(new OrderChaosMeaningProvider());
                    weighters.Add(new PetersonMeaningWeighter());
                    break;
                case "skinner-operant":
                    var actionIds = preset.OperantSeeds?.Keys.ToArray() ?? Array.Empty<string>();
                    providers.Add(new OperantLearningProvider(actionIds, randomSeed: options.Seed ?? 1));
                    weighters.Add(new OperantWeighter());
                    break;
                case "piaget-equilibration":
                    if (preset.Stage is not { } stage)
                        throw new ArgumentException("piaget-equilibration requires cognitiveStage.", nameof(preset));
                    providers.Add(new PiagetEquilibrationProvider(stage));
                    weighters.Add(new PiagetCognitionWeighter());
                    break;
                case "erikson-psychosocial":
                    if (preset.IdentityStage is not { } identity)
                        throw new ArgumentException("erikson-psychosocial requires identityStage.", nameof(preset));
                    providers.Add(new EriksonPsychosocialProvider(identity));
                    weighters.Add(new EriksonIdentityWeighter());
                    break;
            }
        }

        var engine = new AffectEngine(providers, weighters);

        if (enabled.Contains("skinner-operant") && preset.OperantSeeds is { Count: > 0 } seeds)
        {
            var bag = new Dictionary<string, float>(StringComparer.Ordinal);
            foreach (var pair in seeds)
                bag[OperantLearningProvider.StrengthKey(pair.Key)] = pair.Value;

            engine.Import(new AffectPersist
            {
                Providers =
                {
                    [OperantLearningProvider.ProviderId] = bag
                }
            });
        }

        engine.Tick(WorldEvent.Tick);
        return engine;
    }

    private static HashSet<string> FilterEnabled(MindPreset preset, JitterTier tier)
    {
        var raw = preset.EnabledProviderIds ?? Array.Empty<string>();
        var unknown = raw.Where(id => !KnownIds.Contains(id)).Distinct(StringComparer.Ordinal).ToArray();
        if (unknown.Length > 0)
            throw new ArgumentException("Unknown provider id: " + string.Join(", ", unknown), nameof(preset));

        var enabled = new HashSet<string>(raw, StringComparer.Ordinal);
        if (tier is JitterTier.Ambient or JitterTier.Crowd)
            enabled.ExceptWith(AmbientSkip);

        return enabled;
    }

    private static OceanTraits ApplyJitter(MindPreset preset, BuildOptions options)
    {
        if (options.Seed is null)
            return preset.Traits;

        var delta = options.Tier == JitterTier.Named ? NamedJitter : AmbientJitter;
        var rng = new Random(options.Seed.Value);
        var t = preset.Traits;
        var bands = preset.Bands;

        return new OceanTraits(
            JitterOne(t.Openness, bands?.Openness, delta, rng),
            JitterOne(t.Conscientiousness, bands?.Conscientiousness, delta, rng),
            JitterOne(t.Extraversion, bands?.Extraversion, delta, rng),
            JitterOne(t.Agreeableness, bands?.Agreeableness, delta, rng),
            JitterOne(t.Neuroticism, bands?.Neuroticism, delta, rng));
    }

    private static float JitterOne(float midpoint, TraitBand? band, float delta, Random rng)
    {
        var offset = ((float)rng.NextDouble() * 2f - 1f) * delta;
        var value = midpoint + offset;
        var min = 0f;
        var max = 1f;
        if (band is { } b)
        {
            min = Math.Min(b.Min, midpoint);
            max = Math.Max(b.Max, midpoint);
        }

        if (value < min) return min;
        if (value > max) return max;
        return value;
    }
}
