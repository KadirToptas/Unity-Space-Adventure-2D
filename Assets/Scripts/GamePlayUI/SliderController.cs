using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    private Slider slider;
    
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 1.0f;
    }


    public void SliderValue(int _maxValue , int _currentValue)
    {
        int sliderValue = _maxValue - _currentValue;
        slider.maxValue = _maxValue;
        slider.value = sliderValue;

    }
}
