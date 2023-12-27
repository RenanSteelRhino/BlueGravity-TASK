using UnityEngine;

namespace BGSTask
{
    public class MonsterLife : MonoBehaviour
    {
        [SerializeField] int life = 1;
        [SerializeField] int rewardCoins = 1;

        void OnDeath()
        {
            ParticlePoolManager.Instance.SpawnDeathParticle(transform.position);
            CurrencyManager.Instance.AddCoins(rewardCoins);
            FeedbackTextManager.Instance.SpawnCoinText(transform.position, $"+ {rewardCoins}");
            gameObject.SetActive(false);
        }

        public void TakeDamage()
        {
            life -= 1;

            if(life <= 0)
                OnDeath();
        }

        public void Revive()
        {
            life = 1;
        }
    }
}
