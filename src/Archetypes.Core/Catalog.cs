using PersonalityEngine.Providers.Ocean;
using PersonalityEngine.Providers.Piaget;

namespace Archetypes;

/// <summary>
/// C# encoding of catalog rows. Markdown under <c>presets/</c> is the authoring source.
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
        Rationale: JobRationale("conscientiousness", "Barrick & Mount (1991); Hurtz & Donovan (2000). Direction across occupations."),
        Bands: new OceanBands(TraitBand.Mid, TraitBand.High, TraitBand.Low, TraitBand.Mid, TraitBand.Low));

    public static MindPreset Carpenter { get; } = Job(
        "carpenter",
        new OceanTraits(0.50f, 0.78f, 0.42f, 0.52f, 0.40f),
        new OceanBands(TraitBand.Mid, TraitBand.High, TraitBand.Mid, TraitBand.Mid, TraitBand.Mid),
        Operants(("measure", 0.72f), ("join", 0.76f), ("repair", 0.70f), ("plane", 0.55f), ("idle", 0.20f)),
        "conscientiousness",
        "Barrick & Mount (1991); Hurtz & Donovan (2000).");

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

    public static MindPreset TownWatch { get; } = Job(
        "town-watch",
        new OceanTraits(0.38f, 0.74f, 0.52f, 0.42f, 0.45f),
        new OceanBands(TraitBand.Low, TraitBand.High, TraitBand.Mid, TraitBand.Mid, TraitBand.Mid),
        Operants(("challenge", 0.72f), ("patrol", 0.70f), ("raise-alarm", 0.62f), ("repeat-protocol", 0.58f), ("idle", 0.22f)),
        "conscientiousness",
        "Barrick & Mount (1991) police/watch group direction. Exact midpoint: project convention.");

    public static MindPreset RecordsClerk { get; } = new(
        "records-clerk",
        "profession",
        new OceanTraits(0.42f, 0.80f, 0.40f, 0.55f, 0.45f),
        Stage: null,
        IdentityStage: null,
        OperantSeeds: Operants(("file", 0.75f), ("copy", 0.70f), ("tally", 0.65f), ("recall-record", 0.60f), ("repeat-protocol", 0.55f)),
        EnabledProviderIds: AlmaAndSkinner,
        Rationale: JobRationale("conscientiousness", "Barrick & Mount (1991); Hurtz & Donovan (2000)."),
        Bands: new OceanBands(TraitBand.Mid, TraitBand.High, TraitBand.Low, TraitBand.Mid, TraitBand.Mid));

    public static MindPreset GuildSteward { get; } = Job(
        "guild-steward",
        new OceanTraits(0.48f, 0.76f, 0.68f, 0.52f, 0.42f),
        new OceanBands(TraitBand.Mid, TraitBand.High, TraitBand.High, TraitBand.Mid, TraitBand.Mid),
        Operants(("assign", 0.72f), ("tally", 0.70f), ("hear-petition", 0.60f), ("refuse", 0.45f), ("idle", 0.20f)),
        "extraversion",
        "Barrick & Mount (1991) Extraversion for managers. Exact midpoint: project convention.");

    public static MindPreset MarketMerchant { get; } = Job(
        "market-merchant",
        new OceanTraits(0.52f, 0.58f, 0.74f, 0.50f, 0.45f),
        new OceanBands(TraitBand.Mid, TraitBand.Mid, TraitBand.High, TraitBand.Mid, TraitBand.Mid),
        Operants(("haggle", 0.75f), ("buy", 0.62f), ("sell", 0.72f), ("call-wares", 0.58f), ("idle", 0.22f)),
        "extraversion",
        "Barrick & Mount (1991) Extraversion for sales. Exact midpoint: project convention.");

    public static MindPreset Innkeeper { get; } = Job(
        "innkeeper",
        new OceanTraits(0.48f, 0.62f, 0.72f, 0.70f, 0.42f),
        new OceanBands(TraitBand.Mid, TraitBand.Mid, TraitBand.High, TraitBand.High, TraitBand.Mid),
        Operants(("serve", 0.74f), ("welcome", 0.68f), ("keep-tab", 0.60f), ("eject", 0.42f), ("idle", 0.22f)),
        "extraversion",
        "Barrick & Mount (1991) Extraversion for social-interaction jobs. Exact midpoint: project convention.");

    public static MindPreset Healer { get; } = Job(
        "healer",
        new OceanTraits(0.50f, 0.76f, 0.48f, 0.72f, 0.48f),
        new OceanBands(TraitBand.Mid, TraitBand.High, TraitBand.Mid, TraitBand.High, TraitBand.Mid),
        Operants(("bind", 0.74f), ("sit-with", 0.68f), ("dose", 0.62f), ("fetch-supply", 0.50f), ("idle", 0.20f)),
        "agreeableness",
        "project convention. Barrick & Mount did not treat Agreeableness as a strong general performance predictor.");

    public static MindPreset Apothecary { get; } = Job(
        "apothecary",
        new OceanTraits(0.52f, 0.80f, 0.48f, 0.58f, 0.45f),
        new OceanBands(TraitBand.Mid, TraitBand.High, TraitBand.Mid, TraitBand.Mid, TraitBand.Mid),
        Operants(("measure", 0.78f), ("compound", 0.72f), ("refuse", 0.50f), ("label", 0.55f), ("idle", 0.20f)),
        "conscientiousness",
        "Barrick & Mount (1991); Hurtz & Donovan (2000).");

    public static MindPreset SchoolTeacher { get; } = Job(
        "school-teacher",
        new OceanTraits(0.55f, 0.74f, 0.66f, 0.68f, 0.45f),
        new OceanBands(TraitBand.Mid, TraitBand.High, TraitBand.High, TraitBand.High, TraitBand.Mid),
        Operants(("drill", 0.74f), ("correct", 0.68f), ("keep-room", 0.62f), ("praise", 0.50f), ("idle", 0.20f)),
        "extraversion",
        "Barrick & Mount (1991) Extraversion for social-interaction jobs; holding a room. Exact midpoint: project convention.");

    public static MindPreset FieldFarmer { get; } = Job(
        "field-farmer",
        new OceanTraits(0.42f, 0.78f, 0.38f, 0.52f, 0.45f),
        new OceanBands(TraitBand.Mid, TraitBand.High, TraitBand.Low, TraitBand.Mid, TraitBand.Mid),
        Operants(("sow", 0.70f), ("tend", 0.74f), ("harvest", 0.72f), ("store", 0.60f), ("idle", 0.22f)),
        "conscientiousness",
        "Barrick & Mount (1991); Hurtz & Donovan (2000).");

    public static MindPreset Herder { get; } = Job(
        "herder",
        new OceanTraits(0.48f, 0.70f, 0.45f, 0.50f, 0.48f),
        new OceanBands(TraitBand.Mid, TraitBand.High, TraitBand.Mid, TraitBand.Mid, TraitBand.Mid),
        Operants(("move-flock", 0.74f), ("count", 0.70f), ("fold", 0.65f), ("call-dog", 0.55f), ("idle", 0.25f)),
        "conscientiousness",
        "Barrick & Mount (1991); Hurtz & Donovan (2000).");

    public static MindPreset WaterMiller { get; } = Job(
        "water-miller",
        new OceanTraits(0.44f, 0.80f, 0.36f, 0.50f, 0.42f),
        new OceanBands(TraitBand.Mid, TraitBand.High, TraitBand.Low, TraitBand.Mid, TraitBand.Mid),
        Operants(("tend-mill", 0.76f), ("grind", 0.70f), ("stop-mill", 0.62f), ("take-toll", 0.40f), ("idle", 0.22f)),
        "conscientiousness",
        "Barrick & Mount (1991); Hurtz & Donovan (2000).");

    public static MindPreset Porter { get; } = Job(
        "porter",
        new OceanTraits(0.38f, 0.70f, 0.48f, 0.52f, 0.40f),
        new OceanBands(TraitBand.Low, TraitBand.High, TraitBand.Mid, TraitBand.Mid, TraitBand.Mid),
        Operants(("lift", 0.76f), ("carry", 0.78f), ("set-down", 0.70f), ("take-fare", 0.45f), ("idle", 0.28f)),
        "conscientiousness",
        "Barrick & Mount (1991); Hurtz & Donovan (2000). Direction for trained work, not a caste. Do not encode as lower intelligence.");

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

    public static IReadOnlyList<MindPreset> Professions { get; } =
        new[]
        {
            VillageSmith, Carpenter, WildernessScout, TownWatch, RecordsClerk, GuildSteward,
            MarketMerchant, Innkeeper, Healer, Apothecary, SchoolTeacher, FieldFarmer,
            Herder, WaterMiller, Porter
        };

    public static IReadOnlyList<MindPreset> Clans { get; } =
        new[] { PhilobrainScholar, TrogWarrior };

    public static IReadOnlyList<MindPreset> Seeds { get; } =
        new[]
        {
            VillageSmith, Carpenter, WildernessScout, TownWatch, RecordsClerk, GuildSteward,
            MarketMerchant, Innkeeper, Healer, Apothecary, SchoolTeacher, FieldFarmer,
            Herder, WaterMiller, Porter, PhilobrainScholar, TrogWarrior
        };

    private static MindPreset Job(
        string id,
        OceanTraits traits,
        OceanBands bands,
        IReadOnlyDictionary<string, float> operants,
        string highlightKnob,
        string highlightSource) =>
        new(
            id,
            "profession",
            traits,
            Stage: null,
            IdentityStage: null,
            OperantSeeds: operants,
            EnabledProviderIds: AlmaAndSkinner,
            Rationale: JobRationale(highlightKnob, highlightSource),
            Bands: bands);

    private static CitationRef[] JobRationale(string highlightKnob, string highlightSource) =>
        new[]
        {
            new CitationRef("traits", "McCrae & Costa (2008)."),
            new CitationRef(highlightKnob, highlightSource),
            new CitationRef("operantSeeds", "Skinner (1953). Strengths and action ids: project convention.")
        };

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
