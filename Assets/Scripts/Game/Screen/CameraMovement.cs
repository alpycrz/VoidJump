using Menu;
using UnityEngine;

namespace Game.Screen
{
    public class CameraMovement : MonoBehaviour
    {
        private float _speed;
        private float _acceleration;
        private float _maxSpeed;
        private bool _isMoving;
        void Start()
        {
            _isMoving = true;
            if (Options.GetValueEasy() == 1)
            {
                _speed = 0.3f;
                _acceleration = 0.03f;
                _maxSpeed = 1.5f; 
            }

            if (Options.GetValueMedium() == 1)
            {
                _speed = 0.5f;
                _acceleration = 0.05f;
                _maxSpeed = 2.0f;
            }

            if (Options.GetValueHard() == 1)
            {
                _speed = 0.8f;
                _acceleration = 0.08f;
                _maxSpeed = 2.5f;
            }
        }

        void Update()
        {
            if (_isMoving){CameraMoveUp();}
        }

        void CameraMoveUp()
        {
            transform.position += transform.up * (_speed * Time.deltaTime);
            _speed += _acceleration * Time.deltaTime;

            if (_speed > _maxSpeed)
            {
                _speed = _maxSpeed;
            }
        }

        public void GameOver()
        {
            _isMoving = false;
        }
    }
}
