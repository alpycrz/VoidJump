using UnityEngine;

namespace Game.Screen
{
    public class ScreenCalculator : MonoBehaviour
    {
        public static ScreenCalculator instance;

        private float _height;
        private float _width;

        public float Height { get { return _height; } }
        public float Width { get { return _width; } }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != null)
            {
                Destroy(gameObject);
            }

            _height = Camera.main.orthographicSize;
            _width = _height * Camera.main.aspect;
        }
    }
}
