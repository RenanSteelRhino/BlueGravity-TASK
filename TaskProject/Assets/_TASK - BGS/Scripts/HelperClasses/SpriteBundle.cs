using System;
using UnityEngine;

namespace BGSTask
{
    //Simple class to store sprites
    //Used to store sprites of the same set, like the blue suit outifit, and others.
    //Store all the info about the outfit
    
    [Serializable]
    public class SpriteBundle
    {
        public int ID;
        public Sprite northSprite;
        public Sprite southSprite;
        public Sprite sideSprite;
        [Space]
        public int price;
        [TextArea(1,3)] public string description;
        public string title;
        public bool isBought;
    }
}
