#!/usr/bin/env bash
# Download PersonalityEngine.Core 0.6.1 from the public GitHub Release into a local NuGet feed.
set -euo pipefail

root="$(git rev-parse --show-toplevel 2>/dev/null || true)"
if [[ -z "${root}" ]]; then
  root="$(cd "$(dirname "$0")/.." && pwd)"
fi

dest="${root}/artifacts/nuget"
mkdir -p "${dest}"
nupkg="${dest}/PersonalityEngine.Core.0.6.1.nupkg"
url="https://github.com/RossSim/personality-engine/releases/download/v0.6.1/PersonalityEngine.Core.0.6.1.nupkg"

if [[ ! -f "${nupkg}" ]]; then
  curl -fsSL "${url}" -o "${nupkg}"
fi

echo "Personality Engine 0.6.1 nupkg at ${nupkg}"
