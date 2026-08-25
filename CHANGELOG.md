# Changelog

All notable changes to Archetypes are documented here.

The format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).
Versions follow [SemVer](https://semver.org/).

## [Unreleased]

### Changed

- Disclaimer leads with game/simulation software; public catalog will not accept race or national-rank presets
- Clan catalog: Philobrain/Trog are not a smart/dumb pair; Piaget stage is a hypotheticals flag
- Citations registry: Barrick/Hurtz are job-performance validity, not occupational means; DeYoung 2002 split from *Maps of Meaning*; DOI, publisher, and catalog links on the shared papers and books
- Trait-band authoring is half-open at 0.40; scout and innkeeper Conscientiousness 0.60; clerk Extraversion 0.38
- README defines preset, project convention, and the two load APIs; Sternberg is roadmap-only

### Added

- Link to the public Unity host [NPC-demo](https://github.com/RossSim/NPC-demo) (macOS playable; this repo stays catalogs)

## [1.0.0] - 2026-08-22

### Added

- C# `Catalog` encodings for every sampled profession row
- Temperament catalog: Thomas & Chess easy / difficult / slow-to-warm-up as OCEAN bands on the existing jitter tiers, not a type inventory
- Embedded JSON sidecars for every catalog row, `CatalogJson` loader, and `docs/CITATIONS.md`
- GitHub Release pack for `Archetypes.Core` (nupkg + DLL zip), depending on Personality Engine 0.6.1

### Changed

- `MindPreset`, `PresetBuilder`, and catalog JSON are the 1.0 contract; removing or renaming fields is a major bump

## [0.1.0] - 2026-08-22

### Added

- Charter, Cursor start notes, and a public-hygiene check
- Profession catalog: shared schema, merge guardrails, and generic jobs covering ILO ISCO-08 major groups
- Clan catalog: three-section template, guardrails, and two fantasy seeds (`philobrain-scholar`, `trog-warrior`)
- `MindPreset`, `PresetBuilder` → Personality Engine `AffectEngine`, and C# encodings of smith / scout / clerk / Philobrain / Trog

### Changed

- Roadmap and design: version cuts are later intent, not the next coding slice

## [0.0.0] - 2026-08-22

### Added

- Initial GitHub repository and MIT license
