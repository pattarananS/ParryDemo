using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{

    //import
    
    //walk
    public CharacterController controller;
    public float speed = 6f;
    [SerializeField] float turnSmoothTime = 0.1f; 
    [SerializeField] Transform cam;
    float turnSmoothVelocity;

    //groundCheck
    [SerializeField] bool isGrounded;

    //jump
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float jumpHeight = 3;
    [SerializeField] Transform GroundCheck;
    [SerializeField] float GroundDistance = 0.4f;
    [SerializeField] LayerMask GroundMask;
    Vector3 velocity;

    // Update is called once per frame
    void Update()
    { 
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked;

        //JUMP
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -1 * gravity);
        }

        //SPRINT
        if(Input.GetKey("left shift"))
        {
            speed = 25;
        }else if(Input.GetKeyUp("left shift"))
        {
            speed = 15;
        }

        //GRAVITY OF JUMP
        velocity.y += gravity * 10f * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //WALK
        float horizontal = Input.GetAxisRaw("Horizontal"); 
        float vertical = Input.GetAxisRaw("Vertical"); 
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            //WALK DIRECTION
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f)* Vector3.forward;

            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        
    }
    ///LOAD LEVEL METHOD
    void LoadLv()
    {
        Application.LoadLevel("SampleScene");
    }

    
  
}
