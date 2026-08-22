# innkeeper

Generic inn / common-room keeper. Not a named IP and not a real-world ethnic group.

## Fiction

Keeps beds, stew, and the noise of the common room. People want a place to sit, a bowl, and not to be robbed in the night. The work is hospitality and watching the door.

## Knobs

| Field | Value |
| --- | --- |
| `id` | `innkeeper` |
| `category` | `profession` |
| `cognitiveStage` | omitted (generic adult job; do not rank intelligence) |
| `identityStage` | omitted |

### traits

OCEAN 0..1. Constructor order: Openness, Conscientiousness, Extraversion, Agreeableness, Neuroticism.

| Trait | Band | Midpoint | Role in this job |
| --- | --- | --- | --- |
| Openness | mid | 0.48 | New faces; the stew is still the stew |
| Conscientiousness | mid | 0.62 | Beds made, tab kept |
| Extraversion | high | 0.72 | The common room is social |
| Agreeableness | high | 0.70 | Welcome; not a doormat when the tab is owed |
| Neuroticism | mid | 0.42 | Care about a fight in the room |

### operantSeeds

| Action id | Strength | What the host might mean |
| --- | --- | --- |
| `serve` | 0.74 | Bowl, ale, bed |
| `welcome` | 0.68 | Take someone in |
| `keep-tab` | 0.60 | Remember what is owed |
| `eject` | 0.42 | Put someone out |
| `idle` | 0.22 | Wait between guests |

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
| Crowd | Shared inn seed, not one engine per tapster |

Jitter magnitudes are **project convention**.

## Citations

| Knob | Source |
| --- | --- |
| Trait scale (OCEAN 0..1) | McCrae & Costa (2008). |
| Sampling this job | ILO (2012), *ISCO-08* major group 5 (Service and sales workers). |
| High Extraversion | Barrick & Mount (1991) Extraversion for social-interaction jobs. Exact midpoint: **project convention.** |
| High Agreeableness | **Project convention** (hospitality game-feel; not a published innkeeper norm). |
| Other trait midpoints | **Project convention.** |
| `operantSeeds` | Skinner (1953). Strengths and action ids: **project convention.** |
| ALMA + `skinner-operant` | Gebhard (2005); Skinner (1953); Ferster & Skinner (1957). |
| Jitter / omitting stages | **Project convention.** |
