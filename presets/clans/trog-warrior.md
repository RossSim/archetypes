# trog-warrior

Fantasy clan. Not a real-world ethnic group, not a national rank table, and not an IQ score.

## Fiction

Trog companies drill the same stand, the same shield wall, the same three answers to an ambush. They trust what has already worked on this ground. A riddle about a river that *might* run backward is not a fight; they want the ford that is there. They are not written as fools. They are written as people who stay with concrete tactics.

## Knobs

| Field | Value |
| --- | --- |
| `id` | `trog-warrior` |
| `category` | `clan` |
| `cognitiveStage` | `ConcreteOperational` (PE `hypothetical` flag off; `conservation` on) |
| `identityStage` | omitted (combat training is not an Erikson age) |

If a Trog NPC will not follow a hypothetical clue, that is this stage’s structural flag — not a g-factor and not “less intelligent people.” They still conserve, classify, and fight on what is in front of them.

### traits

OCEAN 0..1. Constructor order: Openness, Conscientiousness, Extraversion, Agreeableness, Neuroticism.

| Trait | Band | Midpoint | Role in this clan |
| --- | --- | --- | --- |
| Openness | low | 0.32 | Closed to novelty; not a proxy for intelligence |
| Conscientiousness | high | 0.74 | Drill, watch-standing, keep the line |
| Extraversion | mid | 0.55 | Company life; not a lone duelist by default |
| Agreeableness | mid | 0.40 | Loyalty to the unit; not court manners |
| Neuroticism | mid | 0.40 | Alert in a fight; not a panic score |

### operantSeeds

Action ids the host may emit as `skinner.emit`. Strengths are training history, **project convention**.

| Action id | Strength | What the host might mean |
| --- | --- | --- |
| `strike` | 0.75 | Commit to the trained blow |
| `guard` | 0.70 | Hold the line / shield |
| `repeat-protocol` | 0.68 | Run the same ambush answer again |
| `charge` | 0.50 | Close distance when the protocol says so |
| `idle` | 0.22 | Wait on watch |

### enabledProviderIds

- `ocean`
- `ocean-to-pad`
- `pad-mood`
- `occ`
- `occ-to-pad`
- `skinner-operant`
- `piaget-equilibration`

Piaget is on so the host can read stage-gated flags (`hypothetical` off). Peterson is **off** so this clan is not also scored as “chaos vs order”; rigidity here is Openness + `repeat-protocol` + concrete operations.

### jitter

| Tier | Note |
| --- | --- |
| Named | Full composition; trait jitter ±0.05 inside the band |
| Ambient | Personality + mood only; trait jitter ±0.12; keep Piaget stage so hypothetical flags stay consistent |
| Crowd | Shared company seed, not one engine per walker |

Jitter magnitudes are **project convention**.

## Citations

| Knob | Source |
| --- | --- |
| Trait scale (OCEAN 0..1) | McCrae, R. R., & Costa, P. T., Jr. (2008). The five-factor theory of personality. In O. P. John, R. W. Robins, & L. A. Pervin (Eds.), *Handbook of personality: Theory and research* (3rd ed., pp. 159–181). Guilford Press. **Not** NEO items. |
| Low Openness | McCrae & Costa (2008) on Openness as a domain of novelty. Exact midpoint: **project convention.** Low Openness is not a Piaget stage and not an IQ. |
| High Conscientiousness | Barrick, M. R., & Mount, M. K. (1991). The Big Five personality dimensions and job performance: A meta-analysis. *Personnel Psychology, 44*(1), 1–26. Used only as **direction** for drilled work, not a warrior-race norm. Exact midpoint: **project convention.** |
| Other trait midpoints | **Project convention.** |
| `cognitiveStage` = `ConcreteOperational` | Piaget, J. (1950). *The Psychology of Intelligence.* Inhelder, B., & Piaget, J. (1958). *The Growth of Logical Thinking from Childhood to Adolescence.* Concrete operations handle given material; hypothetical-deductive thought is formal. PE sets `hypothetical` to 0 below formal operations. Choosing this stage for the clan: **project convention** (fantasy structure, not a claim that a people “failed” a test). |
| `repeat-protocol` / combat operants | Skinner, B. F. (1953). *Science and Human Behavior.* Strengths and action ids: **project convention.** |
| ALMA providers | Gebhard, P. (2005). ALMA. McCrae & Costa (2008); Mehrabian & Russell (1974); Ortony, Clore, & Collins (1988). |
| `piaget-equilibration` | Piaget (1950, 1985); Inhelder & Piaget (1958). Numeric gains in PE: **project convention.** |
| Omitting Peterson | **Project convention.** Keeps “won’t try a hypothetical” on cognition + training, not on a meaning-layer formula. |
| Jitter / omitting `identityStage` | **Project convention.** |
