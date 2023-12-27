using System;
using UnityEngine;

namespace BGSTask
{
    [Serializable]
    public class SaveData
    {
        public int coinsAmount;
        public bool[] boughtOutfits = new bool[6];

        public void SetupData()
        {
            coinsAmount = CurrencyManager.Instance.GetCoins();
            Debug.Log($"Saved coins {coinsAmount}");

            SO_SpriteBundle bundle = Resources.Load<SO_SpriteBundle>("SO_SpriteBundle");
            boughtOutfits = new bool[bundle.outifitsBundles.Count];

            for (int i = 0; i < bundle.outifitsBundles.Count; i++)
            {
                boughtOutfits[i] = bundle.outifitsBundles[i].isBought;
            }

            Debug.Log($"Saved outfits {boughtOutfits[0]}-{boughtOutfits[1]}-{boughtOutfits[2]}-{boughtOutfits[3]}");
        }
    }
}
