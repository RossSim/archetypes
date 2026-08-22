# Profession catalog

Generic jobs only. Same row schema as [`../schema.md`](../schema.md). Adult jobs omit Piaget and Erikson stages so work is not mistaken for an intelligence rank.

## Sampling frame

There is no academic paper that lists “the professions” as mind seeds. This catalog samples **at least one generic game job per ILO ISCO-08 major group** so occupational *space* is covered without encoding 436 unit groups. Extra seeds sit where Barrick occupational groups or two distinct game jobs share a major group.

| ISCO-08 major group | Catalog id | Notes |
| --- | --- | --- |
| 1 Managers | `guild-steward` | Barrick & Mount: Extraversion for managers |
| 2 Professionals | `healer`, `school-teacher` | Two seeds; not an IQ rank |
| 3 Technicians and associate professionals | `apothecary` | Compounder, not a license |
| 4 Clerical support workers | `records-clerk` | First-wave seed |
| 5 Service and sales workers | `innkeeper`, `market-merchant` | Barrick & Mount: Extraversion for sales |
| 6 Skilled agricultural, forestry and fishery workers | `field-farmer`, `herder` | Training = operant seeds |
| 7 Craft and related trades workers | `village-smith`, `carpenter` | Two crafts |
| 8 Plant and machine operators, and assemblers | `water-miller` | Generic mill, not industrial plant |
| 9 Elementary occupations | `porter` | Do not encode as lower intelligence |
| 0 Armed forces occupations | `town-watch` | Barrick & Mount police group. `wilderness-scout` is lookout, not garrison |

**Do not import** ISCO skill levels 1–4 as Piaget stage, IQ, or prestige. **Do not encode** Holland RIASEC as knobs until Personality Engine ships that provider.

Sources for this table: International Labour Office (2012), *International Standard Classification of Occupations: ISCO-08*; Barrick, M. R., & Mount, M. K. (1991), *Personnel Psychology, 44*(1), 1–26 (occupational *groups* and OCEAN directions, not a job list).

## Index

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

## C# encodings

`Catalog` currently encodes three jobs: `village-smith`, `wilderness-scout`, `records-clerk`. The other rows in this index are markdown-only until they are added to `src/Archetypes.Core`.
