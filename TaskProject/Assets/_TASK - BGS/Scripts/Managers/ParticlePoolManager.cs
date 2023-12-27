using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace BGSTask
{
    public class ParticlePoolManager : Singleton<ParticlePoolManager>
    {
        Queue<GameObject> particlePool = new();
        [SerializeField] GameObject deathParticle;

        public void SpawnDeathParticle(Vector3 posToSpawn)
        {
            //Create a new particle or get one from the pool
            GameObject obj;
            if(particlePool.Count <= 0)
                obj = Instantiate(deathParticle);
            else
                obj = particlePool.Dequeue();

            //Set to the new pos
            obj.transform.position = posToSpawn;
            //Ask the particle to mind its own buisiness and return to pool after a time
            obj.GetComponent<ParticleToPool>().ReturnParticleToPool();
        }

        public void AddToPool(GameObject obj)
        {
            particlePool.Enqueue(obj);
        }
    }
}
