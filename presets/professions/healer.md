# healer

Generic wound-binder / sick-sitter. Not a licensed physician, not a clinic, and not a real-world ethnic group.

## Fiction

Sits with fever, binds a cut, and knows which salve is on the shelf. People come because someone is hurt, not because a guild wants a lecture. The work is care and repetition, not an intelligence rank.

## Knobs

| Field | Value |
| --- | --- |
| `id` | `healer` |
| `category` | `profession` |
| `cognitiveStage` | omitted (generic adult job; do not rank intelligence) |
| `identityStage` | omitted |

### traits

OCEAN 0..1. Constructor order: Openness, Conscientiousness, Extraversion, Agreeableness, Neuroticism.

| Trait | Band | Midpoint | Role in this job |
| --- | --- | --- | --- |
| Openness | mid | 0.50 | New complaints; not a researcher by default |
| Conscientiousness | high | 0.76 | Doses and clean cloth fail if this slips |
| Extraversion | mid | 0.48 | Beside a bed; not a square |
| Agreeableness | high | 0.72 | Care-work; not a published “healer people” norm |
| Neuroticism | mid | 0.48 | Care about a worsening case |

### operantSeeds

| Action id | Strength | What the host might mean |
| --- | --- | --- |
| `bind` | 0.74 | Dress a wound |
| `sit-with` | 0.68 | Stay with the sick |
| `dose` | 0.62 | Give a prepared draught |
| `fetch-supply` | 0.50 | Get cloth, water, salve |
| `idle` | 0.20 | Wait between cases |

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
| Crowd | Shared infirmary seed, not one engine per attendant |

Jitter magnitudes are **project convention**.

## Citations

| Knob | Source |
| --- | --- |
| Trait scale (OCEAN 0..1) | McCrae & Costa (2008). |
| Sampling this job | ILO (2012), *ISCO-08* major group 2 (Professionals) as **care work**, not a medical license and not skill-level 4 as IQ. Barrick & Mount (1991) professionals group included doctors; this seed is generic care, not a credential. Technician-style compounding is `apothecary`. |
| High Conscientiousness | Barrick & Mount (1991); Hurtz & Donovan (2000). Direction across occupations. |
| High Agreeableness | **Project convention.** Barrick & Mount did not treat Agreeableness as a strong general performance predictor; the midpoint is game-feel for care, not a selection key. |
| Other trait midpoints | **Project convention.** |
| `operantSeeds` | Skinner (1953). Strengths and action ids: **project convention.** |
| ALMA + `skinner-operant` | Gebhard (2005); Skinner (1953); Ferster & Skinner (1957). |
| Not a clinic | [`DISCLAIMER.md`](../../DISCLAIMER.md). Entertainment middleware. |
| Jitter / omitting stages | **Project convention.** |
