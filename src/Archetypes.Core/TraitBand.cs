namespace Archetypes;

/// <summary>Inclusive 0..1 range from the catalog band table. Project convention.</summary>
public readonly record struct TraitBand(float Min, float Max)
{
    public static TraitBand Low { get; } = new(0.20f, 0.40f);
    public static TraitBand Mid { get; } = new(0.40f, 0.60f);
    public static TraitBand High { get; } = new(0.65f, 0.85f);
}

/// <summary>Per-trait bands so jitter can stay inside the authored range.</summary>
public sealed record OceanBands(
    TraitBand Openness,
    TraitBand Conscientiousness,
    TraitBand Extraversion,
    TraitBand Agreeableness,
    TraitBand Neuroticism);
