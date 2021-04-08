using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContAnim : MonoBehaviour
{
    
    Animator animator;

    Life life;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        life =GetComponentInParent<Life>();
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
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("Sprint",false);
            
        }
    }
    void VerificaJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Jump",true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("Jump",false);
            
        }
        
    }

    void VerificaMuerte(float status){
        if (status<=0 && status>=(-0.004))
        {
            animator.SetBool("Muerte",true);
            
        }else{
            animator.SetBool("Muerte",false);
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        VerificaWalkF();
        VerificaWalkB();
        VerificaWalkR();
        VerificaWalkL();
        VerificaRun();
        VerificaJump();

        //VerificaMuerte(life.getLife());

        
    }
}
