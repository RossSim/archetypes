# Changelog

All notable changes to Archetypes are documented here.

The format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).
Versions follow [SemVer](https://semver.org/).

## [Unreleased]

### Added

- C# `Catalog` encodings for the remaining profession rows so every ISCO-08 major-group job has a `MindPreset`
- Temperament catalog: Thomas & Chess easy / difficult / slow-to-warm-up as OCEAN bands on the existing jitter tiers, not a type inventory
- Embedded JSON sidecars for every catalog row, `CatalogJson` loader, and `docs/CITATIONS.md`

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
