using Cainos.PixelArtTopDown_Basic;
using UnityEngine;

namespace BGSTask
{
    //This class will handle the sprites for each direction that the player is facing
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteControllerForDirection : NeedOutfitSO
    {
        [SerializeField] SpriteRenderer mainRenderer;
        Vector2 dir;

        protected override void Awake() 
        {
            base.Awake();
            SaveManager.OnGameLoaded += LoadData;
        }

        private void LoadData(SaveData data)
        {
            for (int i = 0; i < bundle.outifitsBundles.Count; i++)
            {
                if(i == 0 )
                    bundle.outifitsBundles[i].isBought = true;
                else
                {
                    bundle.outifitsBundles[i].isBought = data.boughtOutfits[i];
                    Debug.Log(data.boughtOutfits[i]);
                }
            }

            OnNewOutfitEquip(data.outfitID);
        }

        private void Start() 
        {
            if(mainRenderer == null)
                mainRenderer = GetComponent<SpriteRenderer>();

            OutfitCollectionManager.OnNewOutfitEquip += OnNewOutfitEquip;
        }

        private void Update()
        {
            ChangeSprite();
        }

        //Change the player sprite based on the current movement direction
        void ChangeSprite()
        {
            dir = TopDownCharacterController.Instance.GetCurrentDirection();

            //Get the ID from library, to always be up to date with new outifits or changes
            int outifitID = GameLibrary.Instance.GetOutifit_ID();

            if(dir.x == 1)
            {
                mainRenderer.sprite = bundle.outifitsBundles[outifitID].sideSprite;
                mainRenderer.flipX = true;
            }
            else if(dir.x == -1)
            {
                mainRenderer.sprite = bundle.outifitsBundles[outifitID].sideSprite;
                mainRenderer.flipX = false;
            }

            if(dir.y == 1)
            {
                mainRenderer.sprite = bundle.outifitsBundles[outifitID].northSprite;
                mainRenderer.flipX = false;
            }
            else if(dir.y == -1)
            {
                mainRenderer.sprite = bundle.outifitsBundles[outifitID].southSprite;
                mainRenderer.flipX = false;
            }
        }

        public void OnNewOutfitEquip(int ID)
        {
            mainRenderer.sprite = bundle.outifitsBundles[ID].southSprite;
        }
    }
}
