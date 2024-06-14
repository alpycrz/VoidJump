using UnityEngine;

namespace Game.Screen
{
    public class FullScreen : MonoBehaviour
    {
        private void Start()
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            Vector2 tempScale = transform.localScale;

            float spriteWidth = spriteRenderer.size.x;
            float screenHeight = Camera.main.orthographicSize * 2.0f;
            float screenWidth = screenHeight / UnityEngine.Screen.height * UnityEngine.Screen.width;

            tempScale.x = screenWidth / spriteWidth;
            transform.localScale = tempScale;

        }
    }
}
