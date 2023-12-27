using System;
using GameEnums;
using TMPro;
using UnityEngine;

namespace BGSTask
{
    public class CurrencyManager : Singleton<CurrencyManager>
    {
        [SerializeField] int coinsAmount = 100;

        [Header("UI")]
        [SerializeField] TextMeshProUGUI coinsAmountText;

        // Linke the LoadData to the when the game is loadaded
        private void Awake() => SaveManager.OnGameLoaded += LoadData;

        private void LoadData(SaveData data)
        {
            coinsAmount = data.coinsAmount;
            UpdateCoinText();
        }

        public int GetCoins()
        {
            return coinsAmount;
        }

        public bool HasCoins(int amount)
        {
            return coinsAmount >= amount;
        }

        public void AddCoins(int amount = 1)
        {
            coinsAmount += amount;
            UpdateCoinText();
            SoundManager.Instance.SpawnAudioFor(Enum_AudioTypes.coins);
        }

        public void UseCoins(int amount)
        {
            coinsAmount -= amount;
            UpdateCoinText();
        }

        private void UpdateCoinText() => coinsAmountText.text = coinsAmount.ToString();
    }
}
