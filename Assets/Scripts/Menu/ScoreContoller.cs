using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;



namespace Menu
{
    public class ScoreContoller : MonoBehaviour
    {
        [SerializeField] private TMP_Text easyScore, easyGold, mediumScore, mediumGold, hardScore, hardGold;

        private void Start()
        {
            easyScore.text = "Score: " + Options.GetValueEasyScore();
            easyGold.text = " X " + Options.GetValueEasyGold();

            mediumScore.text = "Score: " + Options.GetValueMediumScore();
            mediumGold.text = " X " + Options.GetValueMediumGold();

            hardScore.text = "Score: " + Options.GetValueHardScore();
            hardGold.text = " x " + Options.GetValueHardGold();
        }

        public void MainMenu()
        {
            SceneManager.LoadScene("Menu");
        }
    
    }
}
