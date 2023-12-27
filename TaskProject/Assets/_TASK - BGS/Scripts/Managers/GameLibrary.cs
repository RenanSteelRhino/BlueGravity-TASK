using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

namespace BGSTask
{
    //This class stores some frequently accessed information, like:
    // - What is the outifit ID that the player is wearing?
    // - Is the outifit store Open?
    // - Were is the player reference?
    public class GameLibrary : Singleton<GameLibrary>
    {
        [SerializeField] SO_SpriteBundle outfitBundle;

        #region Player Reference
            [SerializeField] GameObject playerObject;
            public GameObject GetPlayerObject()
            {
                return playerObject;
            }
        #endregion





        #region Outifit Store
            public List<SpriteBundle> ownedBundles = new();
        #endregion





        #region Outifit ID
            private int outifitID = 0;
            public int overrideOutifitID = 0;
    
            private void OnValidate() 
            {
                outifitID = overrideOutifitID;
            }
    
            //Base functionality to get and set the outifit ID
            //I use functions to be more organized and not generate a mess spaghethi code
            //This is way is easy to see were are the references and what class is requesting to Get or Set
            public void SetOutifit_ID(int newID) => outifitID = newID;
            public int GetOutifit_ID()
            {
                return outifitID;
            }
        #endregion


        private void Start()
        {
            outfitBundle = Resources.Load<SO_SpriteBundle>("SO_SpriteBundle");
            OutfitCollectionManager.OnNewOutfitEquip += SetOutifit_ID;
            UpdateCollectionList();
        }

        public void UpdateCollectionList()
        {
            ownedBundles = outfitBundle.outifitsBundles.Where(item => item.isBought == true).ToList();
        }

        private void OnDestroy() {
            OutfitCollectionManager.OnNewOutfitEquip -= SetOutifit_ID;
        }

        private void OnDisable() {
            OutfitCollectionManager.OnNewOutfitEquip -= SetOutifit_ID;
        }
    }
}
