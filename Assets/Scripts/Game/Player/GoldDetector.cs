using Game.Environment;
using UnityEngine;

namespace Game.Player
{
    public class GoldDetector : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Foot"))
            {
                GetComponentInParent<Gold>().GoldOff();
                FindObjectOfType<Score>().EarnGold();
            }
        }
    }
}
