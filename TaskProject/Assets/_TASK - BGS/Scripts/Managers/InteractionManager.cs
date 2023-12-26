using UnityEngine;

namespace BGSTask
{
    public class InteractionManager : Singleton<InteractionManager>
    {
        [SerializeField] KeyCode interactionKey = KeyCode.E;

        public KeyCode GetInteractionKey()
        {
            return interactionKey;
        }
    }
}
