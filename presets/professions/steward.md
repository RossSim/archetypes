# guild-steward

Generic hall-manager job. Not a named IP and not a real-world ethnic group.

## Fiction

Keeps the roster, the purse, and the door of a guild hall or manor. People come with complaints, tallies, and requests for leave. The work is deciding whose turn it is and whether the stores will last the week.

## Knobs

| Field | Value |
| --- | --- |
| `id` | `guild-steward` |
| `category` | `profession` |
| `cognitiveStage` | omitted (generic adult job; do not rank intelligence) |
| `identityStage` | omitted |

### traits

OCEAN 0..1. Constructor order: Openness, Conscientiousness, Extraversion, Agreeableness, Neuroticism.

| Trait | Band | Midpoint | Role in this job |
| --- | --- | --- | --- |
| Openness | mid | 0.48 | Enough flexibility to re-plan stores; not a scholar |
| Conscientiousness | high | 0.76 | Rosters and purses fail if this slips |
| Extraversion | high | 0.68 | Managing people is social interaction |
| Agreeableness | mid | 0.52 | Firm enough to say no |
| Neuroticism | mid | 0.42 | Care about shortfall; not a panic score |

### operantSeeds

| Action id | Strength | What the host might mean |
| --- | --- | --- |
| `assign` | 0.72 | Put a person on a task |
| `tally` | 0.70 | Count stores and dues |
| `hear-petition` | 0.60 | Listen and decide |
| `refuse` | 0.45 | Turn a request down |
| `idle` | 0.20 | Wait between petitioners |

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
| Crowd | Shared hall seed, not one engine per steward |

Jitter magnitudes are **project convention**.

## Citations

| Knob | Source |
| --- | --- |
| Trait scale (OCEAN 0..1) | McCrae, R. R., & Costa, P. T., Jr. (2008). The five-factor theory of personality. In O. P. John, R. W. Robins, & L. A. Pervin (Eds.), *Handbook of personality* (3rd ed.). Guilford Press. |
| Sampling this job | International Labour Office. (2012). *ISCO-08* major group 1 (Managers). Sampling frame only; not a skill-level rank. |
| High Extraversion | Barrick, M. R., & Mount, M. K. (1991). The Big Five personality dimensions and job performance: A meta-analysis. *Personnel Psychology, 44*(1), 1–26. Extraversion predicted performance for **managers**. Exact midpoint: **project convention.** |
| High Conscientiousness | Barrick & Mount (1991); Hurtz & Donovan (2000). Direction across occupations; not a cutoff. |
| Other trait midpoints | **Project convention.** |
| `operantSeeds` | Skinner, B. F. (1953). *Science and Human Behavior.* Strengths and action ids: **project convention.** |
| ALMA + `skinner-operant` | Gebhard (2005); Skinner (1953); Ferster & Skinner (1957). |
| Jitter / omitting stages | **Project convention.** |
