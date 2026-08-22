namespace Archetypes;

public sealed record BuildOptions
{
    public JitterTier Tier { get; init; } = JitterTier.Named;

    /// <summary>
    /// When set, jitter traits inside the catalog band. When omitted, midpoints are used as written
    /// so tests and named heroes can be deterministic.
    /// </summary>
    public int? Seed { get; init; }
}
