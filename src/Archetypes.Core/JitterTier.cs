namespace Archetypes;

/// <summary>
/// Host-side cost tiers from the catalog jitter notes. Personality Engine has no jitter API.
/// </summary>
public enum JitterTier
{
    /// <summary>Full composition. Optional trait jitter ±0.05 inside the band.</summary>
    Named,

    /// <summary>
    /// Personality + mood; skip OCC, Peterson, Skinner, and Erikson. Keep Piaget when enabled.
    /// Optional trait jitter ±0.12 inside the band.
    /// </summary>
    Ambient,

    /// <summary>Same provider subset as ambient; meant for a shared district seed.</summary>
    Crowd
}
