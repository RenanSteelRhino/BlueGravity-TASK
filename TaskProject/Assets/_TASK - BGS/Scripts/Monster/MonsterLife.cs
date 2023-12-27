using GameEnums;
using UnityEngine;

namespace BGSTask
{
    public class MonsterLife : MonoBehaviour
    {
        [SerializeField] int life = 1;
        [SerializeField] int rewardCoins = 1;
        [SerializeField] bool isProp;

        void OnDeath()
        {
            ParticlePoolManager.Instance.SpawnDeathParticle(transform.position);
            CurrencyManager.Instance.AddCoins(rewardCoins);
            FeedbackTextManager.Instance.SpawnCoinText(transform.position, $"+ {rewardCoins}");

            //Play Audio for the kill
            if(isProp)
                SoundManager.Instance.SpawnAudioFor(Enum_AudioTypes.prop);
            else
                SoundManager.Instance.SpawnAudioFor(Enum_AudioTypes.monster);

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
