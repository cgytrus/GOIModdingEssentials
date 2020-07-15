using System;

//using I2.Loc;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace ModApis {
    public static class SettingsMenuApis {
        public static event EventHandler onMainGameLoaded = delegate { };
        public static void OnMainGameLoaded() {
            InitGameLanguageBarButtons();
            onMainGameLoaded?.Invoke(null, null);
        }
        public static void InitGameLanguageBarButtons() {
            Transform basePanel = GameObject.Find("Canvas").transform.Find("InGame Menu").Find("Panel");

            Transform languageBar = basePanel.Find("LanguageBar");
            VerticalLayoutGroup languageBarLayout = languageBar.gameObject.AddComponent<VerticalLayoutGroup>();
            languageBarLayout.padding = new RectOffset(-110, 0, -16, 0);
            languageBarLayout.spacing = -25f;
            languageBarLayout.childControlHeight = true;
            languageBarLayout.childControlWidth = true;

            GameObject buttonRow = new GameObject("ButtonRow");
            RectTransform buttonRowTransform = buttonRow.AddComponent<RectTransform>();
            buttonRow.transform.SetParent(languageBar);
            buttonRowTransform.pivot = new Vector2(0f, 1f);
            buttonRowTransform.anchorMin = new Vector2(0f, 1f);
            buttonRowTransform.anchorMax = new Vector2(0f, 1f);
            buttonRow.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
            HorizontalLayoutGroup buttonsLayout = buttonRow.AddComponent<HorizontalLayoutGroup>();
            buttonsLayout.padding = new RectOffset(190, 0, 0, 0);
            buttonsLayout.childAlignment = TextAnchor.MiddleLeft;
        }
        public static Button AddInGameSettingsMenuButton(int positionIndex = 0, string text = "") {
            Transform basePanel = GameObject.Find("Canvas").transform.Find("InGame Menu").Find("Panel");
            GameObject originalButton = basePanel.Find("ButtonRow").Find("QuitButton").gameObject;

            GameObject newButton = UnityEngine.Object.Instantiate(originalButton);
            newButton.transform.SetParent(basePanel.Find("LanguageBar").Find("ButtonRow"), false);
            newButton.transform.SetSiblingIndex(positionIndex);

            TextMeshProUGUI textComponent = newButton.transform.Find("Text").GetComponent<TextMeshProUGUI>();
            textComponent.SetText(text);
            /*Localize localize = newButton.transform.Find("Text").GetComponent<Localize>();
            localize.SetTerm(text, text);*/

            Button button = newButton.GetComponent<Button>();
            button.onClick = new Button.ButtonClickedEvent();
            return button;
        }
    }
}
