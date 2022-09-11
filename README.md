
# Secret Of Mana Save Editor

As the project name implies, this is a Save Editor for the game Secret Of Mana.  Specifically, it's for the 3D remake available on Steam.  To use the editor you can clone the repository and build it with Visual Studio, or you can download the pre-compiled binaries here (you need both):

- TODO DLL Link
- TODO EXE Link

## Usage
There's no documentation available yet, but the 30 second introduction is: Clickable elements will show the Hand icon when you hover over them, and will allow you to change something about the thing you're hovering over (ie player name, weapon level, etc).  Non-clickable elements will show the default Arrow icon.

## Presets
There are _presets_ available to allow specific edits to be applied in bulk (accessed via the Gear icon).  **Minimum** and **Moderate** should be pretty safe to use, but **Maximum** will quite possibly break your game.  

I've started a playthrough that uses the Max preset, and quickly ran into two issues (that have been addressed in the Max preset so you shouldn't run into those issues), and there are possibly other issues waiting to be found.  I haven't had much time to continue my playthrough, so if you are feeling brave please give it a try and let me know if you run into any troubles.

## TODO List
- There's no app icon
- Ensure everything can be undone (ie adding and removing mana seeds, orbs, forgings, etc)
  - Can't take away a spirit once you add them
  - Can't take away girl or sprite once you add them
- Weapon images are always level 1 -- probably too much effort to grab all 72 variations though
- Finish a playthrough using the Max preset
- Lots of testing!

## Acknowledgements
- The character stats screen makes use of the [Experience FAQ](https://gamefaqs.gamespot.com/snes/588646-secret-of-mana/faqs/42174) created by Chris Castiglione (dinobotmaximized)
- Secret Of Mana is owned by Square Enix.  The images used in the editor are screenshots from the game, and not my personal creations
