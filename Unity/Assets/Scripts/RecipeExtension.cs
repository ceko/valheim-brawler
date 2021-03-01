using UnityEngine;

namespace ValheimBrawler.Unity { 
    [CreateAssetMenu(fileName = "New Recipe", menuName = "Valheim/Recipe", order = 100)]
    public class RecipeExtension : Recipe { 

        public void ResolveStandins() {
            if(this.m_item is ItemDropStandinResolver) {
                this.m_item = ((ItemDropStandinResolver)this.m_item).getConcreteItem();
            }

            if(this.m_craftingStation && this.m_craftingStation is StationStandinResolver) {                
                this.m_craftingStation = ((StationStandinResolver)this.m_craftingStation).getConcreteStation();
            }            

            if(this.m_repairStation && this.m_repairStation is StationStandinResolver) {                
                this.m_repairStation = ((StationStandinResolver)this.m_repairStation).getConcreteStation();
            }            

            foreach(Piece.Requirement req in this.m_resources) {
                if(req.m_resItem is ItemDropStandinResolver) {
                    req.m_resItem = ((ItemDropStandinResolver)req.m_resItem).getConcreteItem();
                }
            }
        }

    }
}