using System.Collections.Generic;
using System.Linq;
using GameEnums;
using UnityEngine;

namespace BGSTask
{
    public class SoundManager : Singleton<SoundManager>
    {
        [SerializeField] GameObject audioSourcePrefab;
        [SerializeField] AudioClip popSoundForEnemies;
        [SerializeField] AudioClip popSoundForProps;
        [SerializeField] AudioClip coinSound;
        [SerializeField] AudioClip[] swordSounds;

        Queue<GameObject> audioPool = new();

        public void SpawnAudioFor(Enum_AudioTypes type)
        {
            GameObject newAudio = null;

            if(audioPool.Count > 0)
                newAudio = audioPool.Dequeue();
            else
                newAudio = Instantiate(audioSourcePrefab);
            
            newAudio.SetActive(true);

            AudioSource source = newAudio.GetComponent<AudioSource>();
            
            //Get the corret sound based on what is it for
            source.clip = type switch
            {
                Enum_AudioTypes.monster => popSoundForEnemies,
                Enum_AudioTypes.prop => popSoundForProps,
                Enum_AudioTypes.sword => swordSounds[Random.Range(0, swordSounds.Length)],
                Enum_AudioTypes.coins => coinSound,
            };

            source.pitch = Random.Range(0.9f, 1.1f);
            source.Play();
        }

        public void AddToPool(GameObject obj)
        {
            audioPool.Enqueue(obj);
            obj.SetActive(false);
        }

    }
}
