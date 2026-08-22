# Presets

Hand-authored catalog tables. Markdown is the authoring format. C# `MindPreset` encodings of the first seeds live in `src/Archetypes.Core`; later JSON should be inferred from these rows.

## Layout

```text
presets/
├── README.md              # this file: index + profession guardrails
├── schema.md              # shared row fields
├── professions/
│   ├── README.md          # ISCO-08 sampling frame + full job index
│   └── *.md               # one file per generic job
└── clans/
    ├── README.md          # clan template + clan guardrails
    ├── philobrain-scholar.md
    └── trog-warrior.md
```

Temperament is later.

## Profession index

Full index and the ILO ISCO-08 sampling frame live in [`professions/README.md`](professions/README.md). Short list:

| Id | Fiction (one line) |
| --- | --- |
| `village-smith` | Village craft: forge, repair, keep a steady shop |
| `carpenter` | Wood joinery and repair |
| `wilderness-scout` | Reconnaissance and lookout, not a named IP |
| `town-watch` | Gate and street garrison |
| `records-clerk` | Record-keeper and administrator |
| `guild-steward` | Keep a hall, a roster, and a purse |
| `market-merchant` | Buy, sell, and haggle in the open square |
| `innkeeper` | Beds, stew, and the common room |
| `healer` | Bind wounds and sit with the sick |
| `apothecary` | Measure, compound, and refuse a bad ask |
| `school-teacher` | Letters, sums, and keeping a room |
| `field-farmer` | Fields, seasons, and stores |
| `herder` | Flock, pasture, and the dog |
| `water-miller` | Keep the wheel turning |
| `porter` | Carry, stack, and wait at the door |

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

Clan template and extra clan rules: [clans/README.md](clans/README.md).

See also [Disclaimer](../DISCLAIMER.md) and [Design](../docs/DESIGN.md).
