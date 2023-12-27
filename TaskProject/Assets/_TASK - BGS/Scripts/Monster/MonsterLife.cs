using UnityEngine;

namespace BGSTask
{
    public class MonsterLife : MonoBehaviour
    {
        [SerializeField] int life = 1;


        void OnDeath()
        {
            //Play vfx
            CurrencyManager.Instance.AddCoins();
            Destroy(gameObject);
        }
    }
}
