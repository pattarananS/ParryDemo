using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentHealth : MonoBehaviour
{
    public CentralModifier cm;
    public float hp;
    public float maxHp = 100;
    // Start is called before the first frame update
    void Start()
    {
        cm = FindObjectOfType<CentralModifier>();
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "parryslash" )
        {
            hp = hp - cm.parrySlashDamage;
        }

        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
