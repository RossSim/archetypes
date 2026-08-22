# Design

How Archetypes sits beside Personality Engine without forking psychology.

## Catalog-first

Tables come first. A profession or clan file in `presets/` is a **row**: fiction, knobs Personality Engine can already take, and per-knob citations. `MindPreset` and `PresetBuilder` are inferred from those rows. Do not invent knobs PE cannot consume yet.

## Split of responsibility

| Layer | Personality Engine | Archetypes |
| --- | --- | --- |
| Runtime tick | `AffectEngine.Tick` | — |
| Cited theory | `IAffectProvider` implementations | — |
| Starting profile | Constructor args | Catalog tables, later `MindPreset` |
| Lore names | — | `philobrain-scholar`, `trog-warrior` |
| Builder | `AlmaComposition.Create(...)` | `PresetBuilder.Build(preset)` |

## Catalog row (now)

Every public entry should be able to carry:

- `id`, `category` (`profession`, `clan`, later `temperament`)
- `traits` — five OCEAN 0..1, or a documented band plus a midpoint
- `operantSeeds` — action-id → strength for training history
- `enabledProviderIds` — which PE providers this seed expects
- `citations` — per knob: paper **or** `project convention`
- optional `cognitiveStage`, `identityStage`
- optional `jitter` notes (named vs ambient)
- a short **fiction** blurb separate from knobs

Markdown or JSON is fine for authoring. The builder reads `MindPreset` in C#; embedded JSON is a later epic. The first rows live in [`presets/`](../presets/README.md); field definitions are in [`presets/schema.md`](../presets/schema.md).

## Profession catalog guardrails

Profession entries (and any later job added to `presets/professions/`) must pass:

- No IQ, g, or composite cognitive rank — including “this job is smarter”
- No real-world race, ethnicity, or national presets
- No MBTI
- Fiction ≠ science: the blurb must not stand in for a citation
- Every numeric knob cites a paper **or** is labeled **project convention**
- Only Personality Engine 0.6.1+ constructor args
- Omit `cognitiveStage` / `identityStage` on generic adult jobs unless the host is portraying a developmental role

The same list is in [`presets/README.md`](../presets/README.md). Occupational *space* is sampled with at least one generic job per ILO ISCO-08 major group; see [`presets/professions/README.md`](../presets/professions/README.md). Do not import ISCO skill levels as Piaget stage, IQ, or prestige.

## Clan catalog guardrails

On top of the profession list:

- Public catalog: fantasy ids only (`philobrain-scholar`, `trog-warrior`, …)
- No real-world race, ethnicity, or national cognitive rank tables
- Cognitive difference = Piaget structure + operant training + trait bands — never “less intelligent people”
- Three sections required: Fiction / Knobs / Citations
- Template: [`presets/clans/README.md`](../presets/clans/README.md)

## MindPreset

Inferred from the profession and clan tables:

```csharp
public sealed record MindPreset(
    string Id,
    string Category,              // profession, temperament, clan
    OceanTraits Traits,
    CognitiveStage? Stage,
    PsychosocialStage? IdentityStage,
    IReadOnlyDictionary<string, float>? OperantSeeds,
    string[] EnabledProviderIds,
    IReadOnlyList<CitationRef> Rationale);
```

`PresetBuilder.Build(preset)` assembles PE providers from `enabledProviderIds` (PE has no enable-by-id API) and applies catalog operant strengths via `AffectPersist` import — PE 0.6.1 seeds action ids at default operant level only. Named vs ambient jitter is host-side.

`CitationRef` ties each knob to a paper or labels it **project convention**. Drop or add fields if later catalogs show the record is wrong.

## Fantasy vs science docs

Each clan preset should split:

1. **Fiction** — what players see in the world (“Philobrain clan prizes hypotheticals”)
2. **Knobs** — Piaget formal operational, high Openness, strong explore operants
3. **Citations** — Piaget 1950; McCrae & Costa 2008; project convention for operant strengths

Avoid one bibliography backing the whole archetype.

## Cognitive difference without IQ

| Player-visible behavior | Knob |
| --- | --- |
| Won’t follow hypothetical clues | `CognitiveStage.Preoperational`, `hypothetical` flag off |
| Repeats old tactic | Skinner strength on `repeat-protocol` |
| Won’t try the puzzle | Self-efficacy channel when PE ships a Bandura provider |
| Curious vs rigid | OCEAN Openness |
| Trained for the job | Operant history + Conscientiousness |

## Tiers and jitter

- **Named** — full preset composition
- **Ambient** — personality + mood only, ± jitter on traits
- **Crowd** — shared district seed (Personality Engine applications notes: cost of one instance per walker)

## Multiplayer note

Presets produce local PE state. Games replicate persist blobs or authoritative channels on the server — Archetypes does not handle netcode.
