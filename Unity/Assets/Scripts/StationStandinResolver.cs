using UnityEngine;

namespace ValheimBrawler.Unity {
    public class StationStandinResolver : CraftingStation
    {

        public enum Stations {        
            Workbench,
            Forge
        }
        
        [Header("Resolver settings")]
        [SerializeField]
        public Stations Station;
    
        public CraftingStation getConcreteStation() {
            switch(Station) {
                case Stations.Workbench:
                    // Wood arrows are made at the workbench
                    return ObjectDB.instance.GetRecipe(ObjectDB.instance.GetItemPrefab("ArrowWood").GetComponent<ItemDrop>().m_itemData).m_craftingStation;                    
                case Stations.Forge:
                    // Copper knife is made at the forge
                    return ObjectDB.instance.GetRecipe(ObjectDB.instance.GetItemPrefab("KnifeCopper").GetComponent<ItemDrop>().m_itemData).m_craftingStation;
                default:
                    throw new System.Exception("Unhandled station type.");
            }
        }

    }
}