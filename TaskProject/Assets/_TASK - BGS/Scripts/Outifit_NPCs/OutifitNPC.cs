using DG.Tweening;
using UnityEngine;

namespace BGSTask
{
    public class OutifitNPC : InteractableObject
    {
        //Used to start and to finish the dialog
        [SerializeField] InteractionTrigger trigger;

        [Space]
        [Header("Tween Options")]
        [SerializeField] GameObject InteractionButton;
        [SerializeField] float speed = 0.35f;
        [SerializeField] Ease easeType = Ease.OutCubic;
        bool insideInteraction;

        public override void OnInteract()
        {
            //Open store UI
            OutfitStoreManager.Instance.OpenStore();
            //Close dialog and interaction button
            OnTriggerExit();
        }

        private void Awake() 
        {
            trigger.onTriggerEnter += OnTriggerEnter;
            trigger.onTriggerExit += OnTriggerExit;
        }

        private void OnTriggerEnter()
        {
            //Enable the button and scale it down
            InteractionButton.SetActive(true);
            InteractionButton.transform.localScale = new Vector3(0, 0, 0);

            DialogController.Instance.StartDialog();

            //Do grow animation
            InteractionButton.transform.DOScale(new Vector3(1, 1, 1), speed).SetEase(easeType);
        }

        private void OnTriggerExit()
        {
            DialogController.Instance.StopDialog();

            //Do scale down animation
            InteractionButton.transform.DOScale(new Vector3(0, 0, 0), speed).SetEase(easeType).OnComplete( () => InteractionButton.SetActive(false) );
        }
    }
}
