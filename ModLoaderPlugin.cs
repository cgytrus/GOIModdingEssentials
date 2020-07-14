using BepInEx;
using BepInEx.Bootstrap;

using GOIModApis;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GOIModLoader {
    [BepInProcess("GettingOverIt.exe")]
    [BepInPlugin("GOI.plugins.modLoader", "Mod Loader", "0.1.0")]
    [BepInDependency("GOI.plugins.modApis")]
    [BepInDependency("com.bepis.bepinex.configurationmanager")]
    public class ModLoaderPlugin : BaseUnityPlugin {
        private ConfigurationManager.ConfigurationManager configurationManager;
        public void Awake() {
            configurationManager = (ConfigurationManager.ConfigurationManager)
                Chainloader.PluginInfos["com.bepis.bepinex.configurationmanager"].Instance;
            MainMenuApis.onMainMenuLoaded += (_, __) => AddModSettingsButton();
            Debug.Log("Mod Loader initialized");
        }
        public void AddModSettingsButton() {
            Button button = MainMenuApis.AddMainMenuButton(3, "Mods");
            button.onClick.AddListener(new UnityAction(() => configurationManager.DisplayingWindow = !configurationManager.DisplayingWindow));
        }
    }
}
