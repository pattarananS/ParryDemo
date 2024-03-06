using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public AgentHealth agentHp; 
    //[SerializeField] private Transform target;
    //[SerializeField] private Camera camera;

    void Start()
    {
        agentHp = FindObjectOfType<AgentHealth>();
    }
    // Update is called once per frame
    void Update()
    {
        slider.value = agentHp.hp / agentHp.maxHp;

        //transform.rotation = camera.transform.rotation;
        //transform.position = target.position;
    }
}
