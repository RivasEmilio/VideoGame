using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public CharacterController controller;

    public float speed = 4f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;

    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    // Update is called once per frame
    bool isGround;
    void Update()
    {

        isGround= Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGround && velocity.y <0){

            velocity.y = -2f;
        }
        
        float x =Input.GetAxis("Horizontal");
        float z =Input.GetAxis("Vertical");
        
        Vector3 move = transform.right*x + transform.forward*z;

        controller.Move(move*speed*Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGround){

            velocity.y = Mathf.Sqrt(jumpHeight* -2f * gravity);
        }

        velocity.y += gravity* Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed=speed*1.5f;
        }else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed=4f;
        }

        controller.Move(velocity*Time.deltaTime);

    }
}
