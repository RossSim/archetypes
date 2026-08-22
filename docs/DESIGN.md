# Design

How Archetypes sits beside Personality Engine without forking psychology.

## Catalog-first

Tables come first. A profession, clan, or temperament file in `presets/` is a **row**: fiction, knobs Personality Engine can already take, and per-knob citations. `MindPreset` and `PresetBuilder` are inferred from those rows. Do not invent knobs PE cannot consume yet.

## Split of responsibility

| Layer | Personality Engine | Archetypes |
| --- | --- | --- |
| Runtime tick | `AffectEngine.Tick` | — |
| Cited theory | `IAffectProvider` implementations | — |
| Starting profile | Constructor args | Catalog tables → `MindPreset` |
| Lore names | — | `philobrain-scholar`, `trog-warrior` |
| Builder | `AlmaComposition.Create(...)` | `PresetBuilder.Build(preset)` |

A Unity game that ticks those engines lives in [NPC-demo](https://github.com/RossSim/NPC-demo), not in this repo.

## Catalog row

Every public entry should be able to carry:

- `id`, `category` (`profession`, `clan`, `temperament`)
- `traits` — five OCEAN 0..1, or a documented band plus a midpoint
- `operantSeeds` — action-id → strength for training history
- `enabledProviderIds` — which PE providers this seed expects
- `citations` — per knob: paper **or** `project convention`
- optional `cognitiveStage`, `identityStage`
- optional `jitter` notes (named vs ambient)
- a short **fiction** blurb separate from knobs

Markdown is the authoring format. C# `Catalog` encodes those rows. `CatalogJson` loads the same rows from embedded JSON under `presets/`. Field definitions: [`presets/schema.md`](../presets/schema.md). Catalog hub: [`presets/README.md`](../presets/README.md). Shared papers: [`CITATIONS.md`](CITATIONS.md).

## Profession catalog guardrails

Merge rules are in the [charter](CHARTER.md) (normative) and [`presets/README.md`](../presets/README.md) (checklist). Occupational *space* is sampled with at least one generic job per ILO ISCO-08 major group; see [`presets/professions/README.md`](../presets/professions/README.md). Do not import ISCO skill levels as Piaget stage, IQ, or prestige.

## Clan catalog guardrails

Clan template and extra rules: [`presets/clans/README.md`](../presets/clans/README.md). Public catalog: fantasy ids only. Piaget `cognitiveStage` on a clan is a host-set flag for PE’s `hypothetical` channel, not a claim that a people is stuck in a childhood stage or is less intelligent.

## Temperament catalog guardrails

Temperament template and extra rules: [`presets/temperament/README.md`](../presets/temperament/README.md). Unique to that catalog: not a type inventory; PAD from `ocean-to-pad`; omit Skinner, Piaget, and Erikson.

## MindPreset

Inferred from the catalog tables:

```csharp
public sealed record MindPreset(
    string Id,
    string Category,              // profession, clan, temperament
    OceanTraits Traits,
    CognitiveStage? Stage,
    PsychosocialStage? IdentityStage,
    IReadOnlyDictionary<string, float>? OperantSeeds,
    string[] EnabledProviderIds,
    IReadOnlyList<CitationRef> Rationale,
    OceanBands? Bands = null);
```

`PresetBuilder.Build(preset)` assembles PE providers from `enabledProviderIds` (PE has no enable-by-id API) and applies catalog operant strengths via `AffectPersist` import — PE 0.6.1 seeds action ids at default operant level only. Named vs ambient jitter is host-side. Optional `Bands` let jitter stay inside the authored range.

`CitationRef` ties each knob to a paper or labels it **project convention**.

`Catalog` encodes every profession, clan, and temperament markdown row in C#. `CatalogJson.Load(id)` reads the matching embedded JSON.

## 1.0 contract

These shapes are frozen. New catalog **rows** (another job, clan, or climate) are compatible. Removing or renaming a field, JSON key, jitter magnitude, or known provider id is a **major** bump. Optional additive fields are a **minor** bump. See [Releasing](RELEASING.md).

**`MindPreset`:** `Id`, `Category` (`profession` / `clan` / `temperament`), `Traits` (OCEAN 0..1), optional `Stage` / `IdentityStage`, optional `OperantSeeds`, `EnabledProviderIds`, `Rationale`, optional `Bands` (`low` / `mid` / `high`).

**`PresetBuilder.Build(preset, options?)`:** assembles PE 0.6.1+ providers from `enabledProviderIds`. Named keeps the listed stack. Ambient and crowd skip `occ`, `occ-to-pad`, `peterson-metatraits`, `peterson-maps`, `skinner-operant`, and `erikson-psychosocial`; they keep Piaget when enabled. Omit `BuildOptions.Seed` for catalog midpoints. Named jitter ±0.05; ambient/crowd ±0.12; both clamp inside the band (expanding the band if the midpoint sits outside).

**Known provider ids:** `ocean`, `ocean-to-pad`, `occ`, `occ-to-pad`, `pad-mood`, `peterson-metatraits`, `peterson-maps`, `skinner-operant`, `piaget-equilibration`, `erikson-psychosocial`.

**`CatalogJson`:** camelCase DTO documents (not polymorphic types). `Parse` / `Serialize` / `Load(id)` / `LoadAll`. Band names are `low` / `mid` / `high`. Stages are enum names (`FormalOperational`, …). Extra JSON members are ignored.

## Fantasy vs science docs

Each clan preset should split:

1. **Fiction** — what players see in the world (“Philobrain clan prizes hypotheticals”)
2. **Knobs** — Piaget formal operational, high Openness, strong explore operants
3. **Citations** — Piaget 1950; McCrae & Costa 2008; project convention for operant strengths

Avoid one bibliography backing the whole archetype. Profession files use the same three sections.

## Cognitive difference without IQ

Piaget described **child development**. A clan `cognitiveStage` is a host-set flag for PE’s `hypothetical` channel (on at `FormalOperational`). That is a game metaphor — **project convention** — not a claim that a people is stuck in childhood or is less intelligent.

| Player-visible behavior | Knob |
| --- | --- |
| Won’t follow hypothetical clues | `cognitiveStage` below `FormalOperational` (PE `hypothetical` flag off) |
| Repeats old tactic | Skinner strength on `repeat-protocol` |
| Won’t try the puzzle | Self-efficacy channel when PE ships a Bandura provider |
| Curious vs rigid | OCEAN Openness |
| Trained for the job | Operant history + Conscientiousness |

## Tiers and jitter

Personality Engine has no jitter API. `BuildOptions.Seed` is optional; omit it to use catalog midpoints as written.

| Tier | What `PresetBuilder` does |
| --- | --- |
| Named | Full composition. With a seed: trait jitter ±0.05 inside the band |
| Ambient | Personality + mood; skip OCC, Peterson, Skinner, and Erikson; keep Piaget when enabled. With a seed: ±0.12 |
| Crowd | Same provider subset as ambient; meant for a shared district seed |

Catalog jitter notes on each markdown file are author intent for those magnitudes.

## Multiplayer note

Presets produce local PE state. Games replicate persist blobs or authoritative channels on the server — Archetypes does not handle netcode.
