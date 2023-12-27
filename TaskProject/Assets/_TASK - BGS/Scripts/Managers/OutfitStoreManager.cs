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
            if(outfitBundleSO == null)
                outfitBundleSO = Resources.Load<SO_SpriteBundle>("SO_SpriteBundle");

            //Link the function to the button
            //I prefere doind that way because you can cleary see the references
            //This is better then assigning the function in the button inspector, with can be easily missed
            //It also keep things organized and in one place only.
            closeButton.onClick.AddListener(CloseStore);

            SetupStoreBanners();
        }

        void SetupStoreBanners()
        {   
            //Run the list of banners and setup their values such as icon, description, price etc
            for (int i = 0; i < outfitBundleSO.outifitsBundles.Count; i++)
            {
                bannerList[i].SetupBanner(outfitBundleSO.outifitsBundles[i]);

                int newID = i;
                bannerList[i].GetButton().onClick.AddListener(() => BuyOutfit(newID));
            }
        }

        public void BuyOutfit(int ID)
        {
            Debug.Log($"Buying ID {ID}");

            SpriteBundle bundle = outfitBundleSO.outifitsBundles[ID];
            if(bundle == null) return;

            //Check if player has coins to buy
            if(!CurrencyManager.Instance.HasCoins(bundle.price)) return;

            //Spend the coins
            CurrencyManager.Instance.UseCoins(bundle.price);

            //Set bundle as bought
            bundle.isBought = true;

            //Update the list of owned outfits
            GameLibrary.Instance.UpdateCollectionList();
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
