using System.Linq;
using System;
using BepInEx;
using HarmonyLib;
using System.IO;
using UnityEngine;

namespace ValheimBrawler
{
    [BepInPlugin("com.github.ceko.ValheimBrawler", "ValheimBrawler", "1.0.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private static readonly Harmony harmony = new(typeof(Plugin).GetCustomAttributes(typeof(BepInPlugin), false)
            .Cast<BepInPlugin>()
            .First()
            .GUID);

        public static readonly string AssetPath = Path.Combine(Paths.PluginPath, "ValheimBrawler", "valheim-brawler");
                
        public static BepInEx.Logging.ManualLogSource Logger {
            get;
            private set;
        }

        private void Awake()
        {                                       
            Plugin.Logger = base.Logger;
            Logger.LogInfo(Paths.PluginPath);
            Logger.LogInfo("Applying patches.");            
            harmony.PatchAll();

            Logger.LogInfo($"Loading asset bundle at path {Plugin.AssetPath}");
        }

        private void OnDestroy()
        {
            Logger.LogInfo("Unapplying patches.");
            harmony.UnpatchAll();
        }
    }
}
