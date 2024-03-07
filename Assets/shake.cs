using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shake : MonoBehaviour
{
    private Animator anim;
    public float shakeDur = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(shakeDur <= 0)
        {
            shakeDur =0;
        }
        if(shakeDur > 0)
        {
            anim.SetBool("isShaking",true);
        }else{
            anim.SetBool("isShaking",false);
        }
        shakeDur -= 9f * Time.deltaTime;
        //Debug.Log(shakeDur);
        
    }
}
