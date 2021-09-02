using UnityEngine;

namespace BirdTools
{
    [CreateAssetMenu(fileName = "audioSO_title", menuName = "BirdTools/Variables/AudioClip")]
    public class AudioSO : AudioEvent
    {
        public AudioClip[] clips;
        [MinMax(0, 1)] public RangedFloat volume;
        [MinMax(-3, 3)] public RangedFloat pitch;

        public override void Play(AudioSource source)
        {
            if (clips.Length == 0) return;

            source.clip = clips[Random.Range(0, clips.Length)];
            source.volume = Random.Range(volume.Min, volume.Max);
            source.pitch =  Random.Range(pitch.Min, pitch.Max);
            source.Play();
        }
        
    }
    
}