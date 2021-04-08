using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Life : MonoBehaviour
{
    // Start is called before the first frame update
    private float life= 0;
    public RawImage bar;
    private float fill= 20f;
    public Text Govtext;
    public GameObject enemy;

    Color change;
   
    void Start(){

        change=bar.color;
       
    }

    // Update is called once per frame
    void Update(){}

    public float getLife(){
        return life;
    }

     private void OnTriggerStay(Collider other){

        if(other.CompareTag("Enemy")){

            life=(life+fill);
            print("Contact with enemy");
            bar.color=new Color(bar.color.r,bar.color.g,bar.color.b,life);
            
            
        }

         if(life<0){
            Govtext.gameObject.SetActive(true);  
            enemy.gameObject.SetActive(false);
             
         }
    }
}
