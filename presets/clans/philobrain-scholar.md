# philobrain-scholar

Fantasy clan. Not a real-world ethnic group and not an IQ table.

## Fiction

Philobrain halls argue about what *would* happen if the river ran backward. Children are praised for “if” questions. A scout’s report is treated as a hypothesis until someone names a test. They lose patience with “because that is how it has always been done.”

## Knobs

| Field | Value |
| --- | --- |
| `id` | `philobrain-scholar` |
| `category` | `clan` |
| `cognitiveStage` | `FormalOperational` (PE `hypothetical` flag on) |
| `identityStage` | omitted (clan is about how they reason, not an Erikson age) |

### traits

OCEAN 0..1. Constructor order: Openness, Conscientiousness, Extraversion, Agreeableness, Neuroticism.

| Trait | Band | Midpoint | Role in this clan |
| --- | --- | --- | --- |
| Openness | high | 0.80 | Preference for novelty and ideas; not a scholarship IQ |
| Conscientiousness | mid | 0.52 | Study habits vary; the hall is not a barracks |
| Extraversion | mid | 0.50 | Debate is social; the library is not |
| Agreeableness | mid | 0.48 | Argument is allowed; cruelty is not the point |
| Neuroticism | mid | 0.42 | Curiosity without making worry the clan trait |

### operantSeeds

Action ids the host may emit as `skinner.emit`. Strengths are training history, **project convention**.

| Action id | Strength | What the host might mean |
| --- | --- | --- |
| `explore` | 0.72 | Seek a new case or path |
| `hypothesize` | 0.70 | State an if-then |
| `debate` | 0.62 | Test a claim in talk |
| `study` | 0.58 | Stay with a text or problem |
| `teach` | 0.45 | Hand a method to someone else |

### enabledProviderIds

- `ocean`
- `ocean-to-pad`
- `pad-mood`
- `occ`
- `occ-to-pad`
- `skinner-operant`
- `piaget-equilibration`
- `peterson-metatraits`
- `peterson-maps`

Piaget is on because this clan’s lore is hypothetical-deductive structure. Peterson is on because exploration vs order is part of the hall’s work. Mix coefficients stay PE’s.

### jitter

| Tier | Note |
| --- | --- |
| Named | Full composition; trait jitter ±0.05 inside the band |
| Ambient | Personality + mood only; trait jitter ±0.12; keep Piaget stage so hypothetical flags stay consistent |
| Crowd | Shared hall seed, not one engine per walker |

Jitter magnitudes are **project convention**.

## Citations

| Knob | Source |
| --- | --- |
| Trait scale (OCEAN 0..1) | McCrae, R. R., & Costa, P. T., Jr. (2008). The five-factor theory of personality. In O. P. John, R. W. Robins, & L. A. Pervin (Eds.), *Handbook of personality: Theory and research* (3rd ed., pp. 159–181). Guilford Press. **Not** NEO items. |
| High Openness | McCrae & Costa (2008) on Openness as a domain of novelty and ideas. Exact midpoint: **project convention.** This is not a published “scholar people” norm. |
| Other trait midpoints | **Project convention.** |
| `cognitiveStage` = `FormalOperational` | Inhelder, B., & Piaget, J. (1958). *The Growth of Logical Thinking from Childhood to Adolescence.* Piaget, J. (1950). *The Psychology of Intelligence.* Formal operations include hypothetical-deductive reasoning. Host-set stage; PE turns `hypothetical` on at this stage. Choosing this stage for the clan: **project convention** (fantasy composition, not a measured population). |
| `operantSeeds` | Skinner, B. F. (1953). *Science and Human Behavior.* 0..1 strengths and action ids: **project convention.** |
| ALMA providers | Gebhard, P. (2005). ALMA. McCrae & Costa (2008); Mehrabian & Russell (1974); Ortony, Clore, & Collins (1988). |
| `piaget-equilibration` | Piaget (1950, 1985); Inhelder & Piaget (1958). Numeric gains in PE: **project convention.** |
| `peterson-metatraits` / `peterson-maps` | DeYoung, C. G., Peterson, J. B., & Higgins, D. M. (2002). Higher-order factors of the Big Five predict conformity. *Personality and Individual Differences, 33*(4), 533–552. Peterson, J. B. (1999). *Maps of Meaning.* Enabling them here: **project convention.** |
| Jitter / omitting `identityStage` | **Project convention.** |
