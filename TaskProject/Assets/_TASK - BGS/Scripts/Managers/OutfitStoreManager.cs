using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BGSTask
{
    public class OutfitStoreManager : Singleton<OutfitStoreManager>
    {
        [SerializeField] GameObject outfitStoreObj;
        [SerializeField] SO_SpriteBundle outfitBundleSO;

        [Header("UI")]
        [SerializeField] Button closeButton;
        [SerializeField] List<OutfitStore_Banner> bannerList = new();
        

        //Events
        public static event Action OnStoreOpen;
        public static event Action OnStoreClose;

        private void Start() 
        {
            //Link the function to the button
            //I prefere doind that way because you can cleary see the references
            //This is better then assigning the function in the button inspector, with can be easily missed
            //It also keep things organized and in one place only.
            closeButton.onClick.AddListener(CloseStore);
        }

        void SetupStoreBanners()
        {   
            //Run the list of banners and setup their values such as icon, description, price etc
            for (int i = 0; i < bannerList.Count; i++)
            {
                bannerList[i].SetupBanner(outfitBundleSO.outifitsBundles[i]);
                bannerList[i].GetButton().onClick.AddListener(() => BuyOutfit(i));

            }
        }

        public void BuyOutfit(int ID)
        {
            SpriteBundle bundle = outfitBundleSO.outifitsBundles[ID];
            if(bundle == null) return;
            //Check for coins
            // if(!CurrencyManager.Instance.HasCoins(bundle.price)) return
            bundle.isBought = true;

            //If the bundle is aready on the owned list, return
            if(GameLibrary.Instance.ownedBundles.Contains(bundle)) return;

            //Add the bundle to the owned list
            GameLibrary.Instance.ownedBundles.Add(bundle);
        }

        public void OpenStore()
        {
            //Open the store
            outfitStoreObj.SetActive(true);
            //Send event to listeners
            OnStoreOpen?.Invoke();
        }

        public void CloseStore()
        {
            //Close store
            outfitStoreObj.SetActive(false);
            //Send event to listeners
            OnStoreClose?.Invoke();
        }
    }
}
