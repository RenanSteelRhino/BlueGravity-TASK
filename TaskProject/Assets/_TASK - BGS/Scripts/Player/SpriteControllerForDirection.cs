using System.Collections;
using System.Collections.Generic;
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

        private void Start() 
        {
            if(mainRenderer == null)
                mainRenderer = GetComponent<SpriteRenderer>();
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
    }
}
