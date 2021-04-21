using BepInEx;
using HarmonyLib;
using JotunnLib.Entities;
using JotunnLib.Managers;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace valheimbrawler
{
    [BepInPlugin("zarboz.valheim-brawler", "valheim-brawler", "1.0.0")]
    [BepInDependency(JotunnLib.JotunnLib.ModGuid)]
    

    public class Mod : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony("zarboz.valheim-brawler");
        public static GameObject BMCestus { get; private set; }
        public static GameObject BCestus { get; private set; }
        public static GameObject ICestus { get; private set; }
        public static GameObject SCestus { get; private set; }
        public static GameObject SKnucks { get; private set; }
        public static GameObject WKnucks { get; private set; }


        private void Awake()
        {
            AssetBundle assetBundle = AssetBundle.LoadFromFile(Path.Combine(Paths.PluginPath, "valheim-brawler"));

            Mod.BMCestus = assetBundle.LoadAsset<GameObject>("BlackMetalCestus");
            Mod.BCestus = assetBundle.LoadAsset<GameObject>("BronzeCestus");
            Mod.ICestus = assetBundle.LoadAsset<GameObject>("IronCestus");
            Mod.SCestus = assetBundle.LoadAsset<GameObject>("SilverCestus");
            Mod.SKnucks = assetBundle.LoadAsset<GameObject>("StuddedKnuckles");
            Mod.WKnucks = assetBundle.LoadAsset<GameObject>("WoodKnuckles");

            ObjectManager.Instance.ObjectRegister += InitObjects;
            PrefabManager.Instance.PrefabRegister += RegisterPrefabs;
            
        }

        void OnDestroy()
        {
            harmony.UnpatchSelf();
          
        }

        private void RegisterPrefabs(object sender, EventArgs e)
        {
            PrefabManager.Instance.RegisterPrefab(Mod.BMCestus, "BlackMetalCestus");
            PrefabManager.Instance.RegisterPrefab(Mod.BCestus, "BronzeCestus");
            PrefabManager.Instance.RegisterPrefab(Mod.ICestus, "IronCestus");
            PrefabManager.Instance.RegisterPrefab(Mod.SCestus, "SilverCestus");
            PrefabManager.Instance.RegisterPrefab(Mod.SKnucks, "StuddedKnuckles");
            PrefabManager.Instance.RegisterPrefab(Mod.WKnucks, "WoodKnuckles");

        }

        private void InitObjects(object sender, EventArgs e)
        {

            
            ObjectManager.Instance.RegisterItem("BlackMetalCestus");
            ObjectManager.Instance.RegisterRecipe(new RecipeConfig()
            {

                Name = "Recipe_BlackMetalCestus",
                Item = "BlackMetalCestus",
                Amount = 1,
                MinStationLevel = 4,
                CraftingStation = "forge",
                RepairStation = "forge",
                Requirements = new PieceRequirementConfig[]
               {
                    new PieceRequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 5
                    },
                    new PieceRequirementConfig()
                    {
                        Item = "BlackMetal",
                        Amount = 10
                    },
                    new PieceRequirementConfig()
                    {
                        Item = "Iron",
                        Amount = 5
                    },
               },
            });

            ObjectManager.Instance.RegisterItem("BronzeCestus");
            ObjectManager.Instance.RegisterRecipe(new RecipeConfig()
            {

                Name = "Recipe_BronzeCestus",
                Item = "BronzeCestus",
                Amount = 1,
                MinStationLevel = 4,
                CraftingStation = "forge",
                RepairStation = "forge",
                Requirements = new PieceRequirementConfig[]
               {
                    new PieceRequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 5
                    },
                    new PieceRequirementConfig()
                    {
                        Item = "Bronze",
                        Amount = 10
                    },
                    new PieceRequirementConfig()
                    {
                        Item = "Tin",
                        Amount = 5
                    },
               },
            });

            ObjectManager.Instance.RegisterItem("IronCestus");
            ObjectManager.Instance.RegisterRecipe(new RecipeConfig()
            {

                Name = "Recipe_IronCestus",
                Item = "IronCestus",
                Amount = 1,
                MinStationLevel = 4,
                CraftingStation = "forge",
                RepairStation = "forge",
                Requirements = new PieceRequirementConfig[]
               {
                    new PieceRequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 5
                    },
                    new PieceRequirementConfig()
                    {
                        Item = "Iron",
                        Amount = 10
                    }
               },
            });

            ObjectManager.Instance.RegisterItem("SilverCestus");
            ObjectManager.Instance.RegisterRecipe(new RecipeConfig()
            {

                Name = "Recipe_SilverCestus",
                Item = "SilverCestus",
                Amount = 1,
                MinStationLevel = 4,
                CraftingStation = "forge",
                RepairStation = "forge",
                Requirements = new PieceRequirementConfig[]
               {
                    new PieceRequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 5
                    },
                    new PieceRequirementConfig()
                    {
                        Item = "Silver",
                        Amount = 15
                    }
               },
            });

            ObjectManager.Instance.RegisterItem("StuddedKnuckles");
            ObjectManager.Instance.RegisterRecipe(new RecipeConfig()
            {

                Name = "Recipe_StuddedKnuckles",
                Item = "StuddedKnuckles",
                Amount = 1,
                MinStationLevel = 2,
                CraftingStation = "forge",
                RepairStation = "forge",
                Requirements = new PieceRequirementConfig[]
               {
                    new PieceRequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 5
                    },
                    new PieceRequirementConfig()
                    {
                        Item = "BoneFragments",
                        Amount = 10
                    }
               },
            });

            ObjectManager.Instance.RegisterItem("WoodKnuckles");
            ObjectManager.Instance.RegisterRecipe(new RecipeConfig()
            {

                Name = "Recipe_StuddedKnuckles",
                Item = "StuddedKnuckles",
                Amount = 1,
                MinStationLevel = 2,
                CraftingStation = "forge",
                RepairStation = "forge",
                Requirements = new PieceRequirementConfig[]
               {
                    new PieceRequirementConfig()
                    {
                        Item = "LeatherScraps",
                        Amount = 5
                    },
                    new PieceRequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 5
                    }
               },
            });


        }
    }
}
