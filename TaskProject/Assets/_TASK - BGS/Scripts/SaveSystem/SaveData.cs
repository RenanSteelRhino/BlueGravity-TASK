using System;
using UnityEngine;

namespace BGSTask
{
    [Serializable]
    public class SaveData
    {
        public int coinsAmount;
        public bool[] boughtOutfits = new bool[6];
        public int outfitID;
        public Vector2 playerPos;
        public int playerLayer;
        public int tutorialPhase;

        public void SetupData()
        {
            //Save coins
            coinsAmount = CurrencyManager.Instance.GetCoins();

            //Get the outfit list and get the values for bought items
            SO_SpriteBundle bundle = Resources.Load<SO_SpriteBundle>("SO_SpriteBundle");
            boughtOutfits = new bool[bundle.outifitsBundles.Count];

            //Setup list for bought itens
            for (int i = 0; i < bundle.outifitsBundles.Count; i++)
                boughtOutfits[i] = bundle.outifitsBundles[i].isBought;

            //Save with outfit is the player using
            outfitID = GameLibrary.Instance.GetOutifit_ID();

            //Save the last know player position
            playerPos = GameLibrary.Instance.GetPlayerObject().transform.position;

            //Save the last know layer in with the player was in (second or first floor)
            playerLayer = GameLibrary.Instance.GetPlayerObject().layer;

            //Save tutorial
            tutorialPhase = TutorialManager.Instance.tutorialPhase;
        }
    }
}
