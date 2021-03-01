using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ValheimBrawler.Unity {

    public class Database : MonoBehaviour 
    {
        [SerializeField]
        public List<GameObject> Items;

        [SerializeField]
        public List<RecipeExtension> Recipes;
    } 

}
