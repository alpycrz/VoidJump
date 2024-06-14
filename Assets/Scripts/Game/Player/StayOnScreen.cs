using Game.Screen;
using UnityEngine;

namespace Game.Player
{
    public class StayOnScreen : MonoBehaviour
    {
        private void Update()
        {
            if (transform.position.x < -ScreenCalculator.instance.Width)
            {
                Vector2 temp = transform.position;
                temp.x = -ScreenCalculator.instance.Width;
                transform.position = temp;
            }

            if (transform.position.x > ScreenCalculator.instance.Width)
            {
                Vector2 temp = transform.position;
                temp.x = ScreenCalculator.instance.Width;
                transform.position = temp;
            }

        }
    }
}
