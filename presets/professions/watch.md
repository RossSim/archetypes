# town-watch

Generic garrison / gate-guard job. Not a named IP, not a national army table, and not a real-world ethnic group.

## Fiction

Stands the gate and walks the street after dark. The work is noticing who should not be there and calling the rest of the watch. It is not wilderness scouting; the wall is the wall.

## Knobs

| Field | Value |
| --- | --- |
| `id` | `town-watch` |
| `category` | `profession` |
| `cognitiveStage` | omitted (generic adult job; do not rank intelligence) |
| `identityStage` | omitted |

### traits

OCEAN 0..1. Constructor order: Openness, Conscientiousness, Extraversion, Agreeableness, Neuroticism.

| Trait | Band | Midpoint | Role in this job |
| --- | --- | --- | --- |
| Openness | low | 0.38 | Protocol over novelty |
| Conscientiousness | high | 0.74 | Watch-standing and the same three answers |
| Extraversion | mid | 0.52 | Challenge a stranger; not a courtier |
| Agreeableness | mid | 0.42 | Loyalty to the watch; not softness at the gate |
| Neuroticism | mid | 0.45 | Alert, not a panic score |

### operantSeeds

| Action id | Strength | What the host might mean |
| --- | --- | --- |
| `challenge` | 0.72 | Stop and ask |
| `patrol` | 0.70 | Walk the assigned route |
| `raise-alarm` | 0.62 | Call the rest of the watch |
| `repeat-protocol` | 0.58 | Same gate answers |
| `idle` | 0.22 | Stand and wait |

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
| Crowd | Shared watch seed (one gate), not one engine per walker |

Jitter magnitudes are **project convention**.

## Citations

| Knob | Source |
| --- | --- |
| Trait scale (OCEAN 0..1) | McCrae & Costa (2008). |
| Sampling this job | ILO (2012), *ISCO-08* major group 0 (Armed forces) as a **garrison** sample; Barrick & Mount (1991) **police** occupational group for Extraversion/C directions. Not a real-world force and not an IQ table. |
| High Conscientiousness | Barrick & Mount (1991); Hurtz & Donovan (2000). Direction; not a cutoff. |
| Other trait midpoints | **Project convention.** Low Openness is not a Piaget stage. |
| `operantSeeds` | Skinner (1953). Strengths and action ids: **project convention.** |
| ALMA + `skinner-operant` | Gebhard (2005); Skinner (1953); Ferster & Skinner (1957). |
| Distinct from `wilderness-scout` | **Project convention.** Scout is lookout/reconnaissance (openness/explore); watch is gate protocol. |
| Jitter / omitting stages | **Project convention.** |
