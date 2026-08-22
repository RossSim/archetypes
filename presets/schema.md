# Catalog entry schema

Shared **table row** for profession, clan, and temperament entries. Markdown is the authoring format; the C# record is `MindPreset` in `src/Archetypes.Core`.

Personality Engine **0.6.1+** knobs only. Do not invent fields the engine cannot consume yet.

## Required

| Field | What it is |
| --- | --- |
| `id` | Kebab-case preset id (`village-smith`) |
| `category` | `profession`, `clan`, or `temperament` |
| `fiction` | Short designer-facing blurb. Not a citation. |
| `traits` | Five OCEAN values in 0..1, **or** a named band plus a recommended midpoint. Constructor order in PE: Openness, Conscientiousness, Extraversion, Agreeableness, Neuroticism. |
| `operantSeeds` | Action-id → strength (0..1). Training history for `skinner-operant`. Required on profession and clan rows. **Omit** on temperament (no job repertoire). Strengths are a game proxy, not laboratory response rates. |
| `enabledProviderIds` | PE provider ids this seed expects turned on |
| `citations` | **Per knob**: bibliographic source **or** `project convention` |

## Optional

| Field | What it is |
| --- | --- |
| `cognitiveStage` | PE `CognitiveStage` (`Sensorimotor`, `Preoperational`, `ConcreteOperational`, `FormalOperational`). Host-set. Omit on generic adult **jobs**. **Clans** may set it: PE gates `hypothetical` on at `FormalOperational`. That is structure, not IQ. |
| `identityStage` | PE `PsychosocialStage` (Erikson eight ages). Host-set; omit unless the job is about a life-stage role. |
| `jitter` | Named vs ambient vs crowd notes (trait delta, which layers to keep) |

## Trait bands (project convention)

Use a band plus a midpoint so `PresetBuilder` can jitter inside the band when a host passes `BuildOptions.Seed`.

| Band | Range | Typical midpoint |
| --- | --- | --- |
| low | 0.20–0.40 | 0.30 |
| mid | 0.40–0.60 | 0.50 |
| high | 0.65–0.85 | 0.75 |

These ranges are **project convention**. Occupational Big Five **direction** (which trait is high vs low for a job) may cite job-performance literature. Exact floats are not published scoring keys.

## Default profession providers

Generic adult jobs enable the ALMA stack plus operant training:

- `ocean`
- `ocean-to-pad`
- `pad-mood`
- `occ`
- `occ-to-pad`
- `skinner-operant`

A job or clan may add other **already-shipped** PE ids (for example `peterson-maps` when exploration/meaning is part of the work, or `piaget-equilibration` when a clan sets `cognitiveStage`). Do not list ids PE does not have.

## Default temperament providers

Temperament rows enable personality, mood, and optional appraisal — not job training:

- `ocean`
- `ocean-to-pad`
- `pad-mood`
- `occ`
- `occ-to-pad`

PAD is not a constructor arg. The mood baseline is whatever `ocean-to-pad` computes from the OCEAN midpoints (Gebhard ALMA coefficients; Mehrabian 1996 for PAD as temperament *language*). Skip `skinner-operant`, Piaget, Erikson, and Peterson unless a later PE temperament provider ships and this catalog consumes it.

Clan files must use the three-section template in [`clans/README.md`](clans/README.md). Temperament files must use [`temperament/README.md`](temperament/README.md).

PE’s `OperantLearningProvider` currently seeds listed action ids at its default operant level. `PresetBuilder` applies catalog `operantSeeds` strengths through `AffectPersist` import.

## File shape

Each entry is one markdown file with three sections:

1. **Fiction** — what a designer or player sees
2. **Knobs** — tables for traits, operants, providers, optional stages, jitter
3. **Citations** — one row per knob (or per trait), never one bibliography for the whole job

## Out of scope on this schema

- Embedded JSON loader
- RIASEC, Sternberg, Bandura, HEXACO
- IQ / g channels
