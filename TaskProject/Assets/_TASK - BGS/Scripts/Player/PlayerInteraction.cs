using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGSTask
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] LayerMask interactionLayer;

        private void Update() 
        {
            //Check for objects that can be interact with
            if(Input.GetKeyDown(InteractionManager.Instance.GetInteractionKey()))
                CheckForInteractableObjects();
        }

        void CheckForInteractableObjects()
        {
            RaycastHit2D hit = Physics2D.BoxCast(transform.position, new Vector2(1.6f ,1.6f),0, Vector2.zero, 1, interactionLayer);

            //If a object was hit, interact with it
            if(hit.transform == null) return;

            Debug.Log("You hit: " + hit.transform.name);
            hit.transform.GetComponent<InteractableObject>().OnInteract();
        }
    }
}
