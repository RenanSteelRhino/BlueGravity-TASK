using System;
using UnityEngine;

namespace BGSTask
{
    public class InteractionTrigger : MonoBehaviour
    {
        public event Action onTriggerEnter;
        public event Action onTriggerExit;

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if(!other.CompareTag("Player")) return;
            onTriggerEnter?.Invoke();
        }

        private void OnTriggerExit2D(Collider2D other) 
        {
            if(!other.CompareTag("Player")) return;
            onTriggerExit?.Invoke();
        }
    }
}
