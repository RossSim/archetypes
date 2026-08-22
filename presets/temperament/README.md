# Temperament catalog

Starting **climate** seeds, not types. Same row schema as professions and clans ([`../schema.md`](../schema.md)). Every public temperament file **must** use three sections — Fiction / Knobs / Citations — not one bibliography for the whole constellation.

These rows are Thomas & Chess **easy / difficult / slow-to-warm-up** clusters mapped onto Personality Engine OCEAN bands. PAD mood baseline comes from PE `ocean-to-pad` (Mehrabian coefficients as used in Gebhard ALMA). They are not MBTI, not a four-letter inventory, and not an infant diagnosis.

## Template

Copy this shape. Do not skip a section.

```markdown
# {id}

One-line reminder: starting climate, not a personality type and not a clinical label.

## Fiction

Designer-facing blurb only. Do not cite papers here. Do not imply a paper measured this NPC.

## Knobs

| Field | Value |
| --- | --- |
| `id` | kebab-case |
| `category` | `temperament` |
| `cognitiveStage` | omit |
| `identityStage` | omit |

### traits
(band + midpoint for O, C, E, A, N — spread across traits, not Neuroticism alone)

### operantSeeds
omit (temperament is not job training)

### enabledProviderIds
(`ocean`, `ocean-to-pad`, `pad-mood`, `occ`, `occ-to-pad`)

### pad notes
(what `ocean-to-pad` is expected to do; do not hand-author PAD)

### jitter
(named / ambient / crowd)

## Citations

One row per knob. Never one list that “covers the temperament.”
```

## Index

| Id | Fiction (one line) |
| --- | --- |
| `easy-temperament` | Settles in; approach and even mood |
| `difficult-temperament` | Withdraws, adapts slowly, reacts hard |
| `slow-to-warm-up` | Hangs back, then eases in |

All three rows are encoded in `Catalog`.

## NYLS dimensions vs PE knobs

Thomas & Chess described nine NYLS dimensions. Personality Engine 0.6.1+ does not have those channels. This catalog maps a **subset** onto OCEAN. Unmapped dimensions stay host-side (OCC event size, pacing). Mapping is **project convention**.

| NYLS dimension | This catalog |
| --- | --- |
| Activity level | Extraversion (low activity → lower E on slow-to-warm-up) |
| Rhythmicity | Conscientiousness (regularity). Weak mapping |
| Approach / withdrawal | Extraversion |
| Adaptability | Agreeableness |
| Threshold of responsiveness | *not a PE knob* |
| Intensity of reaction | *not a PE knob* — host OCC magnitudes |
| Quality of mood | Neuroticism (more negative mood → higher N) |
| Distractibility | *not a PE knob* |
| Attention span / persistence | Conscientiousness (partial) |

Do not treat Neuroticism as “the temperament slider.” Easy is high Extraversion **and** high Agreeableness **and** low Neuroticism. Difficult is low Extraversion **and** low Agreeableness **and** high Neuroticism **and** low Conscientiousness.

## PAD notes

Do not set Pleasure / Arousal / Dominance on the preset. PE computes the personality→mood baseline in `ocean-to-pad` (Gebhard ALMA 2005; Mehrabian 1996 for PAD as individual-difference language). ALMA’s Neuroticism coefficient on arousal is **negative**, so high N is not “more wound-up” in that mapping. Document the qualitative climate in fiction; let PE do the PAD math.

## Temperament guardrails

Profession guardrails still apply. In addition:

- **Not a type inventory.** Easy / difficult / slow-to-warm-up are starting bands, not letters you “are”
- No MBTI or four-letter types
- Not an infant assessment and not NYLS scoring keys
- Do not ship NYLS population percentages as NPC base rates
- Do not derive the row from Neuroticism alone
- Do not invent intensity, threshold, or distractibility knobs
- Omit `cognitiveStage` / `identityStage` (climate is not a developmental rank)
- Omit `operantSeeds` and `skinner-operant` (no job repertoire)
- Do not implement a temperament `IAffectProvider` here
- Fiction must not imply a paper measured this NPC
- Three-section split required on every temperament file
