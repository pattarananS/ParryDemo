using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthBar : MonoBehaviour
{
    //PLAYER HEALTH BAR SLIDER
    [SerializeField] private Slider slider;

    ////
    public void UpdatePlayerHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue/maxValue;
    }
}
