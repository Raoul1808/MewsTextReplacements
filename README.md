# Mew's Text Replacements
 Source code for the Spin Rhythm XD Mod "Mew's Text Replacements".
 
 This mod allows users to replace a few in-game texts with their own custom ones.
 
 Features:
 
 - Customizable Game Over Screen ("Failed" text)
 - More to come!

## Usage
 This mod adds a new file in your Documents folder called `FailedTexts.txt`.
 
 All you have to do is to add your own text, with each entry on a separate line. It's as easy as that!
 
 Note: Changes apply only when the game opens. It doesn't update in-game.
 Second Note: Long Texts won't show entirely on screen. It *does* work, just mind your text length

## Building
 Building the mod requires you to own Spin Rhythm XD on Steam, [with the modloader installed as well](https://github.com/SRXDModdingGroup/SRXDBepInExInstaller/releases/latest).
 
 1. Install BepInEx (link above) on your Spin Rhythm XD installation
 2. Run Spin Rhythm XD
 3. Create a `Libs` folder right next to the mod's source code folder
 4. Copy these files from `<your SRXD installation>/BepInEx` to `Libs`:
    - `core/0Harmony.dll`
    - `core/BepInEx.Core.dll`
    - `core/BepInEx.IL2CPP.dll`
    - `core/UnhollowerBaseLib.dll`
    - `unhollowed/Assembly-CSharp.dll`
    - `unhollowed/Il2Cppmscorlib.dll`
    - `unity-libs/Unity.TextMeshPro.dll`
    - `unity-libs/UnityEngine.CoreModule.dll`
    - `unity-libs/UnityEngine.UI.dll`
 5. Compile the mod. It runs the game automatically if no errors occur.
 
 - If you get a post-build error, change this path `copy . . . "D\Steam\steamapps\common\Spin Rhythm XD\BepInEx\plugins"` to your Spin Rhythm XD/BepInEx/plugins path, or just remove the line (don't forget you have to copy manually the mod!)
 - If you have issues running the modloader after copying the dependencies, that's because you moved them instead of copying them. Either reinstall the modloader or fix your mistakes

## Roadmap
 - [x] Replace Game Over "Failed" Text
 - [ ] Make more customizable text
 - [ ] Replace more text
 - [ ] Make advanced text replacements more accessible
