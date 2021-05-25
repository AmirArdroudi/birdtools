using UnityEngine;

namespace BirdTools
{
    [CreateAssetMenu(fileName = "audioSO_title", menuName = "BirdTools/Variables/AudioClip")]
    public class AudioSO : AudioEvent
    {
        public AudioClip[] clips;
        [Range(0,1)] public float volume = 0.9f;
        [Range(0,1)] public float pitch = 0.9f;

        public override void Play(AudioSource source)
        {
            if (clips.Length == 0) return;

            source.clip = clips[Random.Range(0, clips.Length)];
            source.volume = Random.Range(volume, volume+0.2f);
            source.pitch =  Random.Range(pitch, pitch +0.1f);
            source.Play();
        }
        
    }
}