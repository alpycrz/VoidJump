using UnityEngine;

namespace Game.Environment
{
    public class Gold : MonoBehaviour
    {
        [SerializeField] private GameObject gold = default;

        public void GoldOn() {gold.SetActive(true);}
        public void GoldOff() {gold.SetActive(false);}

    }
}
