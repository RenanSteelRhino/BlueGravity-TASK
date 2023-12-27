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

        public void TakeDamage()
        {
            life -= 1;

            if(life <= 0)
                OnDeath();
        }
    }
}
