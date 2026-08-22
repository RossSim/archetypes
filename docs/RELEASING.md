# Releasing

Every published cut of Archetypes has a **version**, **changelog notes**, and a **GitHub Release** with downloadable assets. The nupkg is distributed the same way as Personality Engine (GitHub Release asset into a local feed). This repo does not push to nuget.org.

## Version

The package and assembly version live in `src/Archetypes.Core/Archetypes.Core.csproj` (`Version`). Use SemVer: `MAJOR.MINOR.PATCH`.

- **PATCH** — fixes, docs, packaging
- **MINOR** — new catalog rows, optional additive fields, compatible API
- **MAJOR** — removing or renaming `MindPreset` fields, changing JSON keys, changing jitter magnitudes, or dropping a frozen provider id

The README status line must match `Version`.

1.0 froze the contract in [Design](DESIGN.md#10-contract). New profession / clan / temperament **rows** are MINOR. New psychology knobs wait for Personality Engine.

## Release notes

Add a new section at the top of `CHANGELOG.md` (below `[Unreleased]`):

```markdown
## [X.Y.Z] - YYYY-MM-DD

### Added
### Changed
### Fixed
```

Move items out of `[Unreleased]`. Those notes are the GitHub Release body. Do **not** include private issue-tracker URLs, project keys, or ticket ids in the changelog, the GitHub Release, or the git tag message.

## Cut a release

1. Bump `Version` and the README status line.
2. Write the `CHANGELOG.md` section.
3. Commit on `main` (why, not what).
4. Tag and push:

   ```bash
   git tag -a vX.Y.Z -m "Archetypes vX.Y.Z"
   git push origin main
   git push origin vX.Y.Z
   ```

5. Pushing `v*` runs [`.github/workflows/release.yml`](../.github/workflows/release.yml): restore Personality Engine 0.6.1, test, pack `.nupkg` + DLL zip, create the GitHub Release with the changelog section as notes.

If the workflow cannot run, pack locally and attach the same assets:

```bash
bash scripts/restore-pe.sh
dotnet test
dotnet pack src/Archetypes.Core/Archetypes.Core.csproj -c Release -o dist
```

Do not commit `dist/`, `bin/`, `artifacts/`, or `*.nupkg`.
