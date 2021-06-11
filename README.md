# Important note:
# This version of GOI modding essentials is currently in development, no fixes have been put in place that result in functionality for 1.6.

Stuff you need to start modding Getting Over It with BepInEx

# How to use
Download and install [BepInEx](https://bepinex.github.io/bepinex_docs/master/articles/user_guide/installation/index.html) first

Once you've done that, open the [Releases](https://github.com/cgytrus/GOIModdingEssentials/releases) tab, 
download the latest archive (GOIModdingEssentials.zip), 
extract the folder from it to `game's folder/BepInEx/plugins`,
download and install [BepInEx.ConfigurationManager](https://github.com/BepInEx/BepInEx.ConfigurationManager/releases) the same way 
(put the dll right into the `plugins` folder, no need to put it in another folder)

# How to commit
Clone the repository to your pc and add additional dlls to put into the Libs folder (get them in `game's folder/GettingOverIt_Data/Managed`):
- Assembly-CSharp.dll
- netstandard.dll
- UnityEngine.TextMeshPro.dll
- UnityEngine.CoreModule.dll
- UnityEngine.dll
- UnityEngine.TextRenderingModule.dll
- UnityEngine.UI.dll
