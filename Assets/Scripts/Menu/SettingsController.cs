using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    public class SettingsController : MonoBehaviour
    {
        public Button easyButton, mediumButton, hardButton;

        private void Start()
        {
            if (Options.GetValueEasy() == 1)
            {
                easyButton.interactable = false;
                mediumButton.interactable = true;
                hardButton.interactable = true;
            }

            if (Options.GetValueMedium() == 1)
            {
                easyButton.interactable = true;
                mediumButton.interactable = false;
                hardButton.interactable = true;
            }

            if (Options.GetValueHard() == 1)
            {
                easyButton.interactable = true;
                mediumButton.interactable = true;
                hardButton.interactable = false;
            }
        }

        public void ChoosenOption(string level)
        {
            switch (level)
            {
                case "easy":
                    Options.SetValueEasy(1);
                    Options.SetValueMedium(0);
                    Options.SetValueHard(0);
                    easyButton.interactable = false;
                    mediumButton.interactable = true;
                    hardButton.interactable = true;
                    break;

                case "medium":
                    Options.SetValueEasy(0);
                    Options.SetValueMedium(1);
                    Options.SetValueHard(0);
                    easyButton.interactable = true;
                    mediumButton.interactable = false;
                    hardButton.interactable = true;
                    break;

                case "hard":
                    Options.SetValueEasy(0);
                    Options.SetValueMedium(0);
                    Options.SetValueHard(1);
                    easyButton.interactable = true;
                    mediumButton.interactable = true;
                    hardButton.interactable = false;
                    break;
            }
        }

        public void MainMenu()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}