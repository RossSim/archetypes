# Archetypes

[![License: MIT](https://img.shields.io/badge/license-MIT-yellow.svg)](LICENSE)

Preset catalogs for [Personality Engine](https://github.com/RossSim/personality-engine): profession and fantasy-clan **mind seeds** (temperament later) that map into PE constructor arguments.

Personality Engine is runtime middleware (events in → snapshot out). Archetypes is **authoring data plus a builder**: markdown tables, C# `MindPreset` rows, and lore that turn “village blacksmith” or “Philobrain scholar” into `OceanTraits`, Piaget stage, operant seeds, and which providers to enable. It does not add new psychology providers to PE.

```mermaid
flowchart LR
  preset[Archetype preset]
  builder[PresetBuilder]
  pe[Personality Engine]
  game[Your game host]
  preset --> builder --> pe --> game
```

## What this is

- Cited **defaults** per knob (traits, cognitive stage, training history), not a single IQ score
- Optional **jitter** for named heroes vs ambient NPCs
- **Fantasy** clan and generic profession ids — not real-world race or ethnicity presets in the public catalog

## What this is not

- Not a psychometric test, clinic, or personality type inventory (no MBTI)
- Not an `IAffectProvider` implementation (those stay in personality-engine)
- Not IQ or g-factor channels — use Piaget structure, Sternberg domains (when PE ships them), operant history, and trait bands instead

See [Disclaimer](DISCLAIMER.md).

## Status

**0.1 builder** on `main`. Profession and clan catalogs plus `PresetBuilder` → Personality Engine `AffectEngine`. No public NuGet package yet (that waits for a schema freeze).

Depends on Personality Engine **0.6.1+** (`netstandard2.1`).

```bash
bash scripts/restore-pe.sh
dotnet test
```

```csharp
using Archetypes;

var engine = PresetBuilder.Build(Catalog.VillageSmith);
engine.Tick(PersonalityEngine.WorldEvent.Tick);
```

Named heroes use the default `JitterTier.Named` (full stack). Ambient NPCs pass `new BuildOptions { Tier = JitterTier.Ambient }` (personality + mood; Piaget kept when the seed enabled it). Markdown under `presets/` is the authoring source. `Catalog` currently encodes five of those rows in C# (`village-smith`, `wilderness-scout`, `records-clerk`, `philobrain-scholar`, `trog-warrior`).

## Documentation

| Doc | What it is |
| --- | --- |
| [Charter](docs/CHARTER.md) | What is fixed |
| [Roadmap](docs/ROADMAP.md) | What shipped vs later |
| [Design](docs/DESIGN.md) | Layers, builder, guardrails |
| [Catalog schema](presets/schema.md) | Shared row fields |
| [Catalog hub](presets/README.md) | Layout and profession guardrails |
| [Profession sampling](presets/professions/README.md) | ISCO-08 frame and job index |
| [Clan catalog](presets/clans/README.md) | Template, guardrails, Philobrain / Trog |
| [Cursor start](docs/CURSOR_START.md) | Standing rules for new sessions |
| [Changelog](CHANGELOG.md) | Version notes |
| [Disclaimer](DISCLAIMER.md) | Entertainment middleware; not a test |

## Layout

```text
archetypes/
├── docs/
├── presets/                 # markdown catalog (authoring source)
│   ├── schema.md
│   ├── professions/
│   └── clans/
├── src/Archetypes.Core/     # MindPreset, Catalog seeds, PresetBuilder
├── tests/Archetypes.Tests/
└── scripts/restore-pe.sh    # PersonalityEngine.Core 0.6.1 from GitHub Release
```

## License

[MIT](LICENSE). Personality Engine is also MIT; cite academic sources per preset knob in `docs/CITATIONS.md` when that file lands.
