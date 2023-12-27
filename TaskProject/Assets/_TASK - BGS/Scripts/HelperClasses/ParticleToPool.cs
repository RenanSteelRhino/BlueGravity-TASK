using System.Collections;
using UnityEngine;

namespace BGSTask
{
    // Class made to retun the obj to its pool
    public class ParticleToPool : MonoBehaviour
    {
        [SerializeField] ParticleSystem sys;

        public void ReturnParticleToPool()
        {
            //Play the particle again when it is "spawned"
            sys.Play();
            //Return the particle to the pool after some time
            StartCoroutine(Return());
        }

        IEnumerator Return()
        {
            yield return new WaitForSeconds(1);
            ParticlePoolManager.Instance.AddToPool(this.gameObject);
        }
    }
}
