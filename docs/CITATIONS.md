# Citations

Every catalog knob names a source. This file is the **shared registry**. Per-preset citation tables stay in the markdown rows under [`presets/`](../presets/README.md). Exact floats, action ids, and which providers a seed enables are **project convention** unless a row says otherwise.

Personality Engine’s provider bibliography: [personality-engine citations](https://github.com/RossSim/personality-engine/blob/main/docs/CITATIONS.md).

Cited authors have not endorsed this catalog. See [Disclaimer](../DISCLAIMER.md).

## Shared knobs

| Knob | What it is | Source |
| --- | --- | --- |
| Trait scale (OCEAN 0..1) | Host-supplied Big Five domains, not inventory items | McCrae, R. R., & Costa, P. T., Jr. (2008). The five-factor theory of personality. In O. P. John, R. W. Robins, & L. A. Pervin (Eds.), *Handbook of personality: Theory and research* (3rd ed., pp. 159–181). Guilford Press. **Not** NEO-PI-R / NEO-FFI items. |
| Trait bands (low / mid / high) | Inclusive ranges so jitter stays inside an authored band | **Project convention.** low 0.20–0.40, mid 0.40–0.60, high 0.65–0.85. |
| Occupational **direction** (which trait is high vs low for a job) | Conscientiousness across jobs; Extraversion more for social work; Openness more for training proficiency | Barrick, M. R., & Mount, M. K. (1991). The Big Five personality dimensions and job performance: A meta-analysis. *Personnel Psychology, 44*(1), 1–26. Hurtz, G. M., & Donovan, J. J. (2000). Personality and job performance: The Big Five revisited. *Journal of Applied Psychology, 85*(6), 869–879. Exact midpoints: **project convention.** |
| `operantSeeds` | Action-id → 0..1 training history for `skinner-operant` | Skinner, B. F. (1953). *Science and Human Behavior.* Ferster, C. B., & Skinner, B. F. (1957). *Schedules of Reinforcement.* Strengths and action ids: **project convention.** |
| ALMA stack (`ocean`, `ocean-to-pad`, `pad-mood`, `occ`, `occ-to-pad`) | Personality, PAD mood baseline, OCC feelings | Gebhard, P. (2005). ALMA: A layered model of affect. In *Proceedings of AAMAS '05* (pp. 29–36). ACM. https://doi.org/10.1145/1082473.1082478 McCrae & Costa (2008); Mehrabian & Russell (1974); Ortony, Clore, & Collins (1988). Enabling the stack on a seed: **project convention.** |
| PAD baseline | Personality → mood; not a separate temperament constructor | Mehrabian, A., & Russell, J. A. (1974). *An Approach to Environmental Psychology.* MIT Press. Mehrabian, A. (1996). Pleasure-arousal-dominance: A general framework for describing and measuring individual differences in temperament. *Current Psychology, 14*(4), 261–292. Coefficients live in PE `ocean-to-pad` (Gebhard 2005). |
| Named / ambient / crowd jitter | Trait delta and which layers to keep | **Project convention.** Named ±0.05, ambient/crowd ±0.12, inside the band. Personality Engine has no jitter API. |
| Omitting `cognitiveStage` / `identityStage` on adult jobs and temperament | Climate and craft are not developmental ranks | **Project convention.** |

## Clan knobs

| Knob | What it is | Source |
| --- | --- | --- |
| `cognitiveStage` | PE Piaget period; `hypothetical` on at `FormalOperational` | Piaget, J. (1950). *The Psychology of Intelligence.* Inhelder, B., & Piaget, J. (1958). *The Growth of Logical Thinking from Childhood to Adolescence.* Piaget, J. (1985). *The Equilibration of Cognitive Structures.* Host-set stage; choosing a stage for a **fantasy clan**: **project convention.** Structure, not IQ. |
| `peterson-metatraits` / `peterson-maps` | Stability/plasticity and explore vs order | DeYoung, C. G., Peterson, J. B., & Higgins, D. M. (2002). Higher-order factors of the Big Five predict conformity. *Personality and Individual Differences, 33*(4), 533–552. Peterson, J. B. (1999). *Maps of Meaning.* Enabling them on a seed: **project convention.** |

## Temperament knobs

| Knob | What it is | Source |
| --- | --- | --- |
| Easy / difficult / slow-to-warm-up | NYLS constellations mapped onto OCEAN bands | Thomas, A., Chess, S., & Birch, H. G. (1968). *Temperament and Behavior Disorders in Children.* New York University Press. Thomas, A., & Chess, S. (1977). *Temperament and Development.* Brunner/Mazel. Thomas, A., & Chess, S. (1981). *The Dynamics of Psychological Development.* Brunner/Mazel. Mapping onto Extraversion, Agreeableness, Neuroticism, and Conscientiousness: **project convention.** Not MBTI, not NYLS scoring keys, not an infant diagnosis. |
| Unmapped NYLS dimensions (intensity, threshold, distractibility) | Not PE knobs | Host OCC magnitudes and pacing. **Project convention** to omit them. |

## Not in this catalog

- IQ, g, or WAIS-style composites
- MBTI or four-letter types
- Real-world race, ethnicity, or national rank tables
- Holland RIASEC, Sternberg, Bandura, HEXACO (wait for those providers in personality-engine)
- A temperament `IAffectProvider` (PAD comes from `ocean-to-pad`)
