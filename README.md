# Teck PEAK Launcher

### Retro hardware. A simpler way to manage PEAK mods.

A community Windows launcher for **PEAK**, styled after a classic red-and-ivory Famicom console. Install a curated mod bundle, choose your utilities, and switch supported mod text between **Vietnamese and English**.

![Teck PEAK Launcher — Famicom Edition](docs/images/launcher.png)

## Features

- **A console-shaped desktop launcher:** textured plastic, a PEAK cartridge, a wired controller, and a borderless window.
- **Mod installation and removal:** select supported mods, install their dependencies, and manage the files installed by Teck.
- **Vietnamese / English:** an offline localization layer with 1,325 dictionary entries. Switch languages with **F10** or the language button in the F7 menu.
- **An in-game F7 menu:** item spawning, player tools, teleport controls, recovery options, and configurable utilities, subject to each feature's requirements.
- **More players:** PEAK Unlimited provides configurable lobby capacity; the host must install it.
- **Package verification:** pinned SHA-256 hashes, installation backups, and rollback on supported write failures.

## Included mods

| Component | Version | Default | Purpose |
| --- | --- | --- | --- |
| PEAK Troll Mod | 0.5.0 + Teck compatibility patch | On | F7 menu, item and player tools, recovery, and utilities |
| PEAK Unlimited | 4.0.1 | On | Configurable player limit and multiplayer fixes |
| ItemInfo | 0.1.7 | On | Information about held items and their effects |
| Start With Backpacks | 1.1.0 | On | Starting backpack support |
| Healing Campfires | 4.5.1 | Off | Optional campfire healing and revival features |
| Teck PEAK Bilingual | 1.0.0 | Automatic dependency | Vietnamese / English display translation |

Required dependencies are included as separate ZIP packages. Available features and compatibility depend on the game version, host permissions, and the mods installed by other participants.

## Requirements

- Windows with .NET Framework 4.x.
- An installed copy of PEAK and Steam signed in to an account with access to the game.
- Permission to write to your PEAK installation folder.

## Installation

1. Download **Teck-PEAK-VI-EN.zip** from this repository's **Releases** page.
2. Extract the entire archive into a new folder. Keep `Teck-PEAK.exe` beside the `packages` folder.
3. Close PEAK and open `Teck-PEAK.exe`.
4. Open **THIẾT LẬP** and select the folder containing `PEAK.exe` and `PEAK_Data`.
5. Choose your mods, save the selection, and click **CÀI MOD**.
6. Sign in to Steam and click **CHƠI PEAK**, or launch PEAK from your Steam Library.
7. Enter a lobby, press **F7**, and use **F10** to switch the supported mod text between Vietnamese and English.

Use this release when updating the bilingual bundle. Older Teck launchers do not include the localization layer.

## Launcher controls

| Control | Action |
| --- | --- |
| **POWER** | Launch PEAK through Steam |
| **RESET** | Install or update the selected mods |
| **A** | Open settings, mod selection, and the game-folder picker |
| **B** | Open instructions and the session log |
| **− / ×** | Minimize / close |
| Drag an empty area of the console | Move the launcher |

The physical-looking **RESET** button installs mods; it does not reset game progress. The D-pad and SELECT/START details are decorative.

## In-game shortcuts

| Key | Action |
| --- | --- |
| **F7** | Open PEAK Troll Mod |
| **F10** | Switch Vietnamese / English |
| **F2** | Open PEAK Unlimited settings |
| **F8** | Spectator free camera provided by PEAK Troll Mod |

These are the bundle's default bindings. Some can be reassigned in mod settings.

The language setting is saved in `BepInEx/config/teck.peak.bilingual.cfg`. Use `Language = vi` for Vietnamese or `Language = en` for English while the game is closed.

## Translation coverage

The localization layer handles supported mod menu captions, descriptions, tooltips, configuration labels, and mod-created item/status text. It covers the F7 menu, PEAK Unlimited, ItemInfo, and supported settings shown by the F7 configuration browser, including optional Healing Campfires.

This is **mod UI localization**, not a full translation of the PEAK base game. Configuration identifiers, item IDs, network messages, lobby codes, text input, and technical logs retain their original data. Unknown runtime text and unfamiliar item names fall back to the original language. Search for items using their original English names.

Some original mod names and technical terms are intentionally retained. Mods without their own visible menu do not gain a new menu through localization.

## Compatibility and verification

The bundled F7 menu contains an **unofficial Teck compatibility patch**, assembly version `0.5.0.1`. It addresses a `CharacterData.userID` type mismatch by reading the current string-based ID and adds an initialization error guard. It is not an official release by the upstream author.

Automated checks cover translation logic, English pass-through, dynamic numbers, rich-text tags, multiline captions, package integrity, dependency selection, installation/update/removal, configuration preservation, and rollback behavior. Installer tests use fake game directories and do not execute fake game files.

**Every localized page, Vietnamese glyph, and gameplay feature has not yet been verified in a live PEAK lobby.** A static dictionary audit does not prove correct rendering in Unity. Game updates or additional mods may introduce incompatible or untranslated text. Use private sessions where participants agree to the enabled features.

See the release's `TEST-RESULTS.txt`, `LOCALE-TESTS.txt`, `TRANSLATION-AUDIT.tsv`, and `LOCALIZATION-VI-EN.md` for details.

## Troubleshooting

**Steam opens but PEAK does not start:** check Steam for login, update, or launch errors, then try **Library → PEAK → Play**. The launcher waits up to 30 seconds to detect a PEAK process; detecting a process does not confirm that the game reached its main menu. Launch diagnostics are saved to `%LOCALAPPDATA%\TeckPeak\launch.log`.

**Text is clipped or missing Vietnamese accents:** switch to English with **F10** and report the affected page with a screenshot.

**Another mod loader is already installed:** manage that installation with the tool that created it. Teck stops rather than overwriting an untracked loader.

**A package fails verification:** use a fresh copy of the published archive. Do not modify the pinned hashes to bypass the failure.

**Removing the bundle:** close PEAK, then use **THIẾT LẬP → Gỡ mod**. The launcher removes tracked files and restores available backups. Untracked files and game-generated configuration are preserved.

## Windows security notices

The executable is **unsigned**. A Microsoft Defender custom directory scan of this build on **October 19, 2026** reported no threats. This is a point-in-time scan result, not a guarantee of safety or a complete security audit.

An earlier Teck build in this project's history was flagged as `Trojan:Win32/Bearfoos.A!ml`. That detection has **not** been established as a false positive. The result above applies to the current build only and does not clear earlier files. Packaging or reputation alone does not establish why a detection occurred.

If a security product flags a file, stop using it and retain the detection details for investigation. Do not disable protection or add exclusions to run it. SHA-256 hashes verify that files match a release; they do not establish that a file is trustworthy.

## Build from source

The downloadable bundle includes the launcher source, patched menu source, localization plugin, dictionary, and pinned packages in `source/`.

To build the launcher on Windows:

```powershell
cd source
powershell -NoProfile -File .\build.ps1
```

Output is written to `source/dist/`. Building does not install mods or run the resulting executable.

To rebuild the localization plugin, use `source/localization/build-locale.ps1 -GameDir <your-PEAK-folder>`. It requires the local game's managed assemblies and BepInEx dependencies. Game assemblies are not distributed. If you change a plugin, deliberately rebuild its package and update the catalog hash before rebuilding the launcher.

## Credits and third-party notices

- [PEAK Troll Mod](https://github.com/rdlawe15-cpu/PeakTrollMod) — upstream F7 menu.
- [PEAK Unlimited](https://thunderstore.io/c/peak/p/glarmer/PEAK_Unlimited/).
- [ItemInfo](https://thunderstore.io/c/peak/p/Yueby/ItemInfo/).
- [Start With Backpacks](https://thunderstore.io/c/peak/p/tony4twenty/Start_With_Backpacks/).
- [Healing Campfires](https://thunderstore.io/c/peak/p/tony4twenty/Healing_Campfires/).
- [PEAK](https://store.steampowered.com/app/3527290/PEAK/) — game artwork belongs to its respective owners.

The console skin was generated with image_gen and integrated with native launcher controls. The Teck logo was supplied by the project owner. See `ART-PROMPT.txt` and `MOD-SOURCES.md` in the release.

Third-party components retain their own licenses and notices; do not assume one project-wide license covers every bundled file. The new localization source includes its MIT license.

This is an unofficial community project. It is not affiliated with or endorsed by Nintendo, the PEAK developers, Steam, or the authors of the bundled mods. Famicom and other referenced names belong to their respective owners.
