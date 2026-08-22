# school-teacher

Generic letters-and-sums teacher. Not a licensed educator, not a test publisher, and not a real-world ethnic group.

## Fiction

Keeps a room of children or apprentices long enough to copy a row of letters and a column of sums. The work is repeating the same lesson until someone has it, then starting again with the next.

## Knobs

| Field | Value |
| --- | --- |
| `id` | `school-teacher` |
| `category` | `profession` |
| `cognitiveStage` | omitted (generic adult job; do not rank intelligence) |
| `identityStage` | omitted |

### traits

OCEAN 0..1. Constructor order: Openness, Conscientiousness, Extraversion, Agreeableness, Neuroticism.

| Trait | Band | Midpoint | Role in this job |
| --- | --- | --- | --- |
| Openness | mid | 0.55 | Enough novelty for a new example; the primer is still the primer |
| Conscientiousness | high | 0.74 | The room fails if the lesson does not run |
| Extraversion | high | 0.66 | Holding a room is social interaction |
| Agreeableness | high | 0.68 | Patience with a slow copy; not a pushover |
| Neuroticism | mid | 0.45 | Care about a lost afternoon |

### operantSeeds

| Action id | Strength | What the host might mean |
| --- | --- | --- |
| `drill` | 0.74 | Repeat the lesson |
| `correct` | 0.68 | Mark a copy |
| `keep-room` | 0.62 | Hold attention |
| `praise` | 0.50 | Reinforce a right copy |
| `idle` | 0.20 | Wait between classes |

### enabledProviderIds

- `ocean`
- `ocean-to-pad`
- `pad-mood`
- `occ`
- `occ-to-pad`
- `skinner-operant`

### jitter

| Tier | Note |
| --- | --- |
| Named | Full composition; trait jitter ±0.05 inside the band |
| Ambient | Personality + mood only; trait jitter ±0.12; skip OCC if the host is counting cost |
| Crowd | Shared schoolroom seed, not one engine per tutor |

Jitter magnitudes are **project convention**.

## Citations

| Knob | Source |
| --- | --- |
| Trait scale (OCEAN 0..1) | McCrae & Costa (2008). |
| Sampling this job | ILO (2012), *ISCO-08* major group 2 (Professionals). Barrick & Mount (1991) professionals group included teachers. Not a credential and not skill-level 4 as IQ. |
| High Extraversion | Barrick & Mount (1991) Extraversion for occupations with social interaction; holding a room is treated that way here. Exact midpoint: **project convention.** |
| High Conscientiousness | Barrick & Mount (1991); Hurtz & Donovan (2000). |
| High Agreeableness | **Project convention.** |
| `operantSeeds` | Skinner (1953). Strengths and action ids: **project convention.** |
| ALMA + `skinner-operant` | Gebhard (2005); Skinner (1953); Ferster & Skinner (1957). |
| Jitter / omitting stages | **Project convention.** |
