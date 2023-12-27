using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGSTask
{   
    //Class made to revive and respawn monsters for the game loop
    public class MonsterSpawnManager : MonoBehaviour
    {
        [SerializeField] List<GameObject> monsters = new();

        private void Start() {
            StartCoroutine(ReviveMonsters());
        }

        //Revive a monster every 3 seconds.
        IEnumerator ReviveMonsters()
        {
            while (true)
            {
                yield return new WaitForSeconds(3);
                for (int i = 0; i < monsters.Count; i++)
                {
                    if(monsters[i].activeSelf == false)
                    {
                        //ACtivate monster again
                        monsters[i].SetActive(true);
                        //Reset the monster life
                        monsters[i].GetComponent<MonsterLife>().Revive();
                        //Reset the movement
                        monsters[i].GetComponent<MonsterMovement>().StartMovement();
                        break;
                    }
                }
            }
        }
    }
}
