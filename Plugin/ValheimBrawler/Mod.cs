using System.Linq;
using System;
using BepInEx;
using HarmonyLib;
using System.IO;
using UnityEngine;
using System.Reflection;

namespace ValheimBrawler
{
    [BepInPlugin("com.github.ceko.ValheimBrawler", "ValheimBrawler", "0.0.4")]
    public class Plugin : BaseUnityPlugin
    {
        private static readonly Harmony harmony = new(typeof(Plugin).GetCustomAttributes(typeof(BepInPlugin), false)
            .Cast<BepInPlugin>()
            .First()
            .GUID);

        public static readonly string FolderPath = Path.GetDirectoryName(Path.Combine(Assembly.GetAssembly(typeof(Plugin)).Location));
        public static readonly string AssetPath = Path.Combine(FolderPath, "valheim-brawler");
                
        public static BepInEx.Logging.ManualLogSource Logger {
            get;
            private set;
        }

        private void Awake()
        {                                       
            Plugin.Logger = base.Logger;                        
            
            Logger.LogInfo("Applying patches.");            
            harmony.PatchAll();

            Logger.LogInfo($"Asset bundle will be loaded at path {Plugin.AssetPath}");
        }

        private void OnDestroy()
        {
            Logger.LogInfo("Unapplying patches.");
            harmony.UnpatchSelf();
        }
    }
}
