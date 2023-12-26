using UnityEngine;

namespace BGSTask
{   
    //Simple class that gives access to the outifit bundle list.
    public class NeedOutfitSO : MonoBehaviour
    {
        protected SO_SpriteBundle bundle;

        protected virtual void Awake()
        {
            bundle = Resources.Load<SO_SpriteBundle>("SO_SpriteBundle");
        }
    }
}
