using System.Collections.Generic;
using UnityEngine;

namespace BGSTask
{
    public class FeedbackTextManager : Singleton<FeedbackTextManager>
    {
        [SerializeField] GameObject feedbackPrefab;
        Queue<GameObject> coinsPool = new();

        public void SpawnCoinText(Vector3 position, string text)
        {
            GameObject createdObj = null;

            if(coinsPool.Count > 0)
                createdObj = coinsPool.Dequeue();
            else
                createdObj = Instantiate(feedbackPrefab);

            createdObj.transform.position = position;
            createdObj.SetActive(true);
            createdObj.GetComponent<FeedbackCoin>().SetupCoin(text);

        }

        public void AddToPool(GameObject obj)
        {
            coinsPool.Enqueue(obj);
            obj.SetActive(false);
        }
    }
}
