using System;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace GOIModApis {
    public static class MainMenuApis {
        public static event EventHandler onMainMenuLoaded = delegate { };
        public static void OnMainMenuLoaded() {
            InitMainMenuLanguageBarButtons();
            onMainMenuLoaded?.Invoke(null, null);
        }
        public static Button AddMainMenuButton(int positionIndex = 0, string text = "") {
            GameObject originalButton = GameObject.Find("Canvas").transform.Find("Column").Find("Quit").gameObject;

            GameObject newButton = UnityEngine.Object.Instantiate(originalButton);
            newButton.transform.SetParent(originalButton.transform.parent, false);
            newButton.transform.SetSiblingIndex(positionIndex);

            TextMeshProUGUI textComponent = newButton.transform.Find("Text").GetComponent<TextMeshProUGUI>();
            textComponent.SetText(text);

            Button button = newButton.GetComponent<Button>();
            button.onClick = new Button.ButtonClickedEvent();
            return button;
        }
        public static void InitMainMenuLanguageBarButtons() {
            Transform basePanel = GameObject.Find("Canvas").transform;

            Transform languageBar = basePanel.Find("LanguageBar");
            VerticalLayoutGroup languageBarLayout = languageBar.gameObject.AddComponent<VerticalLayoutGroup>();
            languageBarLayout.padding = new RectOffset(0, 0, -8, 0);
            languageBarLayout.childControlHeight = true;
            languageBarLayout.childControlWidth = true;

            GameObject buttonRow = new GameObject("ButtonRow");
            RectTransform buttonRowTransform = buttonRow.AddComponent<RectTransform>();
            buttonRow.transform.SetParent(languageBar);
            buttonRow.transform.SetSiblingIndex(0);
            buttonRowTransform.pivot = new Vector2(0f, 0f);
            buttonRowTransform.anchorMin = new Vector2(0f, 0f);
            buttonRowTransform.anchorMax = new Vector2(0f, 0f);
            HorizontalLayoutGroup buttonsLayout = buttonRow.AddComponent<HorizontalLayoutGroup>();
            buttonsLayout.padding = new RectOffset(20, 0, 20, 0);
            buttonsLayout.childAlignment = TextAnchor.MiddleLeft;
        }
        public static Button AddMainMenuLanguageBarButton(int positionIndex = 0, string text = "") {
            Transform basePanel = GameObject.Find("Canvas").transform;
            GameObject originalButton = basePanel.Find("SettingsMenu").Find("SettingsMenuLeft").Find("ButtonRow").Find("Back").gameObject;

            GameObject newButton = UnityEngine.Object.Instantiate(originalButton);
            newButton.transform.SetParent(basePanel.Find("LanguageBar").Find("ButtonRow"), false);
            newButton.transform.SetSiblingIndex(positionIndex);

            TextMeshProUGUI textComponent = newButton.transform.Find("Text").GetComponent<TextMeshProUGUI>();
            textComponent.SetText(text);

            Button button = newButton.GetComponent<Button>();
            button.onClick = new Button.ButtonClickedEvent();
            return button;
        }
    }
}
