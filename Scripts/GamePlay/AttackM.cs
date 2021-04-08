using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackM : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    private float life= 0;
    public RawImage bar;
    private float fill= 0.002f;
    public Text Govtext;

    public GameObject tryagain;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        tryagain.SetActive(false);
        bar.color=new Color(bar.color.r,bar.color.g,bar.color.b,0);
        Govtext.gameObject.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {       
    }

     private void OnTriggerStay(Collider other){

        if(other.tag =="Player"){

            animator.SetBool("At",true);
            print("attacking");
            life=(life+fill);
            print("Contact with enemy");
            bar.color=new Color(bar.color.r,bar.color.g,bar.color.b,life);
        }
        if(life>=1){
            Govtext.gameObject.SetActive(true); 
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            tryagain.SetActive(true); 
         }
    }

     private void OnTriggerExit(Collider other){

        if(other.tag =="Player"){
            animator.SetBool("At",false);     
        }
    }
}
