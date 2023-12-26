namespace BGSTask
{
    //This class stores some frequently accessed information, like:
    // - What is the outifit ID that the player is wearing?
    public class GameLibrary : Singleton<GameLibrary>
    {
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
    }
}
