using UnityEngine;

namespace BGSTask
{
    public class InteractionManager : Singleton<InteractionManager>
    {
        [SerializeField] KeyCode interactionKey = KeyCode.E;
        [SerializeField] KeyCode collectionKey = KeyCode.Tab;

        public KeyCode GetInteractionKey()
        {
            return interactionKey;
        }

        public KeyCode GetCollectionKey()
        {
            return collectionKey;
        }
    }
}
