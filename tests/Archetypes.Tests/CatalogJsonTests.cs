using Archetypes;
using PersonalityEngine.Providers.Piaget;
using Xunit;

namespace Archetypes.Tests;

public sealed class CatalogJsonTests
{
    [Theory]
    [MemberData(nameof(CatalogSeeds))]
    public void Roundtrip_matches_catalog_seed(MindPreset preset)
    {
        var loaded = CatalogJson.Parse(CatalogJson.Serialize(preset));
        AssertEqual(preset, loaded);
    }

    [Theory]
    [MemberData(nameof(CatalogSeeds))]
    public void Embedded_json_matches_catalog_seed(MindPreset preset)
    {
        var loaded = CatalogJson.Load(preset.Id);
        AssertEqual(preset, loaded);
        Assert.True(OceanTraitsMatch(preset, loaded));
        var engine = PresetBuilder.Build(loaded);
        Assert.True(PersonalityEngine.Providers.Ocean.OceanTraits.TryRead(engine.Snapshot, out var traits));
        Assert.Equal(preset.Traits.Openness, traits.Openness, 3);
    }

    [Fact]
    public void LoadAll_covers_every_catalog_seed()
    {
        var loaded = CatalogJson.LoadAll();
        Assert.Equal(Catalog.Seeds.Count, loaded.Count);
        Assert.Equal(
            Catalog.Seeds.Select(s => s.Id).OrderBy(id => id, StringComparer.Ordinal),
            loaded.Select(s => s.Id));
    }

    [Fact]
    public void Unknown_id_throws()
    {
        Assert.Throws<ArgumentException>(() => CatalogJson.Load("not-a-seed"));
    }

    [Fact]
    public void Empty_json_throws()
    {
        Assert.Throws<ArgumentException>(() => CatalogJson.Parse(" "));
    }

    [Fact]
    public void Export_catalog_json_when_requested()
    {
        var root = Environment.GetEnvironmentVariable("EXPORT_CATALOG_JSON");
        if (string.IsNullOrEmpty(root))
            return;

        foreach (var seed in Catalog.Seeds)
        {
            var dir = Path.Combine(root, "presets", CatalogJson.DirectoryFor(seed.Category));
            Directory.CreateDirectory(dir);
            File.WriteAllText(Path.Combine(dir, seed.Id + ".json"), CatalogJson.Serialize(seed));
        }
    }

    [Fact]
    public void Clan_json_keeps_piaget_stage()
    {
        var loaded = CatalogJson.Load("philobrain-scholar");
        Assert.Equal(CognitiveStage.FormalOperational, loaded.Stage);
        Assert.Null(loaded.IdentityStage);
    }

    [Fact]
    public void Temperament_json_omits_operants()
    {
        var loaded = CatalogJson.Load("easy-temperament");
        Assert.Null(loaded.OperantSeeds);
        Assert.DoesNotContain("skinner-operant", loaded.EnabledProviderIds);
    }

    public static IEnumerable<object[]> CatalogSeeds()
    {
        foreach (var seed in Catalog.Seeds)
            yield return new object[] { seed };
    }

    private static void AssertEqual(MindPreset expected, MindPreset actual)
    {
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.Category, actual.Category);
        Assert.Equal(expected.Stage, actual.Stage);
        Assert.Equal(expected.IdentityStage, actual.IdentityStage);
        Assert.Equal(expected.EnabledProviderIds, actual.EnabledProviderIds);
        Assert.Equal(expected.Rationale, actual.Rationale);
        Assert.Equal(expected.Bands, actual.Bands);
        Assert.True(OceanTraitsMatch(expected, actual));
        Assert.Equal(expected.OperantSeeds is null, actual.OperantSeeds is null);
        if (expected.OperantSeeds is null)
            return;

        Assert.Equal(expected.OperantSeeds.Count, actual.OperantSeeds!.Count);
        foreach (var pair in expected.OperantSeeds)
        {
            Assert.True(actual.OperantSeeds.TryGetValue(pair.Key, out var strength));
            Assert.Equal(pair.Value, strength, 3);
        }
    }

    private static bool OceanTraitsMatch(MindPreset expected, MindPreset actual) =>
        Math.Abs(expected.Traits.Openness - actual.Traits.Openness) < 0.0005f
        && Math.Abs(expected.Traits.Conscientiousness - actual.Traits.Conscientiousness) < 0.0005f
        && Math.Abs(expected.Traits.Extraversion - actual.Traits.Extraversion) < 0.0005f
        && Math.Abs(expected.Traits.Agreeableness - actual.Traits.Agreeableness) < 0.0005f
        && Math.Abs(expected.Traits.Neuroticism - actual.Traits.Neuroticism) < 0.0005f;
}
