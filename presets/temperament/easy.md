# easy-temperament

Starting climate. Not a personality type, not an infant diagnosis, and not “the extravert class.”

## Fiction

Settles into a new hall without much fuss. Meals and sleep stay roughly on a pattern. New faces get a look, then a nod. Mood stays mostly even unless the host stacks a bad day on purpose.

## Knobs

| Field | Value |
| --- | --- |
| `id` | `easy-temperament` |
| `category` | `temperament` |
| `cognitiveStage` | omitted (climate is not a developmental rank) |
| `identityStage` | omitted |

### traits

OCEAN 0..1. Constructor order: Openness, Conscientiousness, Extraversion, Agreeableness, Neuroticism.

| Trait | Band | Midpoint | Role in this climate |
| --- | --- | --- | --- |
| Openness | mid | 0.50 | Not a novelty type; easy is about approach and mood, not scholarship |
| Conscientiousness | mid | 0.55 | NYLS rhythmicity / a somewhat regular day; weak mapping |
| Extraversion | high | 0.68 | Thomas & Chess **approach** (not “life of the party”) |
| Agreeableness | high | 0.70 | Adapts to a new room without a fight |
| Neuroticism | low | 0.32 | More positive quality of mood; not the only knob on this row |

### operantSeeds

Omitted. Temperament is not job training.

### enabledProviderIds

- `ocean`
- `ocean-to-pad`
- `pad-mood`
- `occ`
- `occ-to-pad`

No `skinner-operant`, Piaget, Erikson, or Peterson. Named still gets OCC so a joy or distress event can sting; ambient jitter drops OCC as usual.

### pad notes

PAD is not authored here. `ocean-to-pad` should pull a relatively higher Pleasure baseline from high Extraversion and Agreeableness. Do not read high Arousal off this row; ALMA maps Neuroticism *against* arousal. Dominance follows Extraversion in that mapping.

### jitter

| Tier | Note |
| --- | --- |
| Named | Full composition; trait jitter ±0.05 inside the band |
| Ambient | Personality + mood only; trait jitter ±0.12; skip OCC if the host is counting cost |
| Crowd | Shared district seed, not one engine per walker |

Jitter magnitudes are **project convention**.

## Citations

| Knob | Source |
| --- | --- |
| Trait scale (OCEAN 0..1) | McCrae, R. R., & Costa, P. T., Jr. (2008). The five-factor theory of personality. In O. P. John, R. W. Robins, & L. A. Pervin (Eds.), *Handbook of personality: Theory and research* (3rd ed., pp. 159–181). Guilford Press. **Not** NEO items. |
| Constellation (easy) | Thomas, A., Chess, S., & Birch, H. G. (1968). *Temperament and Behavior Disorders in Children.* New York University Press. Thomas, A., & Chess, S. (1977). *Temperament and Development.* Brunner/Mazel. Thomas, A., & Chess, S. (1981). *The Dynamics of Psychological Development.* Brunner/Mazel. Easy = biological regularity, approach, adaptability, mild-to-moderate intensity, positive mood. Mapping that cluster onto these OCEAN bands: **project convention.** Not a NYLS scoring key and not an infant diagnosis. |
| High Extraversion | Thomas & Chess approach / withdrawal. Exact midpoint: **project convention.** This is not a published “easy adult” Extraversion norm. |
| High Agreeableness | Thomas & Chess adaptability. Exact midpoint: **project convention.** |
| Low Neuroticism | Thomas & Chess quality of mood. Exact midpoint: **project convention.** Do not treat N as the whole constellation. |
| Mid Conscientiousness | NYLS rhythmicity / persistence onto C: **project convention** (weak mapping). |
| Mid Openness | **Project convention.** |
| Trait bands (low/mid/high ranges) | **Project convention.** |
| Omitting `operantSeeds` / `skinner-operant` | **Project convention.** Temperament is not a job repertoire. |
| PAD baseline | Mehrabian, A. (1996). Pleasure-arousal-dominance: A general framework for describing and measuring individual differences in temperament. *Current Psychology, 14*(4), 261–292. Gebhard, P. (2005). ALMA. In *Proceedings of AAMAS '05*. Coefficients live in PE `ocean-to-pad`; this row does not set PAD. |
| ALMA providers (`ocean`, `ocean-to-pad`, `pad-mood`, `occ`, `occ-to-pad`) | Gebhard (2005); McCrae & Costa (2008); Mehrabian & Russell (1974); Ortony, Clore, & Collins (1988). Wiring temperament to personality + mood + optional OCC: **project convention.** |
| Jitter / omitting stages | **Project convention.** |
