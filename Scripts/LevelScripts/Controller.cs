using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float velocidad = 10.0f;
    float velocidadInicial = 10.0f;
    public float horizontalSpeed = 2.0F;
    Animator animator;
    
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }
    public void FixedUpdate()
    {

        // The value is in the range -1 to 1
        float translationVertical = Input.GetAxis("Vertical") * velocidad;
        float translationHorizontal = Input.GetAxis("Horizontal") * velocidad;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translationVertical *= Time.deltaTime;
        translationHorizontal *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(0, 0, translationVertical);
        // Move translation along the object's x-axis
        transform.Translate(translationHorizontal, 0, 0);

    }

    void VerificaWalkF()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("Camina",true);
        }
        else if(Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("Camina",false);
        }
    }

    void VerificaWalkB(){

        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("Back",true);
        }
        else if(Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("Back",false);
        }
    }

    void VerificaWalkR(){
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("Der",true);
        }
        else if(Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Der",false);
        }

    }

    void VerificaWalkL(){

        if (Input.GetKeyDown(KeyCode.A) )
        {
            animator.SetBool("Iz",true);
        }
        else if(Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Iz",false);
        }

    }

    void VerificaRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool("Sprint",true);
            velocidadInicial= velocidad;
            velocidad*=velocidad;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("Sprint",false);
            velocidad = velocidadInicial;
        }
    }
    void VerificaJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Jump",true);
        }
        else
        {
            animator.SetBool("Jump",false);
        }
    }

    void VerificaMuerte(){
        if (Input.GetKeyDown(KeyCode.M))
        {
            animator.SetBool("Muerte",true);
        }
        else
        {
            animator.SetBool("Muerte",false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(0, h, 0);
        VerificaJump();
        VerificaWalkF();
        VerificaWalkB();
        VerificaWalkR();
        VerificaWalkL();
        VerificaRun();
        VerificaJump();
        VerificaMuerte();
    }
}
