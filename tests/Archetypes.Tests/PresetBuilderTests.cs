using Archetypes;
using PersonalityEngine;
using PersonalityEngine.Providers.Occ;
using PersonalityEngine.Providers.Ocean;
using PersonalityEngine.Providers.Peterson;
using PersonalityEngine.Providers.Piaget;
using PersonalityEngine.Providers.Skinner;
using Xunit;

namespace Archetypes.Tests;

public sealed class PresetBuilderTests
{
    [Theory]
    [MemberData(nameof(CatalogSeeds))]
    public void Named_writes_catalog_ocean_midpoints(MindPreset preset)
    {
        var snap = PresetBuilder.Build(preset).Snapshot;
        Assert.True(OceanTraits.TryRead(snap, out var traits));
        Assert.Equal(preset.Traits.Openness, traits.Openness, 3);
        Assert.Equal(preset.Traits.Conscientiousness, traits.Conscientiousness, 3);
        Assert.Equal(preset.Traits.Extraversion, traits.Extraversion, 3);
        Assert.Equal(preset.Traits.Agreeableness, traits.Agreeableness, 3);
        Assert.Equal(preset.Traits.Neuroticism, traits.Neuroticism, 3);
    }

    [Fact]
    public void Smith_applies_catalog_operant_strengths_not_pe_default()
    {
        var snap = PresetBuilder.Build(Catalog.VillageSmith).Snapshot;
        Assert.True(snap.TryGet(OperantLearningProvider.StrengthKey("forge"), out var forge));
        Assert.True(snap.TryGet(OperantLearningProvider.StrengthKey("idle"), out var idle));
        Assert.Equal(0.75f, forge, 3);
        Assert.Equal(0.20f, idle, 3);
        Assert.True(forge > 0.15f);
    }

    [Fact]
    public void Philobrain_turns_hypothetical_on()
    {
        var snap = PresetBuilder.Build(Catalog.PhilobrainScholar).Snapshot;
        Assert.True(snap.TryGet(PiagetEquilibrationProvider.HypotheticalKey, out var flag));
        Assert.Equal(1f, flag, 3);
        Assert.True(snap.TryGet(StabilityPlasticityProvider.PlasticityKey, out _));
    }

    [Fact]
    public void Trog_keeps_conservation_and_turns_hypothetical_off()
    {
        var snap = PresetBuilder.Build(Catalog.TrogWarrior).Snapshot;
        Assert.True(snap.TryGet(PiagetEquilibrationProvider.HypotheticalKey, out var hypothetical));
        Assert.True(snap.TryGet(PiagetEquilibrationProvider.ConservationKey, out var conservation));
        Assert.Equal(0f, hypothetical, 3);
        Assert.Equal(1f, conservation, 3);
        Assert.False(snap.TryGet(StabilityPlasticityProvider.PlasticityKey, out _));
    }

    [Fact]
    public void Ambient_smith_skips_occ_and_skinner()
    {
        var options = new BuildOptions { Tier = JitterTier.Ambient };
        var engine = PresetBuilder.Build(Catalog.VillageSmith, options);
        engine.Tick(new WorldEvent(OccEmotion.JoyKind, 1f));
        var snap = engine.Snapshot;

        Assert.True(OceanTraits.TryRead(snap, out _));
        Assert.False(snap.TryGet(OccEmotion.JoyKey, out _));
        Assert.False(snap.TryGet(OperantLearningProvider.StrengthKey("forge"), out _));
    }

    [Fact]
    public void Named_smith_records_occ_joy()
    {
        var engine = PresetBuilder.Build(Catalog.VillageSmith);
        engine.Tick(new WorldEvent(OccEmotion.JoyKind, 1f));
        Assert.True(engine.Snapshot.TryGet(OccEmotion.JoyKey, out var joy));
        Assert.True(joy > 0f);
    }

    [Fact]
    public void Ambient_philobrain_keeps_piaget()
    {
        var snap = PresetBuilder.Build(
            Catalog.PhilobrainScholar,
            new BuildOptions { Tier = JitterTier.Ambient }).Snapshot;
        Assert.True(snap.TryGet(PiagetEquilibrationProvider.HypotheticalKey, out var flag));
        Assert.Equal(1f, flag, 3);
        Assert.False(snap.TryGet(StabilityPlasticityProvider.PlasticityKey, out _));
    }

    [Fact]
    public void Seeded_jitter_stays_inside_expanded_band()
    {
        var snap = PresetBuilder.Build(
            Catalog.VillageSmith,
            new BuildOptions { Tier = JitterTier.Named, Seed = 7 }).Snapshot;
        Assert.True(OceanTraits.TryRead(snap, out var traits));
        Assert.InRange(traits.Conscientiousness, 0.65f, 0.85f);
        Assert.InRange(traits.Extraversion, 0.20f, 0.40f);
        Assert.NotEqual(Catalog.VillageSmith.Traits.Conscientiousness, traits.Conscientiousness);
    }

    [Fact]
    public void Unknown_provider_id_throws()
    {
        var bad = Catalog.VillageSmith with { EnabledProviderIds = new[] { "ocean", "not-a-provider" } };
        Assert.Throws<ArgumentException>(() => PresetBuilder.Build(bad));
    }

    public static IEnumerable<object[]> CatalogSeeds()
    {
        foreach (var seed in Catalog.Seeds)
            yield return new object[] { seed };
    }
}
