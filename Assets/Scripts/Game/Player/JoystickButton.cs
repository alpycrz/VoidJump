using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Player
{
    public class JoystickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [HideInInspector]
        public bool isPressed;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            isPressed = true;
        }
        
        public void OnPointerUp(PointerEventData eventData)
        {
            isPressed = false;
        }

    }
}
