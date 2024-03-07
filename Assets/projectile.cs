using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    [SerializeField] GameObject spark;
    [SerializeField] GameObject spark2;
    public shake sh;
    public ShooterScript ss;
    
    void Start()
    {
        sh = FindObjectOfType<shake>();
        ss = FindObjectOfType<ShooterScript>();
    }

    void Update()
    {
        Destroy(gameObject,3f);
    }
    void OnTriggerEnter (Collider coll)
    {
        if(coll.tag == "PlayerDMGReciever" )
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "parry")
        {
            Instantiate(spark2, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if(col.gameObject.name == "block")
        {
            sh.shakeDur++;
            
            Debug.Log("parry");
            ss.charge++;
            Instantiate(spark, transform.position, Quaternion.identity);
            
            Destroy(gameObject);
        }
        //if(col.gameObject.name == "parry")
        //{
         //   Debug.Log("block");
        //}
    }
    
}
