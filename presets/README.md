# Presets

Hand-authored catalog tables. Markdown is the format until a builder exists. There is no C# `MindPreset` yet; later code should be inferred from these rows.

## Layout

```text
presets/
├── README.md              # this file: index + profession guardrails
├── schema.md              # shared row fields
└── professions/
    ├── smith.md
    ├── scout.md
    └── clerk.md
```

Clan tables come next (same schema, Fiction / Knobs / Citations split). Temperament is later.

## Profession index

| Id | Fiction (one line) |
| --- | --- |
| `village-smith` | Village craft: forge, repair, keep a steady shop |
| `wilderness-scout` | Reconnaissance and lookout, not a named IP |
| `records-clerk` | Record-keeper and administrator |

## Profession guardrails

Every profession entry must pass this list before merge:

- No IQ, g, WAIS-style composites, or any profession→intelligence rank
- No real-world race, ethnicity, or national cognitive rank tables
- No MBTI or four-letter type inventories
- No Holland RIASEC or Sternberg knobs until Personality Engine ships those providers
- Fiction blurb is not a citation. Lore must not imply a paper
- Every numeric knob cites a paper **or** is labeled **project convention**
- Only Personality Engine 0.6.1+ constructor args (`OceanTraits`, optional Piaget/Erikson stages, operant seeds, enabled provider ids)
- Jobs differ by **trait bands + training history**, not by “smarter” or “dumber” people
- Generic job names only (smith, scout, clerk) — not real-world demographic groups

See also [Disclaimer](../DISCLAIMER.md) and [Design](../docs/DESIGN.md).
