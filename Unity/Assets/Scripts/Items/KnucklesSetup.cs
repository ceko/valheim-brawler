using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ValheimBrawler.Unity.Items {

    public class KnucklesSetup : MonoBehaviour
    {        
        void Start()
        {
            // TODO: Move this somewhere else or only run it once per prefab type.
            var club = ObjectDB.instance.GetItemPrefab("Club").GetComponent<ItemDrop>();     
            // Big hack :(                   
            var knuckles = ObjectDB.instance.GetItemPrefab(this.name.Replace("(Clone)","").Trim()).GetComponent<ItemDrop>();
            
            knuckles.m_itemData.m_shared.m_hitEffect = club.m_itemData.m_shared.m_hitEffect;
            knuckles.m_itemData.m_shared.m_blockEffect = club.m_itemData.m_shared.m_blockEffect;
            knuckles.m_itemData.m_shared.m_triggerEffect = club.m_itemData.m_shared.m_triggerEffect;            
        }        
    }

}
