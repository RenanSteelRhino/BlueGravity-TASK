using System.Collections;
using UnityEngine;

namespace BGSTask
{
    //Class made to retunr the audio source back to the pool
    public class SoundToPool : MonoBehaviour
    {
        private void Start() 
        {
            StartCoroutine(Return());
        }

        IEnumerator Return()
        {
            yield return new WaitForSeconds(1);
            SoundManager.Instance.AddToPool(this.gameObject);
        }
    }
}
