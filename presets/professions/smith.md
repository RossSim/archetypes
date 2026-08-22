# village-smith

Generic village craft job. Not a named IP and not a real-world ethnic group.

## Fiction

Keeps the forge lit. Neighbors bring broken hinges, bent ploughshares, and horses that need shoeing. The work is hot, repetitive, and judged by whether the piece holds. Talk is short; the shop is the shop.

## Knobs

| Field | Value |
| --- | --- |
| `id` | `village-smith` |
| `category` | `profession` |
| `cognitiveStage` | omitted (generic adult job; do not rank intelligence) |
| `identityStage` | omitted |

### traits

OCEAN 0..1. Constructor order: Openness, Conscientiousness, Extraversion, Agreeableness, Neuroticism.

| Trait | Band | Midpoint | Role in this job |
| --- | --- | --- | --- |
| Openness | mid | 0.45 | Practical problem-solving at the anvil, not scholarly novelty |
| Conscientiousness | high | 0.78 | Reliability and persistence at skilled work |
| Extraversion | low | 0.35 | Workshop-first; customers are intermittent |
| Agreeableness | mid | 0.50 | Enough warmth to take a commission without being a courtier |
| Neuroticism | low | 0.32 | Composure around heat, noise, and spoiled work |

### operantSeeds

Action ids the host may emit as `skinner.emit`. Strengths are training history, **project convention**.

| Action id | Strength | What the host might mean |
| --- | --- | --- |
| `forge` | 0.75 | Shape metal; primary craft |
| `repair` | 0.70 | Restore a broken piece |
| `quench` | 0.55 | Finish heat-treat; trained but less frequent |
| `haggle` | 0.35 | Price a job; present, not the core repertoire |
| `idle` | 0.20 | Wait for work; near default operant level |

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
| Crowd | Shared district seed (one smithy), not one engine per walker |

Jitter magnitudes are **project convention**.

## Citations

| Knob | Source |
| --- | --- |
| Trait scale (OCEAN 0..1) | McCrae, R. R., & Costa, P. T., Jr. (2008). The five-factor theory of personality. In O. P. John, R. W. Robins, & L. A. Pervin (Eds.), *Handbook of personality: Theory and research* (3rd ed., pp. 159–181). Guilford Press. **Not** NEO items. |
| High Conscientiousness for this job | Barrick, M. R., & Mount, M. K. (1991). The Big Five personality dimensions and job performance: A meta-analysis. *Personnel Psychology, 44*(1), 1–26. Conscientiousness predicts performance **across** occupations; this catalog uses that **direction**, not a selection cutoff. Hurtz, G. M., & Donovan, J. J. (2000). Personality and job performance: The Big Five revisited. *Journal of Applied Psychology, 85*(6), 869–879. |
| Openness / Extraversion / Agreeableness / Neuroticism midpoints | **Project convention.** Barrick & Mount discuss Extraversion more for social jobs and Openness more for training proficiency; exact floats here are game-feel, not published smith norms. |
| Trait bands (low/mid/high ranges) | **Project convention.** |
| `operantSeeds` strengths | Skinner, B. F. (1953). *Science and Human Behavior.* Repertoire shaped by contingencies. 0..1 strengths: **project convention** (same as Personality Engine). Action ids `forge` / `repair` / `quench` / `haggle` / `idle`: **project convention.** |
| ALMA providers (`ocean`, `ocean-to-pad`, `pad-mood`, `occ`, `occ-to-pad`) | Gebhard, P. (2005). ALMA: A layered model of affect. In *Proceedings of AAMAS '05*. McCrae & Costa (2008); Mehrabian & Russell (1974); Ortony, Clore, & Collins (1988). Wiring this job to the default stack: **project convention.** |
| `skinner-operant` | Skinner (1953); Ferster, C. B., & Skinner, B. F. (1957). *Schedules of Reinforcement.* |
| Jitter magnitudes | **Project convention.** |
| Omitting `cognitiveStage` / `identityStage` | **Project convention.** Adult generic jobs do not encode Piaget or Erikson stages so craft is not mistaken for a cognitive rank. |
