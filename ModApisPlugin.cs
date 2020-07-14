using BepInEx;

using UnityEngine;

namespace GOIModApis {
    [BepInProcess("GettingOverIt.exe")]
    [BepInPlugin("GOI.plugins.modApis", "Mod Apis", "0.1.0")]
    class ModApisPlugin : BaseUnityPlugin {
        public void Awake() {
            Debug.Log("Mod Apis initialized");
        }
    }
}
