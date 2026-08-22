# Archetypes

[![License: MIT](https://img.shields.io/badge/license-MIT-yellow.svg)](LICENSE)

Preset catalogs for [Personality Engine](https://github.com/RossSim/personality-engine): profession, fantasy-clan, and temperament **mind seeds** that map into PE constructor arguments.

A **preset** is a named starting mind: trait bands, optional cognitive flags, training history, and which Personality Engine layers to turn on. Numbers labeled **project convention** are game-feel choices, not scores from a paper.

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
- **Fantasy** clan, generic profession, and temperament ids — not real-world race or ethnicity presets in the public catalog

## What this is not

- Not a psychometric test, clinic, or personality type inventory (no MBTI)
- Not an `IAffectProvider` implementation (those stay in personality-engine)
- Not IQ or g-factor channels — use Piaget structure (when a clan sets a stage), operant history, and trait bands instead

See [Disclaimer](DISCLAIMER.md).

## Status

**1.0** (`Archetypes.Core` 1.0.0). Frozen `MindPreset` / `PresetBuilder` / `CatalogJson` contract. Profession, clan, and temperament catalogs. Packs as a GitHub Release nupkg depending on Personality Engine **0.6.1+** (`netstandard2.1`).

A Unity host that seeds those presets and a macOS playable (no Editor required) live in [NPC-demo](https://github.com/RossSim/NPC-demo). This repo stays catalogs plus builder.

```bash
bash scripts/restore-pe.sh
dotnet test
```

```csharp
using Archetypes;

// Compile-time row (C# catalog):
var engine = PresetBuilder.Build(Catalog.VillageSmith);
// Same row by id string (embedded JSON) when the host stores preset ids:
// var engine = PresetBuilder.Build(CatalogJson.Load("village-smith"));
engine.Tick(PersonalityEngine.WorldEvent.Tick);
```

Named heroes use the default `JitterTier.Named` (full stack). Ambient NPCs pass `new BuildOptions { Tier = JitterTier.Ambient }` (personality + mood; Piaget kept when the seed enabled it). Markdown under `presets/` is the authoring source. `Catalog` encodes every profession, clan, and temperament row in that index; `CatalogJson` loads the JSON sidecars.

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
| [Temperament catalog](presets/temperament/README.md) | Thomas & Chess climates, not types |
| [Citations](docs/CITATIONS.md) | Shared per-knob papers and project-convention labels |
| [Releasing](docs/RELEASING.md) | Version bump, changelog, GitHub Release pack |
| [Cursor start](docs/CURSOR_START.md) | Standing rules for new sessions |
| [Contributing](CONTRIBUTING.md) | Catalog-first patches; public-hygiene |
| [Changelog](CHANGELOG.md) | Version notes |
| [Disclaimer](DISCLAIMER.md) | Game software; not a test |
| [NPC-demo](https://github.com/RossSim/NPC-demo) | Unity host and macOS playable (separate repo) |

## Layout

```text
archetypes/
├── docs/
├── presets/                 # markdown + JSON catalog (markdown is authoring)
│   ├── schema.md
│   ├── professions/
│   ├── clans/
│   └── temperament/
├── src/Archetypes.Core/     # MindPreset, Catalog, CatalogJson, PresetBuilder
├── tests/Archetypes.Tests/
└── scripts/restore-pe.sh    # PersonalityEngine.Core 0.6.1 from GitHub Release
```

## License

[MIT](LICENSE). Personality Engine is also MIT; cite academic sources per preset knob in [`docs/CITATIONS.md`](docs/CITATIONS.md).
