# apothecary

Generic measure-and-compound shop worker. Not a licensed pharmacist and not a real-world ethnic group.

## Fiction

Keeps jars, scales, and a book of recipes. People bring a complaint; the shop returns a measured dose or a refusal. The work is mixing what is written, not inventing medicine.

## Knobs

| Field | Value |
| --- | --- |
| `id` | `apothecary` |
| `category` | `profession` |
| `cognitiveStage` | omitted (generic adult job; do not rank intelligence) |
| `identityStage` | omitted |

### traits

OCEAN 0..1. Constructor order: Openness, Conscientiousness, Extraversion, Agreeableness, Neuroticism.

| Trait | Band | Midpoint | Role in this job |
| --- | --- | --- | --- |
| Openness | mid | 0.52 | New complaint; old recipe |
| Conscientiousness | high | 0.80 | A wrong measure is the shop failing |
| Extraversion | mid | 0.48 | Counter talk; the scale comes first |
| Agreeableness | mid | 0.58 | Help without promising a cure |
| Neuroticism | mid | 0.45 | Care about a spoiled jar |

### operantSeeds

| Action id | Strength | What the host might mean |
| --- | --- | --- |
| `measure` | 0.78 | Weigh and count |
| `compound` | 0.72 | Mix what is written |
| `refuse` | 0.50 | Say no to a bad ask |
| `label` | 0.55 | Mark the dose |
| `idle` | 0.20 | Wait between customers |

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
| Crowd | Shared shop seed, not one engine per mixer |

Jitter magnitudes are **project convention**.

## Citations

| Knob | Source |
| --- | --- |
| Trait scale (OCEAN 0..1) | McCrae & Costa (2008). |
| Sampling this job | ILO (2012), *ISCO-08* major group 3 (Technicians and associate professionals). Generic compounder, not a license. Skill level not imported. |
| High Conscientiousness | Barrick & Mount (1991); Hurtz & Donovan (2000). |
| Other trait midpoints | **Project convention.** |
| `operantSeeds` | Skinner (1953). Strengths and action ids: **project convention.** |
| ALMA + `skinner-operant` | Gebhard (2005); Skinner (1953); Ferster & Skinner (1957). |
| Jitter / omitting stages | **Project convention.** |
