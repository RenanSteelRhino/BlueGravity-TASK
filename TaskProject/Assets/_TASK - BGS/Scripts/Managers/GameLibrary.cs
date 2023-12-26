using System;
using UnityEngine;

namespace BGSTask
{
    //This class stores some frequently accessed information, like:
    // - What is the outifit ID that the player is wearing?
    // - Is the outifit store Open?
    // - Were is the player reference?
    public class GameLibrary : Singleton<GameLibrary>
    {
        #region Player Reference
            [SerializeField] GameObject playerObject;
            public GameObject GetPlayerObject()
            {
                return playerObject;
            }
        #endregion





        #region Outifit Store
            private bool outifitStoreOpen;
            public void SetOutifitStore(bool value) => outifitStoreOpen = value;
            public bool IsOutifitStoreOpen()
            {
                return outifitStoreOpen;
            }
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
    }
}
