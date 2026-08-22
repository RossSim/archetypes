# slow-to-warm-up

Starting climate. Not a shy type letter, not an infant diagnosis, and not a milder “difficult.”

## Fiction

Hangs back at the door. After a few days in the same tavern, talk comes easier. First contact looks like refusal; it is caution. Milder than the difficult seed, slower than the easy one.

## Knobs

| Field | Value |
| --- | --- |
| `id` | `slow-to-warm-up` |
| `category` | `temperament` |
| `cognitiveStage` | omitted (climate is not a developmental rank) |
| `identityStage` | omitted |

### traits

OCEAN 0..1. Constructor order: Openness, Conscientiousness, Extraversion, Agreeableness, Neuroticism.

| Trait | Band | Midpoint | Role in this climate |
| --- | --- | --- | --- |
| Openness | mid | 0.42 | Slower to novelty without closing the map; not a cognitive rank |
| Conscientiousness | mid | 0.50 | Not the irregular-day cluster |
| Extraversion | low | 0.30 | Withdrawal **and** low activity |
| Agreeableness | mid | 0.48 | Slow to adapt, but milder than the difficult seed (mid, not low) |
| Neuroticism | mid | 0.52 | A bit more negative than easy; not the high-N difficult row |

### operantSeeds

Omitted. Temperament is not job training.

### enabledProviderIds

- `ocean`
- `ocean-to-pad`
- `pad-mood`
- `occ`
- `occ-to-pad`

No `skinner-operant`, Piaget, Erikson, or Peterson. “Warms up over days” is host pacing (repeat contact, time on the clock), not a PE temperament provider.

### pad notes

PAD is not authored here. Pleasure should sit between easy and difficult because Extraversion is low while Agreeableness stays mid. Low Extraversion also pulls Dominance down in `ocean-to-pad`. Mild intensity is **not** encoded as low Arousal by hand.

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
| Constellation (slow-to-warm-up) | Thomas, A., Chess, S., & Birch, H. G. (1968). *Temperament and Behavior Disorders in Children.* New York University Press. Thomas, A., & Chess, S. (1977). *Temperament and Development.* Brunner/Mazel. Thomas, A., & Chess, S. (1981). *The Dynamics of Psychological Development.* Brunner/Mazel. Slow-to-warm-up = withdrawal, slow adaptability, mild intensity, somewhat negative mood, low activity. Mapping that cluster onto these OCEAN bands: **project convention.** Not a NYLS scoring key and not an infant diagnosis. |
| Low Extraversion | Thomas & Chess withdrawal plus low activity. Exact midpoint: **project convention.** |
| Mid Agreeableness | Slower adaptability than easy, milder than difficult. Exact midpoint: **project convention.** |
| Mid Neuroticism | Quality of mood between easy and difficult. Exact midpoint: **project convention.** Do not treat N as the whole constellation. |
| Mid Conscientiousness / mid Openness | **Project convention.** |
| Trait bands (low/mid/high ranges) | **Project convention.** |
| Warm-up over time | Host pacing. PE 0.6.1+ has no “days to approach” channel. **Project convention** to omit a fake knob. |
| Omitting `operantSeeds` / `skinner-operant` | **Project convention.** |
| PAD baseline | Mehrabian, A. (1996). Pleasure-arousal-dominance: A general framework for describing and measuring individual differences in temperament. *Current Psychology, 14*(4), 261–292. Gebhard, P. (2005). ALMA. In *Proceedings of AAMAS '05*. Coefficients live in PE `ocean-to-pad`; this row does not set PAD. |
| ALMA providers (`ocean`, `ocean-to-pad`, `pad-mood`, `occ`, `occ-to-pad`) | Gebhard (2005); McCrae & Costa (2008); Mehrabian & Russell (1974); Ortony, Clore, & Collins (1988). Wiring: **project convention.** |
| Jitter / omitting stages | **Project convention.** |
