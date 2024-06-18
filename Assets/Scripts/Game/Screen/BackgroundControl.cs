using UnityEngine;

namespace Game.Screen
{
    public class BackgroundControl : MonoBehaviour
    {
        private float _backgroundPos;
        private float _distance = 10.24f;

        void Start()
        {
            _backgroundPos = transform.position.y;
            FindObjectOfType<Planets>().PlacePlanet(_backgroundPos);
        }

        void Update()
        {
            if (_backgroundPos + _distance < Camera.main.transform.position.y)
            {
                BackgroundMaker();
            }
        }

        void BackgroundMaker()
        {
            _backgroundPos += (_distance * 2);
            FindObjectOfType<Planets>().PlacePlanet(_backgroundPos);
            Vector2 newPos = new Vector2(0, _backgroundPos);
            transform.position = newPos;
        }
    
    }
}
