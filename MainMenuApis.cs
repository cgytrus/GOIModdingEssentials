﻿using System;

//using I2.Loc;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace ModApis {
    public static class MainMenuApis {
        public static event EventHandler onMainMenuLoaded = delegate { };
        public static void OnMainMenuLoaded() {
            onMainMenuLoaded?.Invoke(null, null);
        }
        public static Button AddMainMenuButton(int positionIndex = 0, string text = "") {
            GameObject originalButton = GameObject.Find("Canvas").transform.Find("Column").Find("Quit").gameObject;

            GameObject newButton = UnityEngine.Object.Instantiate(originalButton);
            newButton.transform.SetParent(originalButton.transform.parent, false);
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
