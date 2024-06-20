using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private Sprite[] musicIcons = default;
        [SerializeField] private Button musicButton = default;

        private void Start()
        {
            if (Options.HadSave() == false) Options.SetValueEasy(1);
            if (Options.isMusicOn() == false) Options.SetMusicOn(1);
            CheckMusicSetting();
        }

        public void PlayGame()
        {
            SceneManager.LoadScene("Game");
        }
        public void HighScore()
        {
            SceneManager.LoadScene("HighScore");
        }
        public void Settings()
        {
            SceneManager.LoadScene("Settings");
        }

        public void Music()
        {
            if (Options.GetMusicOn() == 1)
            {
                Options.SetMusicOn(0);
                MusicController.instance.PlayMusic(false);
                musicButton.image.sprite = musicIcons[0];
            }
            else
            { 
                Options.SetMusicOn(1);
                MusicController.instance.PlayMusic(true);
                musicButton.image.sprite = musicIcons[1];
            }
        }

        public void CheckMusicSetting()
        {
            if (Options.GetMusicOn() == 1)
            {
                musicButton.image.sprite = musicIcons[1];
                MusicController.instance.PlayMusic(true);
            }
            else
            {
                musicButton.image.sprite = musicIcons[0];
                MusicController.instance.PlayMusic(false);
            }
        }

    }
}
