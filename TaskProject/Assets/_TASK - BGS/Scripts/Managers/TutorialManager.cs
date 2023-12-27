using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace BGSTask
{
    public class TutorialManager : Singleton<TutorialManager>
    {
        public int tutorialPhase = 0;
        [SerializeField] GameObject wasdMovementBanner;
        [SerializeField] GameObject collectionTabBanner;

        private void Awake() 
        {
            SaveManager.OnGameLoaded += LoadData;
        }

        private void LoadData(SaveData data)
        {
            tutorialPhase = data.tutorialPhase;
            ShowTutorial();
        }

        async void ShowTutorial()
        {
            
            switch (tutorialPhase)
            {
                case 0:
                    wasdMovementBanner.SetActive(true);
                    collectionTabBanner.SetActive(false);
                break;

                case 1:
                    await Task.Delay(1000);
                    wasdMovementBanner.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack).OnComplete( () => wasdMovementBanner.SetActive(false));
                    await Task.Delay(1000);
                    collectionTabBanner.transform.localScale = Vector3.zero;
                    collectionTabBanner.SetActive(true);
                    collectionTabBanner.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutQuint);
                break;

                default:
                    wasdMovementBanner.SetActive(false);
                    collectionTabBanner.transform.DOScale(Vector3.zero, 0.25f).SetEase(Ease.InBack).OnComplete( () => collectionTabBanner.SetActive(false));
                break;
            }
        }

        private void Update() 
        {
            if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) && tutorialPhase == 0)
            {
                tutorialPhase = 1;
                ShowTutorial();
            }

            if(Input.GetKeyDown(InteractionManager.Instance.GetCollectionKey()) && tutorialPhase == 1)
            {
                tutorialPhase = 2;
                ShowTutorial();
            }
        }
    }
}
