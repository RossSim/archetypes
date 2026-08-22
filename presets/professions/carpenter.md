# carpenter

Generic join-and-repair woodworker. Second craft seed beside `guild-smith`. Not a named IP and not a real-world ethnic group.

## Fiction

Keeps joints, roofs, and wagon beds. The work is measuring twice, cutting once, and putting the piece where it will hold. Neighbors come when a door hangs or a beam is cracked.

## Knobs

| Field | Value |
| --- | --- |
| `id` | `carpenter` |
| `category` | `profession` |
| `cognitiveStage` | omitted (generic adult job; do not rank intelligence) |
| `identityStage` | omitted |

### traits

OCEAN 0..1. Constructor order: Openness, Conscientiousness, Extraversion, Agreeableness, Neuroticism.

| Trait | Band | Midpoint | Role in this job |
| --- | --- | --- | --- |
| Openness | mid | 0.50 | A new joint; old tools |
| Conscientiousness | high | 0.78 | A bad joint fails later |
| Extraversion | mid | 0.42 | Shop talk; the bench comes first |
| Agreeableness | mid | 0.52 | Take the commission without a quarrel |
| Neuroticism | mid | 0.40 | Care about a warped board |

### operantSeeds

| Action id | Strength | What the host might mean |
| --- | --- | --- |
| `measure` | 0.72 | Mark the piece |
| `join` | 0.76 | Fit it |
| `repair` | 0.70 | Fix what hangs or splits |
| `plane` | 0.55 | Dress the surface |
| `idle` | 0.20 | Wait between jobs |

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
| Crowd | Shared bench seed, not one engine per joiner |

Jitter magnitudes are **project convention**.

## Citations

| Knob | Source |
| --- | --- |
| Trait scale (OCEAN 0..1) | McCrae & Costa (2008). |
| Sampling this job | ILO (2012), *ISCO-08* major group 7 (Craft and related trades workers). Second craft beside `guild-smith`. |
| High Conscientiousness | Barrick & Mount (1991); Hurtz & Donovan (2000). |
| Other trait midpoints | **Project convention.** |
| `operantSeeds` | Skinner (1953). Strengths and action ids: **project convention.** |
| ALMA + `skinner-operant` | Gebhard (2005); Skinner (1953); Ferster & Skinner (1957). |
| Jitter / omitting stages | **Project convention.** |
