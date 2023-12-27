using System;
using System.IO;
using UnityEngine;

namespace BGSTask
{
    public class SaveManager : MonoBehaviour
    {
        [SerializeField] string saveName = "Save_01";
        public static event Action<SaveData> OnGameLoaded;

        private void Start() 
        {
            LoadGame();
        }

        private void OnApplicationQuit() 
        {
            SaveGame();
        }

        void SaveGame()
        {
            //Create a new data
            SaveData data = new();
            data.SetupData();

            //Transform class to Json string
            string dataToStore = JsonUtility.ToJson(data, true);

            //Store the string in the Player Prefs
            PlayerPrefs.SetString(saveName, dataToStore);
        }

        void LoadGame()
        {
            SaveData data = new();

            //Get string from player prefs, convert to SaveData type
            if(PlayerPrefs.HasKey(saveName))
                data = JsonUtility.FromJson<SaveData>(PlayerPrefs.GetString(saveName));

            //Send the data to anyone who needs
            OnGameLoaded.Invoke(data);
        }
    }
}
