<div align="center">

<h1>TECK · PEAK</h1>
<p><strong>A classic console. A new way to play.</strong></p>
<p>A Famicom-inspired Windows launcher for PEAK.<br>Curated mods, familiar controls, and Vietnamese / English support.</p>

<a href="https://github.com/DaoHao-dev/Teck-PEAK-MOD-VI-EN/releases/download/v1.0.0-beta.1/Teck-PEAK-VI-EN.zip"><img alt="Download for Windows" src="https://img.shields.io/badge/DOWNLOAD_FOR_WINDOWS-8B2638?style=for-the-badge&logo=windows&logoColor=FFF3DB"></a>
<a href="https://github.com/DaoHao-dev/Teck-PEAK-MOD-VI-EN/releases/tag/v1.0.0-beta.1"><img alt="Release v1.0.0 beta 1" src="https://img.shields.io/badge/RELEASE-v1.0.0--beta.1-D8BE8C?style=for-the-badge&labelColor=352B29&color=D8BE8C"></a>
<img alt="Vietnamese and English" src="https://img.shields.io/badge/LANGUAGE-VI_%2F_EN-345C51?style=for-the-badge&labelColor=352B29">

<p><a href="#quick-start">Quick start</a> · <a href="#the-mod-bundle">Mod bundle</a> · <a href="#languages">Languages</a> · <a href="#help--troubleshooting">Help</a> · <a href="#security--verification">Security</a></p>

<img src="docs/images/launcher.png" width="680" alt="Teck PEAK Launcher — realistic red and ivory Famicom console, PEAK cartridge and controller">

<p><sub>Famicom Edition · Borderless desktop launcher · Actual launcher preview</sub></p>
<p><kbd>F7</kbd> Mod menu &nbsp; <kbd>F10</kbd> Việt / English &nbsp; <kbd>F2</kbd> Lobby settings</p>

</div>

> [!IMPORTANT]
> **Beta release.** Extract the entire ZIP and keep <code>packages</code> beside <code>Teck-PEAK.exe</code>. The EXE is unsigned, and live in-game localization verification is still pending. See [security and verification](#security--verification).

---

## Made for your next climb

| 🎮 Familiar by design | 🌐 Two languages | 🧩 One curated bundle |
| :--- | :--- | :--- |
| A textured red-and-ivory console, PEAK cartridge and wired controller. | 1,325 offline translation entries. Press **F10** to switch; your choice is saved. | Select utilities, resolve dependencies and install verified package files. |

<details>
<summary><strong>Explore all features</strong></summary>

- **A console-shaped desktop launcher:** textured plastic, a PEAK cartridge, a wired controller, and a borderless window.
- **Mod installation and removal:** select supported mods, install their dependencies, and manage the files installed by Teck.
- **Vietnamese / English:** an offline localization layer with 1,325 dictionary entries. Switch languages with **F10** or the language button in the F7 menu.
- **An in-game F7 menu:** item spawning, player tools, teleport controls, recovery options, and configurable utilities, subject to each feature's requirements.
- **More players:** PEAK Unlimited provides configurable lobby capacity; the host must install it.
- **Package verification:** pinned SHA-256 hashes, installation backups, and rollback on supported write failures.

</details>

## Quick start

**Download → Extract → Select PEAK → Install mods → Play**

[**⬇ Download Teck PEAK for Windows — v1.0.0-beta.1**](https://github.com/DaoHao-dev/Teck-PEAK-MOD-VI-EN/releases/download/v1.0.0-beta.1/Teck-PEAK-VI-EN.zip)  
[Release notes](https://github.com/DaoHao-dev/Teck-PEAK-MOD-VI-EN/releases/tag/v1.0.0-beta.1) · [SHA-256 checksum](https://github.com/DaoHao-dev/Teck-PEAK-MOD-VI-EN/releases/download/v1.0.0-beta.1/Teck-PEAK-VI-EN-SHA256.txt) · [Hướng dẫn tiếng Việt](LOCALIZATION-VI-EN.md)

1. Download [**Teck-PEAK-VI-EN.zip**](https://github.com/DaoHao-dev/Teck-PEAK-MOD-VI-EN/releases/download/v1.0.0-beta.1/Teck-PEAK-VI-EN.zip).
2. Extract the entire archive into a new folder. Keep `Teck-PEAK.exe` beside the `packages` folder.
3. Close PEAK and open `Teck-PEAK.exe`.
4. Open **THIẾT LẬP** and select the folder containing `PEAK.exe` and `PEAK_Data`.
5. Choose your mods, save the selection, and click **CÀI MOD**.
6. Sign in to Steam and click **CHƠI PEAK**, or launch PEAK from your Steam Library.
7. Enter a lobby, press **F7**, and use **F10** to switch the supported mod text between Vietnamese and English.

Use this release when updating the bilingual bundle. Older Teck launchers do not include the localization layer.

<details>
<summary><strong>Before you install — requirements</strong></summary>

- Windows with .NET Framework 4.x.
- An installed copy of PEAK and Steam signed in to an account with access to the game.
- Permission to write to your PEAK installation folder.

</details>

<details>
<summary><strong>Console controls — POWER, RESET, A and B</strong></summary>

| Control | Action |
| --- | --- |
| **POWER** | Launch PEAK through Steam |
| **RESET** | Install or update the selected mods |
| **A** | Open settings, mod selection, and the game-folder picker |
| **B** | Open instructions and the session log |
| **− / ×** | Minimize / close |
| Drag an empty area of the console | Move the launcher |

The physical-looking **RESET** button installs mods; it does not reset game progress. The D-pad and SELECT/START details are decorative.

</details>

<details>
<summary><strong>In-game shortcuts and saved language settings</strong></summary>

| Key | Action |
| --- | --- |
| **F7** | Open PEAK Troll Mod |
| **F10** | Switch Vietnamese / English |
| **F2** | Open PEAK Unlimited settings |
| **F8** | Spectator free camera provided by PEAK Troll Mod |

These are the bundle's default bindings. Some can be reassigned in mod settings.

The language setting is saved in `BepInEx/config/teck.peak.bilingual.cfg`. Use `Language = vi` for Vietnamese or `Language = en` for English while the game is closed.

</details>

## The mod bundle

| Component | Version | Default | Purpose |
| --- | --- | --- | --- |
| PEAK Troll Mod | 0.5.0 + Teck compatibility patch | On | F7 menu, item and player tools, recovery, and utilities |
| PEAK Unlimited | 4.0.1 | On | Configurable player limit and multiplayer fixes |
| ItemInfo | 0.1.7 | On | Information about held items and their effects |
| Start With Backpacks | 1.1.0 | On | Starting backpack support |
| Healing Campfires | 4.5.1 | Off | Optional campfire healing and revival features |
| Teck PEAK Bilingual | 1.0.0 | Automatic dependency | Vietnamese / English display translation |

Required dependencies are included as separate ZIP packages. Available features and compatibility depend on the game version, host permissions, and the mods installed by other participants.

## Languages

**Tiếng Việt ⇄ English, without restarting the game.**

Press **F10** or select the language button at the top of the F7 menu. Vietnamese is the default; the selection persists.

This translates supported **mod UI**, not the entire PEAK base game. Unknown runtime text and unfamiliar item names keep their original language. Search items using their **English names**.

<details>
<summary><strong>What is translated — coverage and preserved data</strong></summary>

The localization layer handles supported mod menu captions, descriptions, tooltips, configuration labels, and mod-created item/status text. It covers the F7 menu, PEAK Unlimited, ItemInfo, and supported settings shown by the F7 configuration browser, including optional Healing Campfires.

This is **mod UI localization**, not a full translation of the PEAK base game. Configuration identifiers, item IDs, network messages, lobby codes, text input, and technical logs retain their original data. Unknown runtime text and unfamiliar item names fall back to the original language. Search for items using their original English names.

Some original mod names and technical terms are intentionally retained. Mods without their own visible menu do not gain a new menu through localization.

</details>

## Help & troubleshooting

Choose a topic to expand the instructions.

<details>
<summary><strong>Steam opens but PEAK does not start</strong></summary>

check Steam for login, update, or launch errors, then try **Library → PEAK → Play**. The launcher waits up to 30 seconds to detect a PEAK process; detecting a process does not confirm that the game reached its main menu. Launch diagnostics are saved to `%LOCALAPPDATA%\TeckPeak\launch.log`.

</details>

<details>
<summary><strong>Text is clipped or missing Vietnamese accents</strong></summary>

switch to English with **F10** and report the affected page with a screenshot.

</details>

<details>
<summary><strong>Another mod loader is already installed</strong></summary>

manage that installation with the tool that created it. Teck stops rather than overwriting an untracked loader.

</details>

<details>
<summary><strong>A package fails verification</strong></summary>

use a fresh copy of the published archive. Do not modify the pinned hashes to bypass the failure.

</details>

<details>
<summary><strong>Removing the bundle</strong></summary>

close PEAK, then use **THIẾT LẬP → Gỡ mod**. The launcher removes tracked files and restores available backups. Untracked files and game-generated configuration are preserved.

</details>

## Security & verification

The executable is **unsigned**. A Microsoft Defender custom directory scan of this build on **October 19, 2026** reported no threats. This is a point-in-time scan result, not a guarantee of safety or a complete security audit.

An earlier Teck build in this project's history was flagged as `Trojan:Win32/Bearfoos.A!ml`. That detection has **not** been established as a false positive. The result above applies to the current build only and does not clear earlier files. Packaging or reputation alone does not establish why a detection occurred.

If a security product flags a file, stop using it and retain the detection details for investigation. Do not disable protection or add exclusions to run it. SHA-256 hashes verify that files match a release; they do not establish that a file is trustworthy.

<details>
<summary><strong>Compatibility patch and automated test coverage</strong></summary>

The bundled F7 menu contains an **unofficial Teck compatibility patch**, assembly version `0.5.0.1`. It addresses a `CharacterData.userID` type mismatch by reading the current string-based ID and adds an initialization error guard. It is not an official release by the upstream author.

Automated checks cover translation logic, English pass-through, dynamic numbers, rich-text tags, multiline captions, package integrity, dependency selection, installation/update/removal, configuration preservation, and rollback behavior. Installer tests use fake game directories and do not execute fake game files.

**Every localized page, Vietnamese glyph, and gameplay feature has not yet been verified in a live PEAK lobby.** A static dictionary audit does not prove correct rendering in Unity. Game updates or additional mods may introduce incompatible or untranslated text. Use private sessions where participants agree to the enabled features.

See the release's `TEST-RESULTS.txt`, `LOCALE-TESTS.txt`, `TRANSLATION-AUDIT.tsv`, and `LOCALIZATION-VI-EN.md` for details.

</details>

## For developers

The release includes launcher source, the compatibility patch, localization source, the translation dictionary and test reports.

<details>
<summary><strong>Build from source</strong></summary>

The downloadable bundle includes the launcher source, patched menu source, localization plugin, dictionary, and pinned packages in `source/`.

To build the launcher on Windows:

```powershell
cd source
powershell -NoProfile -File .\build.ps1
```

Output is written to `source/dist/`. Building does not install mods or run the resulting executable.

To rebuild the localization plugin, use `source/localization/build-locale.ps1 -GameDir <your-PEAK-folder>`. It requires the local game's managed assemblies and BepInEx dependencies. Game assemblies are not distributed. If you change a plugin, deliberately rebuild its package and update the catalog hash before rebuilding the launcher.

</details>

<details>
<summary><strong>Credits, licenses and third-party notices</strong></summary>

- [PEAK Troll Mod](https://github.com/rdlawe15-cpu/PeakTrollMod) — upstream F7 menu.
- [PEAK Unlimited](https://thunderstore.io/c/peak/p/glarmer/PEAK_Unlimited/).
- [ItemInfo](https://thunderstore.io/c/peak/p/Yueby/ItemInfo/).
- [Start With Backpacks](https://thunderstore.io/c/peak/p/tony4twenty/Start_With_Backpacks/).
- [Healing Campfires](https://thunderstore.io/c/peak/p/tony4twenty/Healing_Campfires/).
- [PEAK](https://store.steampowered.com/app/3527290/PEAK/) — game artwork belongs to its respective owners.

The console skin was generated with image_gen and integrated with native launcher controls. The Teck logo was supplied by the project owner. See `ART-PROMPT.txt` and `MOD-SOURCES.md` in the release.

Third-party components retain their own licenses and notices; do not assume one project-wide license covers every bundled file. The new localization source includes its MIT license.

This is an unofficial community project. It is not affiliated with or endorsed by Nintendo, the PEAK developers, Steam, or the authors of the bundled mods. Famicom and other referenced names belong to their respective owners.

</details>

---

<div align="center">

<strong>Built for the climb. Styled for the memories.</strong><br>
<sub>Unofficial community project · No affiliation with Nintendo or the PEAK developers.</sub>

<p><a href="https://github.com/DaoHao-dev/Teck-PEAK-MOD-VI-EN/releases/download/v1.0.0-beta.1/Teck-PEAK-VI-EN.zip">Download</a> · <a href="https://github.com/DaoHao-dev/Teck-PEAK-MOD-VI-EN/releases">All releases</a> · <a href="https://github.com/DaoHao-dev/Teck-PEAK-MOD-VI-EN/issues">Report an issue</a> · <a href="#teck--peak">Back to top ↑</a></p>

</div>
