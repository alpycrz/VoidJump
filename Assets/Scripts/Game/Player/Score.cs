using Menu;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Player
{
    public class Score : MonoBehaviour
    {
        private int _score;
        private int _highScore;
        private int _gold;
        private int _mostGold;
        private bool _getScore = true;

        [SerializeField] private Text scoreText = default;
        [SerializeField] private Text goldText = default;        
        [SerializeField] private Text gameOverScoreText = default;
        [SerializeField] private Text gameOverGoldText = default;

        private void Start()
        {
            goldText.text = "X" + _gold;
        }

        private void Update()
        {
            if (_getScore)
            {
                _score = (int)Camera.main.transform.position.y;
                scoreText.text = "Score: " + _score;
            }
        }

        public void EarnGold()
        {
            _gold++;
            goldText.text = "X" + _gold;
        }

        public void GameOver()
        {
            
            if (Options.GetValueEasyScore() == 1)
            {
                _highScore = Options.GetValueEasyScore();
                _mostGold = Options.GetValueEasyGold();

                if (_score > _highScore) Options.SetValueEasyScore(_score);
                if (_gold > _mostGold) Options.SetValueEasyGold(_gold);
            }
            
            if (Options.GetValueMediumScore() == 1)
            {
                _highScore = Options.GetValueMediumScore();
                _mostGold = Options.GetValueMediumGold();

                if (_score > _highScore) Options.SetValueMediumScore(_score);
                if (_gold > _mostGold) Options.SetValueMediumGold(_gold);
            }
            
            if (Options.GetValueHardScore() == 1)
            {
                _highScore = Options.GetValueHardScore();
                _mostGold = Options.GetValueHardGold();

                if (_score > _highScore) Options.SetValueHardScore(_score);
                if (_gold > _mostGold) Options.SetValueHardGold(_gold);
            }
            
            
            _getScore = false;
            gameOverScoreText.text = "Score: " + _score;
            gameOverGoldText.text = " X " + _gold;
        }
    }
}
