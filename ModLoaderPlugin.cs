using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using BepInEx;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Security.Permissions;

namespace GOIModLoader
{
    // The first attribute gives bepinex 3 parameters, 1 being the ID, 2 being the plugin name, and 3 being the version, ID being most important here.
    // You can read more information on formatting a plugin development environment at: https://bepinex.github.io/bepinex_docs/master/articles/dev_guide/plugin_tutorial/index.html
    // It is highly recommended you format the ID of all mods to something similar to: "GOI.plugins.x", as the ID is very important for things like dependencies and plugin loading duplicate checks run off of ID.
    [BepInPlugin("GOI.plugins.modloader", "Mod Loader Plugin", "1.0.0.0")]
    // This attribute only allows bepinex to load this plugin if the executable it is running on is named "GettingOverIt.exe".
    [BepInProcess("GettingOverIt.exe")]
    public class ModLoaderPlugin : BaseUnityPlugin
    {
        // Delegate
        // All code involving this delegate and its' events are currently unfinished, and are in experimentation
        public delegate void ModSelection();

        // Event
        public event ModSelection ModSelectClick;

        protected virtual void OnModSelectClick()
        {
            ModSelection handler = ModSelectClick;
            handler?.Invoke();
        }

        void Awake()
        {
            UnityEngine.Debug.Log("Modloader successfully loaded.");
            GenerateButton();
        }


        void Update()
        {
            
        }


        // Menu text Cheat sheet
        public TextMeshProUGUI style;

        // Menu button
        public GameObject ModSelect;

        // StandardFont
        public TMP_FontAsset StandardFont;

        // Main menu button generator
        public void GenerateButton()
        {
            TextMeshProUGUI[] array = Resources.FindObjectsOfTypeAll<TextMeshProUGUI>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].text == "Quit")
                {
                    this.style = array[i];
                    this.StandardFont = array[i].font;
                }
            }
            this.ModSelect = this.AddMenuItem("Select Mods");
            Color black = Color.black;
            black.a = 0f;
            this.ModSelect.GetComponent<TextMeshProUGUI>().color = black;
            GameObject gameObject = new GameObject("Mod Select Pivot", new Type[] { typeof(RectTransform) });
            gameObject.transform.parent = this.style.transform.parent.parent;
            gameObject.transform.SetSiblingIndex(0);
            this.ModSelect.transform.parent = gameObject.transform;
            this.CopyFrom(gameObject, this.style.gameObject);
            gameObject.GetComponent<RectTransform>().sizeDelta = this.style.transform.parent.GetComponent<RectTransform>().sizeDelta;
            this.ModSelect.transform.localPosition = new Vector3(this.ModSelect.GetComponent<RectTransform>().sizeDelta.x / 2f + 12f, -31.3f, 0f);
            Button button = this.ModSelect.AddComponent<Button>();
            button.onClick.AddListener(new UnityAction(this.ModSelectClick));
            button.colors = this.style.transform.parent.GetComponent<Button>().colors;
        }

        // Methods below this point are simply used for generating the main menu button

        private void CopyFrom(GameObject g, GameObject gameObject)
        {
            g.transform.position = gameObject.transform.position;
            g.transform.rotation = gameObject.transform.rotation;
            g.transform.localScale = gameObject.transform.localScale;
        }

        private GameObject AddMenuItem(string Text)
        {
            GameObject gameObject = new GameObject(Text);
            TextMeshProUGUI textMeshProUGUI = gameObject.AddComponent<TextMeshProUGUI>();
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(710.5f, 64f);
            textMeshProUGUI.text = Text;
            textMeshProUGUI.font = this.StandardFont;
            textMeshProUGUI.fontSize = 64f;
            textMeshProUGUI.color = Color.black;
            return gameObject;
        }
    }
}
