using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentHealth : MonoBehaviour
{
    public CentralModifier cm;
    [SerializeField] float hp;
    [SerializeField] float maxHp = 100;
    [SerializeField] GameObject blood;

    [SerializeField] HealthBar hpBar;
    // Start is called before the first frame update
    void Start()
    {
        hpBar = GetComponentInChildren<HealthBar>();
        cm = FindObjectOfType<CentralModifier>();
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
        
        //REDUCE HEALTH WHEN COLLISION WITH SLASHES
        if(col.tag == "parryslash" )
        {
            Instantiate(blood, transform.position, Quaternion.identity);
            hp = hp - cm.parrySlashDamage;
        }

        //REDUCE HEALTH WHEN COLLISION WITH NORMAL ATTACK
        if(col.tag == "nmAttack" )
        {
            Instantiate(blood, transform.position, Quaternion.identity);
            Debug.Log("hit");
            hp = hp - cm.normalAttackDamage;
        }

        hpBar.UpdateHealthBar(hp, maxHp);

        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
