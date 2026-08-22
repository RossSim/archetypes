# water-miller

Generic mill-wheel keeper. Not industrial plant work and not a real-world ethnic group.

## Fiction

Keeps the wheel turning and the stones dressed. Grain comes in; meal goes out. The work is listening to the mill and stopping it before something breaks.

## Knobs

| Field | Value |
| --- | --- |
| `id` | `water-miller` |
| `category` | `profession` |
| `cognitiveStage` | omitted (generic adult job; do not rank intelligence) |
| `identityStage` | omitted |

### traits

OCEAN 0..1. Constructor order: Openness, Conscientiousness, Extraversion, Agreeableness, Neuroticism.

| Trait | Band | Midpoint | Role in this job |
| --- | --- | --- | --- |
| Openness | mid | 0.44 | The mill is a known machine |
| Conscientiousness | high | 0.80 | A jammed stone ruins grain and gear |
| Extraversion | low | 0.36 | The mill is loud; customers are intermittent |
| Agreeableness | mid | 0.50 | Take a sack without a quarrel |
| Neuroticism | mid | 0.42 | Hear a wrong sound |

### operantSeeds

| Action id | Strength | What the host might mean |
| --- | --- | --- |
| `tend-mill` | 0.76 | Keep the wheel and stones right |
| `grind` | 0.70 | Run a sack through |
| `stop-mill` | 0.62 | Shut it down |
| `take-toll` | 0.40 | Keep a share |
| `idle` | 0.22 | Wait for grain |

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
| Crowd | Shared mill seed, not one engine per hand |

Jitter magnitudes are **project convention**.

## Citations

| Knob | Source |
| --- | --- |
| Trait scale (OCEAN 0..1) | McCrae & Costa (2008). |
| Sampling this job | ILO (2012), *ISCO-08* major group 8 (Plant and machine operators). Generic mill, not a factory line. Skill level not imported. |
| High Conscientiousness | Barrick & Mount (1991); Hurtz & Donovan (2000). |
| Other trait midpoints | **Project convention.** |
| `operantSeeds` | Skinner (1953). Strengths and action ids: **project convention.** |
| ALMA + `skinner-operant` | Gebhard (2005); Skinner (1953); Ferster & Skinner (1957). |
| Jitter / omitting stages | **Project convention.** |
