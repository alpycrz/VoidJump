using System;
using Game.Screen;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Player
{
    public class GameController : MonoBehaviour
    {
        public GameObject gameOverPanel;
        public GameObject joystick;
        public GameObject jumpButton;
        public GameObject board;
        public GameObject menuButton;
        public GameObject slider;

        private void Start()
        {
            gameOverPanel.SetActive(false);
            OpenUI();
        }

        public void EndGame()
        {
            gameOverPanel.SetActive(true);
            FindObjectOfType<Score>().GameOver();
            FindObjectOfType<PlayerMovement>().GameOver();
            FindObjectOfType<CameraMovement>().GameOver();
            CloseUI();
        }

        public void ReturnMainMenu()
        {
            SceneManager.LoadScene("Menu");
        }

        public void Replay()
        {
            SceneManager.LoadScene("Game");
        }

        void OpenUI()
        {
            joystick.SetActive(true);
            jumpButton.SetActive(true);
            board.SetActive(true);
            menuButton.SetActive(true);
            slider.SetActive(true);
        }

        void CloseUI()
        {
            joystick.SetActive(false);
            jumpButton.SetActive(false);
            board.SetActive(false);
            menuButton.SetActive(false);
            slider.SetActive(false);
        }
    }
}
