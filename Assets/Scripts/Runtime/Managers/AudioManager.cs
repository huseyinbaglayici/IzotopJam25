using Runtime.Extension;
using UnityEngine;

namespace Runtime.Managers
{
    public class AudioManager : MonoSingleton<AudioManager>
    {
        public AudioSource audioSource;
        public AudioClip walkingSound;
        public AudioClip guitarSound;
        public AudioClip bassGuitarSound;
        public AudioClip bassGuiltarSkill;
        public AudioClip drummerSound;
        public AudioClip drummerSkill;
        public AudioClip introSound;
        
        public void PlayMusic(AudioClip clip)
        {
            if (clip != null)
            {
                AudioSource.PlayClipAtPoint(clip, Vector3.zero);
            }
        }
    }
}