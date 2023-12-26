using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGSTask
{
    [CreateAssetMenu(fileName = "SO_SpriteBundle", menuName = "TaskProject/SO_SpriteBundle", order = 0)]
    public class SO_SpriteBundle : ScriptableObject 
    {
        //This list will store all outifits in the game
        //Here I can access the outifits by index
        public List<SpriteBundle> outifitsBundles = new();
    }
}
