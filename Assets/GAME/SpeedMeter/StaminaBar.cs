using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    private void Start()
    {
        slider.value = slider.maxValue;
    }
    public void UpdateFill(float value)
    {
        slider.value = value;
    }
}
