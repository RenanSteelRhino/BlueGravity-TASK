using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGSTask
{
    public class OutfitStoreManager : Singleton<OutfitStoreManager>
    {
        [SerializeField] GameObject outfitStoreObj;

        public void OpenStore()
        {
            outfitStoreObj.SetActive(true);
            // stop player movement
        }

        public void CloseStore()
        {
            outfitStoreObj.SetActive(false);
        }
    }
}
