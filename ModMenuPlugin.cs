using BepInEx;
using BepInEx.Bootstrap;

using ModApis;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ModLoader {
    [BepInProcess("GettingOverIt.exe")]
    [BepInPlugin("GOI.plugins.modMenu", "Mod Menu", "0.1.0")]
    [BepInDependency("GOI.plugins.modApis")]
    [BepInDependency("com.bepis.bepinex.configurationmanager")]
    public class ModMenuPlugin : BaseUnityPlugin {
        private ConfigurationManager.ConfigurationManager configurationManager;
        public void Awake() {
            configurationManager = (ConfigurationManager.ConfigurationManager)
                Chainloader.PluginInfos["com.bepis.bepinex.configurationmanager"].Instance;
            MainMenuApis.onMainMenuLoaded += (_, __) => AddModsMainMenuButton();
            SettingsMenuApis.onMainGameLoaded += (_, __) => AddModsPauseMenuButton();
            Debug.Log("Mod Loader initialized");
        }
        public void AddModsMainMenuButton() {
            Button button = MainMenuApis.AddMainMenuButton(3, "Mods");
            button.onClick.AddListener(new UnityAction(() => configurationManager.DisplayingWindow = !configurationManager.DisplayingWindow));
        }
        public void AddModsPauseMenuButton() {
            Button button = SettingsMenuApis.AddInGameSettingsMenuButton(0, "Mods");
            button.onClick.AddListener(new UnityAction(() => configurationManager.DisplayingWindow = !configurationManager.DisplayingWindow));
        }
    }
}
