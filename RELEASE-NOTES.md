# Teck PEAK — Famicom VI / EN Edition

A classic-console desktop launcher for PEAK, now with an offline Vietnamese / English localization layer for the bundled mods.

## Highlights

- Red-and-ivory Famicom-style launcher with a textured shell, PEAK cartridge, and controller-shaped controls.
- Curated mod installation, dependency resolution, tracked removal, backups, and package verification.
- 1,325 translation dictionary entries; **F10** switches Vietnamese / English and saves the selection.
- F7 mod menu, PEAK Unlimited, ItemInfo, Start With Backpacks, and optional Healing Campfires.
- Unofficial F7 compatibility patch for the current string-based `CharacterData.userID` API.

## Download and install

Download **Teck-PEAK-VI-EN.zip**, extract the entire archive, and keep `Teck-PEAK.exe` beside `packages`.

Close PEAK → open the launcher → **THIẾT LẬP** → choose your PEAK folder and mods → **CÀI MOD** → launch through Steam.

- **F7:** mod menu.
- **F10:** Vietnamese / English.
- **F2:** PEAK Unlimited settings.

## Known limitations

The translation layer has automated tests, but every localized page and Vietnamese glyph has not yet been checked in a live PEAK lobby. Unrecognized runtime text and unfamiliar item names fall back to the original language. Search items using their original English names. Gameplay features depend on game/mod versions and host/client requirements.

This is mod UI localization, not a complete translation of PEAK. The executable is unsigned. Current-build Defender scan details and verification limits are documented in `SECURITY-CHECK.txt`; the result is not a safety guarantee and does not clear detections on older builds.

## Checksums

```text
fc86f3eb87f7e874b47e78512dd3bd765e2d12a0a8f6828b795b7c16d6aaada5  Teck-PEAK-VI-EN.zip
eb4147a55fe8dd0cb73dae3f10b209ffc21abe99f130025ca7b9aa02e309add9  Teck-PEAK.exe
```

These checksums identify this specific build. If a file is rebuilt or repackaged, publish its new checksum.

Source code, third-party notices, test reports, and a bilingual usage guide are included in the archive.
