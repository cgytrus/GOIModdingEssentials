using BepInEx;

using GOIModApis;

using UnityEngine;
using UnityEngine.UI;

namespace GOIModLoader {
    [BepInProcess("GettingOverIt.exe")]
    [BepInPlugin("GOI.plugins.modLoader", "Mod Loader", "0.1.0")]
    [BepInDependency("GOI.plugins.modApis")]
    public class ModLoaderPlugin : BaseUnityPlugin {
        public void Awake() {
            Debug.Log("Mod Loader initialized");
            MainMenuApis.onMainMenuLoaded += (_, __) => AddModSettingsButton();
        }
        public void AddModSettingsButton() {
            Button button = MainMenuApis.AddMainMenuButton(3, "Mod Settings");
        }
    }
}
