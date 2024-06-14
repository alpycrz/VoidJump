using Game.Player;
using Game.Screen;
using Menu;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Environment
{
    public class Platform : MonoBehaviour
    {
        private PolygonCollider2D _polygonCollider2D;
        private float _randomSpeed;
        private float _min, _max;

        public bool Movement { get; set; }

        private void Start()
        {
            _polygonCollider2D = GetComponent<PolygonCollider2D>();
            
            if (Options.GetValueEasy() == 1)
            {
                _randomSpeed = Random.Range(0.2f, 0.8f);
            }

            if (Options.GetValueMedium() == 1)
            {
                _randomSpeed = Random.Range(0.5f, 1.0f);
            }

            if (Options.GetValueHard() == 1)
            {
                _randomSpeed = Random.Range(0.8f, 1.5f);
            }

            float objectWidth = _polygonCollider2D.bounds.size.x / 2;

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
            if (!Movement) return;
            float pingPongX = Mathf.PingPong(Time.time * _randomSpeed, _max - _min) + _min;
            Vector2 pingPong = new Vector2(pingPongX, transform.position.y);
            transform.position = pingPong;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Foot")) return;
            GameObject.FindGameObjectWithTag("Player").transform.parent = transform;
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerMovement>().JumpReset();
        }
    }
}
