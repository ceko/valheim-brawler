using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using ValheimBrawler.Utils;
using GameConsole = Console;
using UnityEngine;
using System.Collections.Generic;

//TODO: override VisEquipment AttachBackItem to hide fist weapon on sheathe

namespace ValheimBrawler.Patches.Items
{
    
    public static class Database {
        
        public static void EnsureItemsExist() {
            try {
                foreach(GameObject resource in UnityBundle.Database.Items) {
                    if(ObjectDB.instance.GetItemPrefab(resource.name) == null) {
                        Plugin.Logger.LogInfo($"Adding item {resource.name}");                     
                        ObjectDB.instance.m_items.Add(resource);                                 
                        ObjectDB.instance.m_itemByHash.Add(StringExtensionMethods.GetStableHashCode(resource.name), resource);
                    }
                }
            }catch(Exception exc) {
                Plugin.Logger.LogError(exc);
            }
        }

        public static void EnsureRecipesExist() {
            try {
                if(ObjectDB.instance.m_recipes.Count() == 0) {
                    Plugin.Logger.LogInfo("Recipe database not yet setup, skipping initialization.");
                    return;
                }

                foreach(ValheimBrawler.Unity.RecipeExtension recipe in UnityBundle.Database.Recipes) {
                    if(ObjectDB.instance.GetRecipe(recipe.m_item.m_itemData) == null) {
                        Plugin.Logger.LogInfo($"Resolving recipe {recipe.name}");
                        recipe.ResolveStandins();
                        Plugin.Logger.LogInfo($"Adding recipe {recipe.name}");

                        ObjectDB.instance.m_recipes.Add(recipe);
                    }
                }
            }catch(Exception exc) {
                Plugin.Logger.LogError(exc);
            }
        }

    }

    
    [HarmonyPatch(typeof(ObjectDB), "Awake")]
    public static class EnsureObjectsOnAwake {
        public static void Postfix() {
            Database.EnsureItemsExist();
            Database.EnsureRecipesExist();

            var localizationDict = new Dictionary<string, string>() {
                {"item_knuckles_wood", "Wood Sprig"},
                {"item_knuckles_wood_description", "A small length of wood broken from a tree branch. It doesn't work very well."},

                {"item_knuckles_studded", "Bone Studded Knuckles"},
                {"item_knuckles_studded_description", "A length of deer hide studded with chipped bone. Hurt the enemy with the enemy."},

                {"item_bronze_cestus", "Bronze Cestus"},
                {"item_bronze_cestus_description", "A padded leather glove. It menaces with spikes of bronze."},

                {"item_iron_cestus", "Iron Cestus"},
                {"item_iron_cestus_description", "A leather wrap with a jagged chunk of iron attached at the end. Quite aerodynamic."},

                {"item_silver_cestus", "Silver Cestus"},
                {"item_silver_cestus_description", "A finely-tooled weapon made for killing undead. It's also good for digging troughs, perhaps useful to a ditcher."},

                {"item_blackmetal_cestus", "Black Metal Cestus"},
                {"item_blackmetal_cestus_description", "Jagged and cruel, it attacks by blunt and by blade. If only you could refine the design, maybe embed the blades directly into your fists. But no, black metal is poisonous."},
            };

            foreach(KeyValuePair<string, string> entry in localizationDict) {
                Localization.instance.AddWord(entry.Key, entry.Value);
            }            
        }
    }

    [HarmonyPatch(typeof(ObjectDB), "CopyOtherDB")]
    public static class EnsureObjectsOnCopy
    {
        public static void Postfix(ref Dictionary<int, GameObject> ___m_itemByHash)
        {
            Database.EnsureItemsExist();
            Database.EnsureRecipesExist();
        }
    }

    [HarmonyPatch(typeof(Humanoid), "SetupVisEquipment")]
    public static class SetupVisEquipment {
        public static void Prefix(ref Humanoid __instance) {
            // was used for debugging
        }
    }

    [HarmonyPatch(typeof(ZNetScene), "Awake")]
    public static class WoodKnucklesZNet
    {
        public static void Prefix(ref ZNetScene __instance)
        {
            try {
                Plugin.Logger.LogInfo("Adding items to the ZNetScene database");
                foreach(GameObject resource in UnityBundle.Database.Items) {
                     __instance.m_prefabs.Add(resource);  
                }                
            }catch(Exception exc) {
                Plugin.Logger.LogError(exc);
            }
        }

        public static void Postfix(ref ZNetScene __instance) {
            try {
                Plugin.Logger.LogInfo("Setting up fx.");

                foreach(GameObject resource in UnityBundle.Database.Items) {
                    var club = __instance.GetPrefab("Club").GetComponent<ItemDrop>();
                    var itemDrop = resource.GetComponent<ItemDrop>();

                    itemDrop.m_itemData.m_shared.m_hitEffect = club.m_itemData.m_shared.m_hitEffect;
                    itemDrop.m_itemData.m_shared.m_blockEffect = club.m_itemData.m_shared.m_blockEffect;
                    itemDrop.m_itemData.m_shared.m_triggerEffect = club.m_itemData.m_shared.m_triggerEffect;    
                    itemDrop.m_itemData.m_shared.m_trailStartEffect = club.m_itemData.m_shared.m_trailStartEffect;    
                }                
            }catch(Exception exc) {
                Plugin.Logger.LogError(exc);
            }
        }
    }

    
}
