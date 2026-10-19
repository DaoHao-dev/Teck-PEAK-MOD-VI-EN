# Teck PEAK — Tiếng Việt / English

Offline localization layer for the pinned Teck PEAK mod bundle.
Default: Vietnamese. Press F10 or use the Tiếng Việt / English button in F7.
F8 remains PEAK Troll Mod's spectator free-camera shortcut.
The language is saved in BepInEx/config/teck.peak.bilingual.cfg.

Supported: PEAK Troll Mod (Teck compatibility build), PEAK Unlimited 4.0.1,
ItemInfo 0.1.7 and the settings displayed by the F7 configuration browser,
including optional Healing Campfires 4.5.1 and Start With Backpacks 1.1.0.
Mods with no separate visible UI do not gain a new menu.

This translates display captions/tooltips and supported mod-created text,
not network commands, item identifiers, stored configuration keys or logs.
English mode passes the original text through. Unknown runtime text falls
back to the original language. It does not translate PEAK's entire base game.
Runtime item names are translated when present in the dictionary; names from
future updates or other mods may remain in English.

The dictionary and automated translation/installer tests are included.
Live Unity rendering, Vietnamese glyph coverage and every mod feature have
not yet been verified in a PEAK lobby. If there is a rendering problem,
switch to English; to remove the layer, remove its dependency from the
catalog and reinstall through the source build, or uninstall this Teck bundle.
Do not manually delete tracked files before a managed upgrade.

Implementation: scoped Harmony GUI caption hooks and mod-origin Text/TMP
setters. Text input fields are not patched. A copy of GUIContent/GUIStyle is
used so original content and shared styles are not mutated. New code is MIT.
