# Clan catalog

Fantasy clan seeds. Same row schema as professions ([`../schema.md`](../schema.md)). Every public clan file **must** use three sections — Fiction / Knobs / Citations — not one bibliography for the whole archetype.

These are **lore names**, not real-world peoples.

## Template

Copy this shape. Do not skip a section.

```markdown
# {id}

One-line reminder: fantasy clan, not a real-world ethnic group.

## Fiction

Player-facing lore only. Do not cite papers here.

## Knobs

| Field | Value |
| --- | --- |
| `id` | kebab-case |
| `category` | `clan` |
| `cognitiveStage` | PE stage (clans may set this; it is structure, not IQ) |
| `identityStage` | omit unless the clan is about a life-stage role |

### traits
(band + midpoint for O, C, E, A, N)

### operantSeeds
(action-id → strength)

### enabledProviderIds
(ALMA stack plus `piaget-equilibration` when stage is set; other shipped PE ids if needed)

### jitter
(named / ambient / crowd)

## Citations

One row per knob. Never one list that “covers the clan.”
```

## Index

| Id | Fiction (one line) |
| --- | --- |
| `philobrain-scholar` | Clan that prizes hypotheticals and scholarship |
| `trog-warrior` | Clan trained for the fight; stays with what already worked |

## Clan guardrails

Profession guardrails still apply. In addition:

- Public catalog: **fantasy ids only**
- No real-world race, ethnicity, or national cognitive rank tables
- Cognitive difference = **structure** (Piaget stage / flags) + **training** (operants) + **trait bands** — never “less intelligent people”
- If a clan is worse at hypothetical clues, that is `cognitiveStage` below `FormalOperational` (PE’s `hypothetical` flag is stage-gated). It is not a g score
- Fiction must not imply that a paper measured this clan
- Three-section split required on every clan file
