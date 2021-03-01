using UnityEngine;

namespace ValheimBrawler.Unity {
    public class ItemDropStandinResolver : ItemDrop
    {

        public enum Items {        
            Wood,
            BoneFragments,
            DeerHide,
            Bronze,
            Iron,
            Silver,
            BlackMetal,
            LinenThread,
            Chain,
            TrophyWolf
        }
        
        [Header("Resolver settings")]
        [SerializeField]
        public Items Item;
    
        public ItemDrop getConcreteItem() {            
            return ObjectDB.instance.GetItemPrefab(Item.ToString()).GetComponent<ItemDrop>();
        }

    }
}
