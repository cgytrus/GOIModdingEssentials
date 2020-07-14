using BepInEx;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace GOIModApis {
    [BepInProcess("GettingOverIt.exe")]
    [BepInPlugin("GOI.plugins.modApis", "Mod Apis", "0.1.0")]
    class ModApisPlugin : BaseUnityPlugin {
        public void Awake() {
            Debug.Log("Mod Apis initialized");
            SceneManager.sceneLoaded += (Scene scene, LoadSceneMode mode) => {
                if(scene.name == "Loader") {
                    MainMenuApis.OnMainMenuLoaded();
                }
                else if(scene.name == "Mian") {
                    SettingsMenuApis.OnMainGameLoaded();
                }
            };
        }
    }
}
