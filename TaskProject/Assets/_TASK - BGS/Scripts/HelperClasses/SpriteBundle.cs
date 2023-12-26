using System;
using UnityEngine;

namespace BGSTask
{
    //Simple class to store sprites
    //Used to store sprites of the same set, like the blue suit outifit, and others.
    [Serializable]
    public class SpriteBundle
    {
        public Sprite northSprite;
        public Sprite southSprite;
        public Sprite sideSprite;
        public int price;
    }
}
