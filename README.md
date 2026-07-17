# Recall Mod

Adds a **Recall Item** to Valheim — a consumable item that teleports you back to your spawn point after a short channel, similar to the recall mechanic found in MOBA games.

## Features

- **Recall Potion**: a stackable consumable item.
- Using it starts a **6 second channel**. Stay put and stay safe — taking damage during the channel cancels the recall.
- On successful channel completion, teleports you to your bed spawn point (or a fallback location if you haven't slept in a bed yet).
- Crafted at the Workbench.

## Recipe

| Material | Amount |
|---|---|
| Greydwarf Eye | 5 |
| Surtling Core | 2 |
| Fine Wood | 1 |

Crafting station: **Workbench**

## Requirements

- [BepInExPack Valheim](https://thunderstore.io/c/valheim/p/denikson/BepInExPack_Valheim/)
- [Jötunn, the Valheim Library](https://thunderstore.io/c/valheim/p/ValheimModding/Jotunn/)

Both are installed automatically if you use a mod manager (r2modman, Thunderstore Mod Manager, or Vortex).

## Installation

### With a mod manager (recommended)
Install through r2modman or the Thunderstore Mod Manager — dependencies will be resolved automatically.

### Manual
1. Install BepInExPack Valheim and Jötunn first.
2. Extract this mod's contents into `BepInEx/plugins/RecallMod/`.
3. Launch the game.

## Known limitations

- No visual channel bar yet — cancellation is silent aside from a center-screen message.
- No configurable channel time or recipe (planned for a future update via BepInEx config).

## Compatibility

Works in multiplayer. Every player needs the mod installed; dedicated servers need it too if item validation is enforced.

## Feedback

Found a bug or have a suggestion? Open an issue on the mod's repository or leave a comment on the Thunderstore page.
