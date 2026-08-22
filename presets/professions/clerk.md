# records-clerk

Generic record-keeper / administrator. Not a named IP and not a real-world ethnic group.

## Fiction

Sits with the ledger, the seal, and the queue. People want copies, tallies, and proof that something was said last season. The work is paper, order, and remembering where a thing was filed. Courtesy matters; so does not losing the page.

## Knobs

| Field | Value |
| --- | --- |
| `id` | `records-clerk` |
| `category` | `profession` |
| `cognitiveStage` | omitted (generic adult job; do not rank intelligence) |
| `identityStage` | omitted |

### traits

OCEAN 0..1. Constructor order: Openness, Conscientiousness, Extraversion, Agreeableness, Neuroticism.

| Trait | Band | Midpoint | Role in this job |
| --- | --- | --- | --- |
| Openness | mid | 0.42 | Follows existing forms; novel filing systems are rare |
| Conscientiousness | high | 0.80 | Order, completeness, and not losing the record |
| Extraversion | low | 0.40 | Counter work exists; the desk is still the job |
| Agreeableness | mid | 0.55 | Enough patience for a queue without becoming a pushover |
| Neuroticism | mid | 0.45 | Care about error; not a clinical anxiety score |

### operantSeeds

Action ids the host may emit as `skinner.emit`. Strengths are training history, **project convention**.

| Action id | Strength | What the host might mean |
| --- | --- | --- |
| `file` | 0.75 | Put a record in its place; primary craft |
| `copy` | 0.70 | Duplicate a page or seal |
| `tally` | 0.65 | Count, sum, check |
| `recall-record` | 0.60 | Find what was written |
| `repeat-protocol` | 0.55 | Run the same intake steps again |

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
| Crowd | Shared hall seed (one scriptorium), not one engine per walker |

Jitter magnitudes are **project convention**.

## Citations

| Knob | Source |
| --- | --- |
| Trait scale (OCEAN 0..1) | McCrae, R. R., & Costa, P. T., Jr. (2008). The five-factor theory of personality. In O. P. John, R. W. Robins, & L. A. Pervin (Eds.), *Handbook of personality: Theory and research* (3rd ed., pp. 159–181). Guilford Press. **Not** NEO items. |
| High Conscientiousness for this job | Barrick, M. R., & Mount, M. K. (1991). The Big Five personality dimensions and job performance: A meta-analysis. *Personnel Psychology, 44*(1), 1–26. Conscientiousness as a general performance correlate; used here as **direction** for orderly record work, not a hiring test. Hurtz, G. M., & Donovan, J. J. (2000). Personality and job performance: The Big Five revisited. *Journal of Applied Psychology, 85*(6), 869–879. |
| Mid/low Openness, Extraversion, Agreeableness, Neuroticism | **Project convention.** Extraversion in Barrick & Mount is more relevant to social occupations; a clerk has a counter but is not a salesperson. Exact floats are game-feel. |
| Trait bands (low/mid/high ranges) | **Project convention.** |
| `operantSeeds` strengths | Skinner, B. F. (1953). *Science and Human Behavior.* 0..1 strengths: **project convention.** Action ids `file` / `copy` / `tally` / `recall-record` / `repeat-protocol`: **project convention.** |
| ALMA providers | Gebhard, P. (2005). ALMA. McCrae & Costa (2008); Mehrabian & Russell (1974); Ortony, Clore, & Collins (1988). Enabling the default stack: **project convention.** |
| `skinner-operant` | Skinner (1953); Ferster & Skinner (1957). |
| Jitter magnitudes | **Project convention.** |
| Omitting stages | **Project convention.** Adult generic jobs do not encode Piaget or Erikson stages so paperwork is not mistaken for a cognitive rank. |
