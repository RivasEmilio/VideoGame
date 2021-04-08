using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clues : MonoBehaviour
{
    // Start is called before the first frame update

   private bool hasClue1=false, once=true;

   AudioSource audioSource;

    public AudioClip itemClip;
  
    public GameObject[] clues;

    public GameObject[] textObj;

    public GameObject[] trigs;

    
    void Start()
    {
      foreach (var item in clues)
      {
          item.SetActive(false);
      }

      foreach (var item in textObj)
      {
           item.SetActive(false);
      }

      foreach (var item in trigs)
      {
          item.SetActive(false);
      }
    
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
           if(Input.GetKeyDown(KeyCode.Alpha1) && hasClue1 && once){
                clues[0].SetActive(false);
                audioSource.PlayOneShot(itemClip);
                foreach (var item in trigs)
                {
                    item.SetActive(true);
                }
                once=false;
            }

            if(Input.GetKeyDown(KeyCode.Alpha1)){
            clues[1].SetActive(false);
            audioSource.PlayOneShot(itemClip);
            }
    }

    private void OnTriggerStay(Collider other){

        if(other.CompareTag("clue1")){

            if(Input.GetKeyDown(KeyCode.Mouse0)){

                audioSource.PlayOneShot(itemClip);
                Destroy(other.gameObject);
                clues[0].SetActive(true);
                textObj[0].SetActive(true);
                hasClue1=true;
                
            }
           
             
        }

        if(other.CompareTag("clue2")){

            if(Input.GetKeyDown(KeyCode.Mouse0)){

                audioSource.PlayOneShot(itemClip);
                Destroy(other.gameObject);
                clues[1].SetActive(true);        
            }
           
             
        }
    }
}
