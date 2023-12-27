using System.Collections;
using UnityEngine;

namespace BGSTask
{
    public class ParticleToPool : MonoBehaviour
    {
        [SerializeField] ParticleSystem sys;

        public void ReturnParticleToPool()
        {
            sys.Play();
            StartCoroutine(Return());
        }

        IEnumerator Return()
        {
            yield return new WaitForSeconds(1);
            ParticlePoolManager.Instance.AddToPool(this.gameObject);
        }
    }
}
