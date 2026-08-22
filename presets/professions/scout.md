# wilderness-scout

Generic reconnaissance / wilderness lookout. Not a named IP and not a real-world ethnic group.

## Fiction

Walks the treeline and the ridge. Watches roads, camps, and weather. The job is to see first, report cleanly, and not pick a fight that the watch did not ask for. Curiosity is useful; so is coming back.

## Knobs

| Field | Value |
| --- | --- |
| `id` | `wilderness-scout` |
| `category` | `profession` |
| `cognitiveStage` | omitted (generic adult job; do not rank intelligence) |
| `identityStage` | omitted |

### traits

OCEAN 0..1. Constructor order: Openness, Conscientiousness, Extraversion, Agreeableness, Neuroticism.

| Trait | Band | Midpoint | Role in this job |
| --- | --- | --- | --- |
| Openness | high | 0.72 | Training proficiency and willingness to enter unfamiliar ground |
| Conscientiousness | mid | 0.62 | Patrol discipline without making the job a ledger |
| Extraversion | mid | 0.48 | Can report to a hall; does not need a crowd |
| Agreeableness | mid | 0.42 | Independent watch; not hostile by default |
| Neuroticism | mid | 0.48 | Alert, not a panic score |

### operantSeeds

Action ids the host may emit as `skinner.emit`. Strengths are training history, **project convention**.

| Action id | Strength | What the host might mean |
| --- | --- | --- |
| `scout` | 0.75 | Move and observe; primary craft |
| `track` | 0.70 | Follow sign |
| `explore` | 0.65 | Enter unknown ground (pairs with meaning/explore if Peterson is on) |
| `forage` | 0.55 | Live off the route |
| `report` | 0.50 | Bring news back |

### enabledProviderIds

- `ocean`
- `ocean-to-pad`
- `pad-mood`
- `occ`
- `occ-to-pad`
- `skinner-operant`
- `peterson-metatraits`
- `peterson-maps`

Peterson is on because this job’s work includes exploration vs order (maps-of-meaning channels). Mix coefficients stay PE’s; this catalog only names the providers.

### jitter

| Tier | Note |
| --- | --- |
| Named | Full composition; trait jitter ±0.05 inside the band |
| Ambient | Personality + mood only; trait jitter ±0.12; skip OCC and Peterson if the host is counting cost |
| Crowd | Shared watch seed (one ridge), not one engine per walker |

Jitter magnitudes are **project convention**.

## Citations

| Knob | Source |
| --- | --- |
| Trait scale (OCEAN 0..1) | McCrae, R. R., & Costa, P. T., Jr. (2008). The five-factor theory of personality. In O. P. John, R. W. Robins, & L. A. Pervin (Eds.), *Handbook of personality: Theory and research* (3rd ed., pp. 159–181). Guilford Press. **Not** NEO items. |
| High Openness (training / novelty) | Barrick, M. R., & Mount, M. K. (1991). The Big Five personality dimensions and job performance: A meta-analysis. *Personnel Psychology, 44*(1), 1–26. Openness related to **training proficiency**, not a scout IQ. Hurtz, G. M., & Donovan, J. J. (2000). Personality and job performance: The Big Five revisited. *Journal of Applied Psychology, 85*(6), 869–879. |
| Mid Conscientiousness / Extraversion / Agreeableness / Neuroticism | **Project convention.** Barrick & Mount treat Conscientiousness as a general performance correlate; this job keeps C mid-high rather than maxed so the watch can still deviate from protocol. Exact floats are game-feel. |
| Trait bands (low/mid/high ranges) | **Project convention.** |
| `operantSeeds` strengths | Skinner, B. F. (1953). *Science and Human Behavior.* 0..1 strengths: **project convention.** Action ids: **project convention.** |
| ALMA providers | Gebhard, P. (2005). ALMA. McCrae & Costa (2008); Mehrabian & Russell (1974); Ortony, Clore, & Collins (1988). Enabling the default stack: **project convention.** |
| `skinner-operant` | Skinner (1953); Ferster & Skinner (1957). |
| `peterson-metatraits` / `peterson-maps` | DeYoung, C. G., Peterson, J. B., & Higgins, D. M. (2002). Higher-order factors of the Big Five predict conformity. *Personality and Individual Differences, 33*(4), 533–552. Peterson, J. B. (1999). *Maps of Meaning.* Turning them on for a scout: **project convention** (not a published “scout = explore” formula). |
| Jitter magnitudes | **Project convention.** |
| Omitting stages | **Project convention.** |
