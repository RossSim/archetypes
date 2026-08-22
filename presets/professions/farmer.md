# field-farmer

Generic field-and-store grower. Not a real-world ethnic group and not a national agricultural rank table.

## Fiction

Keeps fields, seasons, and the barn. The work is the same tasks in the same order until harvest, then again. Neighbors judge whether the stores last winter.

## Knobs

| Field | Value |
| --- | --- |
| `id` | `field-farmer` |
| `category` | `profession` |
| `cognitiveStage` | omitted (generic adult job; do not rank intelligence) |
| `identityStage` | omitted |

### traits

OCEAN 0..1. Constructor order: Openness, Conscientiousness, Extraversion, Agreeableness, Neuroticism.

| Trait | Band | Midpoint | Role in this job |
| --- | --- | --- | --- |
| Openness | mid | 0.42 | New weather; old methods |
| Conscientiousness | high | 0.78 | Seasons punish a skipped task |
| Extraversion | low | 0.38 | Fields before the square |
| Agreeableness | mid | 0.52 | Neighbor help at harvest |
| Neuroticism | mid | 0.45 | Care about blight and rain |

### operantSeeds

| Action id | Strength | What the host might mean |
| --- | --- | --- |
| `sow` | 0.70 | Put seed in |
| `tend` | 0.74 | Weed, water, walk the rows |
| `harvest` | 0.72 | Take the crop |
| `store` | 0.60 | Barn and bin |
| `idle` | 0.22 | Wait on weather |

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
| Crowd | Shared farm seed, not one engine per hand |

Jitter magnitudes are **project convention**.

## Citations

| Knob | Source |
| --- | --- |
| Trait scale (OCEAN 0..1) | McCrae & Costa (2008). |
| Sampling this job | ILO (2012), *ISCO-08* major group 6 (Skilled agricultural, forestry and fishery workers). Not a skill-level rank. |
| High Conscientiousness | Barrick & Mount (1991); Hurtz & Donovan (2000). Direction for trained work. |
| Other trait midpoints | **Project convention.** |
| `operantSeeds` | Skinner (1953). Strengths and action ids: **project convention.** |
| ALMA + `skinner-operant` | Gebhard (2005); Skinner (1953); Ferster & Skinner (1957). |
| Jitter / omitting stages | **Project convention.** |
