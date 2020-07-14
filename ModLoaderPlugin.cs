
using BepInEx;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace GOIModLoader {
    // The first attribute gives bepinex 3 parameters, 1 being the ID, 2 being the plugin name, and 3 being the version, ID being most important here.
    // You can read more information on formatting a plugin development environment at: https://bepinex.github.io/bepinex_docs/master/articles/dev_guide/plugin_tutorial/index.html
    // It is highly recommended you format the ID of all mods to something similar to: "GOI.plugins.x", as the ID is very important for things like dependencies and plugin loading duplicate checks run off of ID.
    [BepInPlugin("GOI.plugins.modloader", "Mod Loader Plugin", "1.0.0.0")]
    // This attribute only allows bepinex to load this plugin if the executable it is running on is named "GettingOverIt.exe".
    [BepInProcess("GettingOverIt.exe")]
    public class ModLoaderPlugin : BaseUnityPlugin {
        // Delegate
        // All code involving this delegate and its' events are currently unfinished, and are in experimentation
        public delegate void ModSelection();

        public event ModSelection ModSelectClick;

        protected virtual void OnModSelectClick() {
            ModSelection handler = ModSelectClick;
            handler?.Invoke();
        }

        public void Awake() {
            Debug.Log("Modloader successfully loaded.");
        }
        public void Start() {
            Button button = AddMainMenuButton(3, "Mod Settings");
        }

        public Button AddMainMenuButton(int positionIndex = 0, string text = "") {
            GameObject originalButton = GameObject.Find("Canvas").transform.Find("Column").Find("Quit").gameObject;

            GameObject newButton = Instantiate(originalButton);
            newButton.transform.SetParent(originalButton.transform.parent, false);
            newButton.transform.SetSiblingIndex(positionIndex);

            TextMeshProUGUI textComponent = newButton.transform.Find("Text").GetComponent<TextMeshProUGUI>();
            textComponent.SetText(text);

            Button button = newButton.GetComponent<Button>();
            button.onClick = new Button.ButtonClickedEvent();
            return button;
        }
    }
}
