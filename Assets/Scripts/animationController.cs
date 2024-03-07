using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationController : MonoBehaviour
{
  
    public movementScript am;
    private Animator anim;
    //private bool isBlocking;
    //private bool isAttacking;
    // Start is called before the first frame update
    void Start()
    {
        am = FindObjectOfType<movementScript>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        AnimationController();
    }

    private void AnimationController()
    {
          if(Input.GetKey("mouse 1"))
          {
            anim.SetBool("isBlocking",true);
          }else
          {
            am.speed = 15;
            anim.SetBool("isBlocking",false);
          }
          if(Input.GetKeyDown("mouse 0"))
          {
            anim.SetBool("isAttacking",true);
          }else
          {
            anim.SetBool("isAttacking",false);
          }
    }
    void Slowed()
    {
      am.speed = 5;
    }
}
