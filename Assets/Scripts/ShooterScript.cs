using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    public GameObject slash;
    public GameObject chargedParticle;
    public Transform cam;
    public float charge = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ParryShooter();
        this.transform.rotation = cam.transform . rotation;
        if(charge >=1)
        {
            chargedParticle.SetActive(true);
        }else
        {
            chargedParticle.SetActive(false);
        }
    }
    void ParryShooter()
    {
        if(Input.GetKeyDown("mouse 0") && charge >= 1)
          {
            Rigidbody rb = Instantiate(slash, transform.position, transform.rotation).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 64f, ForceMode.Impulse);
            rb.AddForce(transform.up * 12f, ForceMode.Impulse);
            charge--;
          }
        
    }
}
