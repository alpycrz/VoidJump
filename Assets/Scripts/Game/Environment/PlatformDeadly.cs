using System;
using Game.Player;
using Game.Screen;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Environment
{
    public class PlatformDeadly : MonoBehaviour
    {
        private BoxCollider2D _boxCollider2D;
        private float _randomSpeed;
        private float _min, _max;

        public bool Movement { get; set; }

        private void Start()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _randomSpeed = Random.Range(0.5f, 1.0f);

            float objectWidth = _boxCollider2D.bounds.size.x / 2;

            if (transform.position.x > 0)
            {
                _min = objectWidth;
                _max = ScreenCalculator.instance.Width - objectWidth;
            }
            else
            {
                _min = -ScreenCalculator.instance.Width + objectWidth;
                _max = -objectWidth;
            }
        }
    
        private void Update()
        {
            if (Movement)
            {
                float pingPongX = Mathf.PingPong(Time.time * _randomSpeed, _max - _min) + _min;
                Vector2 pingPong = new Vector2(pingPongX, transform.position.y);
                transform.position = pingPong;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Foot")
            {
                FindObjectOfType<PlayerMovement>().GameOver();
                FindObjectOfType<GameController>().EndGame();
            }
        }
    }
}
