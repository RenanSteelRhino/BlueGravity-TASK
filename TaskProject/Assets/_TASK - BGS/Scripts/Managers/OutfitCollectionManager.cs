using System;
using System.Collections.Generic;
using UnityEngine;

namespace BGSTask
{
    public class OutfitCollectionManager : Singleton<OutfitCollectionManager>
    {
        [SerializeField] GameObject collectionParentObj;
        [SerializeField] SO_SpriteBundle outfitBundleSO;

        [Header("UI")]
        [SerializeField] List<OutfitStore_Banner> bannerList = new();

        public static event Action<int> OnNewOutfitEquip;

        private void Start() 
        {
            if(outfitBundleSO == null)
                outfitBundleSO = Resources.Load<SO_SpriteBundle>("SO_SpriteBundle");

            //Link the function to the button
            //I prefere doind that way because you can cleary see the references
            //This is better then assigning the function in the button inspector, with can be easily missed
            //It also keep things organized and in one place only.

            SetupCollectionBanners();
        }

        private void Update() 
        {
            if(Input.GetKeyDown(InteractionManager.Instance.GetCollectionKey()) && collectionParentObj != null)
            {
                if(collectionParentObj.activeSelf)
                    collectionParentObj.SetActive(false);
                else
                {
                    //Update collection list
                    GameLibrary.Instance.UpdateCollectionList();
                    
                    //Setup the banners with the list
                    SetupCollectionBanners();

                    collectionParentObj.SetActive(true);
                }
            }
        }

        void SetupCollectionBanners()
        {   
            //Run the list of banners and setup their values such as icon, description, price etc
            for (int i = 0; i < bannerList.Count; i++)
            {
                if(i < GameLibrary.Instance.ownedBundles.Count)
                {
                    bannerList[i].SetupBanner(GameLibrary.Instance.ownedBundles[i]);
                    bannerList[i].gameObject.SetActive(true);

                    int newID = GameLibrary.Instance.ownedBundles[i].ID;

                    //Clear button, remove any duplicated calls
                    bannerList[i].GetButton().onClick.RemoveAllListeners();

                    bannerList[i].GetButton().onClick.AddListener(() => EquipOutfit(newID));
                }
                else
                {
                    bannerList[i].gameObject.SetActive(false);
                }
            }
        }

        private void EquipOutfit(int ID)
        {
            OnNewOutfitEquip.Invoke(ID);
        }
    }
}
