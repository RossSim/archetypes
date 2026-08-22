# herder

Generic flock-and-pasture keeper. Not a real-world ethnic group.

## Fiction

Walks with sheep or goats (or the local equivalent) between pasture and fold. The work is counting, moving, and knowing which animal is missing. It is not the same as ploughing a field.

## Knobs

| Field | Value |
| --- | --- |
| `id` | `herder` |
| `category` | `profession` |
| `cognitiveStage` | omitted (generic adult job; do not rank intelligence) |
| `identityStage` | omitted |

### traits

OCEAN 0..1. Constructor order: Openness, Conscientiousness, Extraversion, Agreeableness, Neuroticism.

| Trait | Band | Midpoint | Role in this job |
| --- | --- | --- | --- |
| Openness | mid | 0.48 | New pasture; old routes |
| Conscientiousness | high | 0.70 | A lost head of stock is the job failing |
| Extraversion | mid | 0.45 | Alone with the flock; still talks at the fold |
| Agreeableness | mid | 0.50 | Dogs and neighbors |
| Neuroticism | mid | 0.48 | Alert to predators; not a panic score |

### operantSeeds

| Action id | Strength | What the host might mean |
| --- | --- | --- |
| `move-flock` | 0.74 | Take them to pasture |
| `count` | 0.70 | Know who is missing |
| `fold` | 0.65 | Bring them in |
| `call-dog` | 0.55 | Work the animal helper |
| `idle` | 0.25 | Watch them graze |

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
| Crowd | Shared fold seed, not one engine per herder |

Jitter magnitudes are **project convention**.

## Citations

| Knob | Source |
| --- | --- |
| Trait scale (OCEAN 0..1) | McCrae & Costa (2008). |
| Sampling this job | ILO (2012), *ISCO-08* major group 6 (second agricultural seed beside `field-farmer`). |
| High Conscientiousness | Barrick & Mount (1991); Hurtz & Donovan (2000). |
| Other trait midpoints | **Project convention.** |
| `operantSeeds` | Skinner (1953). Strengths and action ids: **project convention.** |
| ALMA + `skinner-operant` | Gebhard (2005); Skinner (1953); Ferster & Skinner (1957). |
| Jitter / omitting stages | **Project convention.** |
