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

    [Fact]
    public void Every_profession_omits_stages()
    {
        Assert.Equal(15, Catalog.Professions.Count);
        foreach (var job in Catalog.Professions)
        {
            Assert.Equal("profession", job.Category);
            Assert.Null(job.Stage);
            Assert.Null(job.IdentityStage);
        }
    }

    [Fact]
    public void Scout_is_the_only_profession_with_peterson()
    {
        foreach (var job in Catalog.Professions)
        {
            var peterson = job.EnabledProviderIds.Contains("peterson-maps");
            if (job.Id == "wilderness-scout")
                Assert.True(peterson);
            else
                Assert.False(peterson);
        }
    }

    [Fact]
    public void Porter_is_trained_work_not_a_cognitive_rank()
    {
        Assert.Null(Catalog.Porter.Stage);
        Assert.True(Catalog.Porter.Traits.Conscientiousness >= 0.65f);
        var snap = PresetBuilder.Build(Catalog.Porter).Snapshot;
        Assert.True(snap.TryGet(OperantLearningProvider.StrengthKey("carry"), out var carry));
        Assert.Equal(0.78f, carry, 3);
    }

    [Fact]
    public void Miller_applies_catalog_operant_strength()
    {
        var snap = PresetBuilder.Build(Catalog.WaterMiller).Snapshot;
        Assert.True(snap.TryGet(OperantLearningProvider.StrengthKey("tend-mill"), out var tend));
        Assert.Equal(0.76f, tend, 3);
    }

    [Fact]
    public void Every_temperament_omits_stages_and_skinner()
    {
        Assert.Equal(3, Catalog.Temperaments.Count);
        foreach (var row in Catalog.Temperaments)
        {
            Assert.Equal("temperament", row.Category);
            Assert.Null(row.Stage);
            Assert.Null(row.IdentityStage);
            Assert.Null(row.OperantSeeds);
            Assert.DoesNotContain("skinner-operant", row.EnabledProviderIds);
            Assert.DoesNotContain("piaget-equilibration", row.EnabledProviderIds);
            Assert.Contains("ocean-to-pad", row.EnabledProviderIds);
        }
    }

    [Fact]
    public void Temperament_is_not_neuroticism_alone()
    {
        Assert.True(Catalog.EasyTemperament.Traits.Extraversion >= 0.65f);
        Assert.True(Catalog.EasyTemperament.Traits.Agreeableness >= 0.65f);
        Assert.True(Catalog.EasyTemperament.Traits.Neuroticism <= 0.40f);

        Assert.True(Catalog.DifficultTemperament.Traits.Extraversion <= 0.40f);
        Assert.True(Catalog.DifficultTemperament.Traits.Agreeableness <= 0.40f);
        Assert.True(Catalog.DifficultTemperament.Traits.Conscientiousness <= 0.40f);
        Assert.True(Catalog.DifficultTemperament.Traits.Neuroticism >= 0.65f);

        Assert.True(Catalog.SlowToWarmUp.Traits.Extraversion <= 0.40f);
        Assert.InRange(Catalog.SlowToWarmUp.Traits.Agreeableness, 0.40f, 0.60f);
        Assert.InRange(Catalog.SlowToWarmUp.Traits.Neuroticism, 0.40f, 0.60f);
    }

    [Fact]
    public void Temperament_pad_baseline_comes_from_ocean_to_pad()
    {
        var easy = OceanToPadMapping.Map(Catalog.EasyTemperament.Traits);
        var difficult = OceanToPadMapping.Map(Catalog.DifficultTemperament.Traits);
        var slow = OceanToPadMapping.Map(Catalog.SlowToWarmUp.Traits);

        var snap = PresetBuilder.Build(Catalog.EasyTemperament).Snapshot;
        Assert.True(snap.TryGet(OceanToPadMapping.PleasureKey, out var pleasure));
        Assert.Equal(easy.Pleasure, pleasure, 3);
        Assert.True(easy.Pleasure > slow.Pleasure);
        Assert.True(slow.Pleasure > difficult.Pleasure);
        Assert.False(snap.TryGet(OperantLearningProvider.StrengthKey("forge"), out _));
    }

    [Fact]
    public void Named_temperament_still_records_occ()
    {
        var engine = PresetBuilder.Build(Catalog.DifficultTemperament);
        engine.Tick(new WorldEvent(OccEmotion.DistressKind, 1f));
        Assert.True(engine.Snapshot.TryGet(OccEmotion.DistressKey, out var distress));
        Assert.True(distress > 0f);
    }

    public static IEnumerable<object[]> CatalogSeeds()
    {
        foreach (var seed in Catalog.Seeds)
            yield return new object[] { seed };
    }
}
