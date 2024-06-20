using UnityEngine;

namespace Menu
{
    public class MusicController : MonoBehaviour
    {
        public static MusicController instance;
        private AudioSource _audioSource;

        private void Awake()
        {
            Singleton();
            _audioSource = GetComponent<AudioSource>();
        }

        void Singleton()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(instance);
            }
        }

        public void PlayMusic(bool play)
        {
            if (play)
            {
                if (!_audioSource.isPlaying)
                {
                    _audioSource.Play();
                }
                else
                {
                    if (_audioSource.isPlaying)
                    {
                        _audioSource.Stop();
                    }
                }
            }
        }
    }
}
