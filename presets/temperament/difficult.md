# difficult-temperament

Starting climate. Not a villain type, not an infant diagnosis, and not “high Neuroticism.”

## Fiction

New rooms take work. Routines slip. A loud market reads as too much. When something goes wrong, the reaction is big. Not a moral failing — a starting climate that needs more recovery time.

## Knobs

| Field | Value |
| --- | --- |
| `id` | `difficult-temperament` |
| `category` | `temperament` |
| `cognitiveStage` | omitted (climate is not a developmental rank) |
| `identityStage` | omitted |

### traits

OCEAN 0..1. Constructor order: Openness, Conscientiousness, Extraversion, Agreeableness, Neuroticism.

| Trait | Band | Midpoint | Role in this climate |
| --- | --- | --- | --- |
| Openness | mid | 0.48 | Not a closed mind; difficult is withdrawal and mood, not stupidity |
| Conscientiousness | low | 0.35 | NYLS irregularity of biological functions / a less predictable day; weak mapping |
| Extraversion | low | 0.32 | Thomas & Chess **withdrawal** |
| Agreeableness | low | 0.32 | Slow to adapt; not “mean people” |
| Neuroticism | high | 0.72 | More negative quality of mood and a lower threshold in the original cluster — still only one knob on this row |

### operantSeeds

Omitted. Temperament is not job training.

### enabledProviderIds

- `ocean`
- `ocean-to-pad`
- `pad-mood`
- `occ`
- `occ-to-pad`

No `skinner-operant`, Piaget, Erikson, or Peterson. Intensity of reaction is **not** encoded as a trait; the host chooses OCC event magnitudes.

### pad notes

PAD is not authored here. `ocean-to-pad` should pull a lower Pleasure baseline from low Extraversion and Agreeableness. Do not treat high Neuroticism as high Arousal: ALMA’s N coefficient on arousal is negative. Dominance follows Extraversion in that mapping.

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
| Constellation (difficult) | Thomas, A., Chess, S., & Birch, H. G. (1968). *Temperament and Behavior Disorders in Children.* New York University Press. Thomas, A., & Chess, S. (1977). *Temperament and Development.* Brunner/Mazel. Thomas, A., & Chess, S. (1981). *The Dynamics of Psychological Development.* Brunner/Mazel. Difficult = irregularity, withdrawal, slow adaptability, high intensity, negative mood. Mapping that cluster onto these OCEAN bands: **project convention.** Not a NYLS scoring key, not a villain class, and not an infant diagnosis. |
| Low Extraversion | Thomas & Chess withdrawal. Exact midpoint: **project convention.** |
| Low Agreeableness | Thomas & Chess slow adaptability. Exact midpoint: **project convention.** Low A is not hostility as a type. |
| High Neuroticism | Thomas & Chess negative quality of mood. Exact midpoint: **project convention.** Do not treat N as the whole constellation. |
| Low Conscientiousness | NYLS irregularity onto C: **project convention** (weak mapping). |
| Mid Openness | **Project convention.** Withdrawal is Extraversion here, not low Openness as “less intelligent.” |
| Trait bands (low/mid/high ranges) | **Project convention.** |
| Intensity / threshold / distractibility | *Not PE knobs.* Host OCC magnitudes and pacing. **Project convention** to omit them. |
| Omitting `operantSeeds` / `skinner-operant` | **Project convention.** |
| PAD baseline | Mehrabian, A. (1996). Pleasure-arousal-dominance: A general framework for describing and measuring individual differences in temperament. *Current Psychology, 14*(4), 261–292. Gebhard, P. (2005). ALMA. In *Proceedings of AAMAS '05*. Coefficients live in PE `ocean-to-pad`; this row does not set PAD. |
| ALMA providers (`ocean`, `ocean-to-pad`, `pad-mood`, `occ`, `occ-to-pad`) | Gebhard (2005); McCrae & Costa (2008); Mehrabian & Russell (1974); Ortony, Clore, & Collins (1988). Wiring: **project convention.** |
| Jitter / omitting stages | **Project convention.** |
