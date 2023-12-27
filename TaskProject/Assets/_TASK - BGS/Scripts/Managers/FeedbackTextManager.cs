using System.Collections.Generic;
using UnityEngine;

namespace BGSTask
{
    //Create the feedback texts on the game world
    public class FeedbackTextManager : Singleton<FeedbackTextManager>
    {
        [SerializeField] GameObject feedbackPrefab;
        Queue<GameObject> coinsPool = new();

        public void SpawnCoinText(Vector3 position, string text)
        {
            GameObject createdObj = null;

            //Create a new object or get one from pool
            if(coinsPool.Count > 0)
                createdObj = coinsPool.Dequeue();
            else
                createdObj = Instantiate(feedbackPrefab);

            //Set text position
            createdObj.transform.position = position;
            createdObj.SetActive(true);
            //Setup text informartion
            createdObj.GetComponent<FeedbackCoin>().SetupCoin(text);

        }

        public void AddToPool(GameObject obj)
        {
            coinsPool.Enqueue(obj);
            obj.SetActive(false);
        }
    }
}
