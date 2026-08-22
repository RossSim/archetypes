# porter

Generic load-carrier. Not a real-world ethnic group and not a skill-level rank.

## Fiction

Moves sacks, crates, and people from one place to another. The work is lifting, walking, and not dropping the load. Neighbors do not treat this as a lesser mind; they treat it as a body that is paid to carry.

## Knobs

| Field | Value |
| --- | --- |
| `id` | `porter` |
| `category` | `profession` |
| `cognitiveStage` | omitted (generic adult job; do not rank intelligence) |
| `identityStage` | omitted |

### traits

OCEAN 0..1. Constructor order: Openness, Conscientiousness, Extraversion, Agreeableness, Neuroticism.

| Trait | Band | Midpoint | Role in this job |
| --- | --- | --- | --- |
| Openness | low | 0.38 | The route is known |
| Conscientiousness | high | 0.70 | A dropped crate is the job failing |
| Extraversion | mid | 0.48 | Street talk; the load comes first |
| Agreeableness | mid | 0.52 | Take the fare without a quarrel |
| Neuroticism | mid | 0.40 | Care about a wet step |

### operantSeeds

| Action id | Strength | What the host might mean |
| --- | --- | --- |
| `lift` | 0.76 | Pick up the load |
| `carry` | 0.78 | Walk it there |
| `set-down` | 0.70 | Put it where they asked |
| `take-fare` | 0.45 | Get paid |
| `idle` | 0.28 | Wait for the next load |

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
| Crowd | Shared dock seed, not one engine per porter |

Jitter magnitudes are **project convention**.

## Citations

| Knob | Source |
| --- | --- |
| Trait scale (OCEAN 0..1) | McCrae & Costa (2008). |
| Sampling this job | ILO (2012), *ISCO-08* major group 9 (Elementary occupations). **Do not encode as lower intelligence.** Skill-level 1 is not imported. |
| High Conscientiousness | Barrick & Mount (1991); Hurtz & Donovan (2000). Direction for trained work, not a caste. |
| Other trait midpoints | **Project convention.** |
| `operantSeeds` | Skinner (1953). Strengths and action ids: **project convention.** |
| ALMA + `skinner-operant` | Gebhard (2005); Skinner (1953); Ferster & Skinner (1957). |
| Jitter / omitting stages | **Project convention.** |
