using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGSTask
{
    public class SwordTrigger : MonoBehaviour
    {
       private void OnTriggerEnter2D(Collider2D other) 
       {
            if(other.CompareTag("Monster"))
            {
                other.gameObject.GetComponent<MonsterLife>().TakeDamage();
            }
       }
    }
}
