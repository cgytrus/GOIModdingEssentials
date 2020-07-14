using BepInEx;

using UnityEngine;
using UnityEngine.UI;

using GOIModApis;

namespace GOIModLoader {
    [BepInProcess("GettingOverIt.exe")]
    [BepInPlugin("GOI.plugins.modLoader", "Mod Loader", "0.1.0")]
    [BepInDependency("GOI.plugins.modApis")]
    public class ModLoaderPlugin : BaseUnityPlugin {
        public void Awake() {
            Debug.Log("Modloader loaded.");
        }
        public void Start() {
            Button button = MainMenuApis.AddMainMenuButton(3, "Mod Settings");
        }
    }
}
