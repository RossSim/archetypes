# market-merchant

Generic stall-holder / trader. Not a named IP and not a real-world ethnic group.

## Fiction

Keeps a stall or a pack. Buys what will sell, names a price, and knows when to drop it. The square is loud. The work is people and goods, not a ledger in a quiet hall (that is the clerk).

## Knobs

| Field | Value |
| --- | --- |
| `id` | `market-merchant` |
| `category` | `profession` |
| `cognitiveStage` | omitted (generic adult job; do not rank intelligence) |
| `identityStage` | omitted |

### traits

OCEAN 0..1. Constructor order: Openness, Conscientiousness, Extraversion, Agreeableness, Neuroticism.

| Trait | Band | Midpoint | Role in this job |
| --- | --- | --- | --- |
| Openness | mid | 0.52 | New wares; not a scholar |
| Conscientiousness | mid | 0.58 | Enough order to not lose the purse |
| Extraversion | high | 0.74 | Sales is social interaction |
| Agreeableness | mid | 0.50 | Warm enough to sell; not a pushover |
| Neuroticism | mid | 0.45 | Care about a bad bargain |

### operantSeeds

| Action id | Strength | What the host might mean |
| --- | --- | --- |
| `haggle` | 0.75 | Name and move a price |
| `buy` | 0.62 | Take goods in |
| `sell` | 0.72 | Move goods out |
| `call-wares` | 0.58 | Draw a crowd |
| `idle` | 0.22 | Wait for a customer |

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
| Crowd | Shared stall seed, not one engine per hawker |

Jitter magnitudes are **project convention**.

## Citations

| Knob | Source |
| --- | --- |
| Trait scale (OCEAN 0..1) | McCrae & Costa (2008). |
| Sampling this job | ILO (2012), *ISCO-08* major group 5 (Service and sales workers). |
| High Extraversion | Barrick & Mount (1991). Extraversion predicted performance for **sales**. Exact midpoint: **project convention.** |
| Other trait midpoints | **Project convention.** |
| `operantSeeds` | Skinner (1953). Strengths and action ids: **project convention.** |
| ALMA + `skinner-operant` | Gebhard (2005); Skinner (1953); Ferster & Skinner (1957). |
| Jitter / omitting stages | **Project convention.** |
