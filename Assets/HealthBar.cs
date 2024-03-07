using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    //[SerializeField] private Transform target;
    //[SerializeField] private Camera camera;

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue/maxValue;
    }
    // Update is called once per frame
    void Update()
    {

        //transform.rotation = camera.transform.rotation;
        //transform.position = target.position;
    }
}
