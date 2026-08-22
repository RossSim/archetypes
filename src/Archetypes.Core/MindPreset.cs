using PersonalityEngine.Providers.Erikson;
using PersonalityEngine.Providers.Ocean;
using PersonalityEngine.Providers.Piaget;

namespace Archetypes;

/// <summary>
/// Catalog row as Personality Engine constructor args. Inferred from
/// <c>presets/</c> tables; markdown remains the authoring source.
/// </summary>
public sealed record MindPreset(
    string Id,
    string Category,
    OceanTraits Traits,
    CognitiveStage? Stage,
    PsychosocialStage? IdentityStage,
    IReadOnlyDictionary<string, float>? OperantSeeds,
    string[] EnabledProviderIds,
    IReadOnlyList<CitationRef> Rationale,
    OceanBands? Bands = null);
