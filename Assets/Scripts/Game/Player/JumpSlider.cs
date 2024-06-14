using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Player
{
    public class JumpSlider : MonoBehaviour
    {
        private Slider _slider;

        private void Start()
        {
            _slider = GetComponent<Slider>();
            _slider.value = 1f;
        }

        public void SliderValue(int maxValue, int currValue)
        {
            int sliderValue = maxValue - currValue;
            _slider.maxValue = maxValue;
            _slider.value = sliderValue;
        }
    }
}
