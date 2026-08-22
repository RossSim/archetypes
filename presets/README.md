# Presets

Hand-authored catalog tables. Markdown is the authoring source. C# `Catalog` and embedded JSON under this tree encode the same `MindPreset` rows.

## Layout

```text
presets/
├── README.md              # this file: hub + profession guardrails
├── schema.md              # shared row fields
├── professions/
│   ├── README.md          # ISCO-08 sampling frame + full job index
│   └── *.md               # one file per generic job (JSON sidecars named by id)
├── clans/
│   ├── README.md          # clan template + clan guardrails
│   ├── philobrain-scholar.md
│   └── trog-warrior.md
└── temperament/
    ├── README.md          # temperament template + guardrails
    ├── easy.md
    ├── difficult.md
    └── slow-to-warm-up.md
```

## Where to look

| Need | File |
| --- | --- |
| Row fields | [`schema.md`](schema.md) |
| Job index and ISCO-08 sampling frame | [`professions/README.md`](professions/README.md) |
| Clan template and index | [`clans/README.md`](clans/README.md) |
| Temperament template and index | [`temperament/README.md`](temperament/README.md) |

`Catalog` in `src/Archetypes.Core` encodes every profession, clan, and temperament row in this tree. `CatalogJson.Load(id)` reads the embedded JSON sidecar.

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
- Generic job names only — not real-world demographic groups

Clan template and extra clan rules: [clans/README.md](clans/README.md). Temperament template and extra rules: [temperament/README.md](temperament/README.md).

See also [Disclaimer](../DISCLAIMER.md) and [Design](../docs/DESIGN.md).
