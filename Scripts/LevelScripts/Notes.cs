using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] pieces;

    public GameObject escape;
    LevelChage sn;
    public GameObject[] objText;

    public GameObject scare;

    public GameObject fullnote;
    
    AudioSource audioSource;

    public AudioClip itemClip;

    public AudioClip clip2;

    private bool n1 = false, n2 = false, n3 = false, n4 = false;
    void Start()
    {
        foreach (var item in pieces)
        {
            item.SetActive(false);
        }

        audioSource = GetComponent<AudioSource>();   
        scare.SetActive(false);

        sn = GameObject.FindObjectOfType(typeof(LevelChage)) as LevelChage;

        escape.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {}
    private void OnTriggerStay(Collider other){

         if (other.CompareTag("n1")&& Input.GetKeyDown(KeyCode.Mouse0))
        {
            n1= true;
            audioSource.PlayOneShot(itemClip);
            Destroy(other.gameObject);
            
        }
         if (other.CompareTag("n2")&& Input.GetKeyDown(KeyCode.Mouse0))
        {
            n2= true;
            audioSource.PlayOneShot(itemClip);
            Destroy(other.gameObject);
            
        } if (other.CompareTag("n3")&& Input.GetKeyDown(KeyCode.Mouse0))
        {
            n3= true;
            audioSource.PlayOneShot(itemClip);
            Destroy(other.gameObject);
            
        } if (other.CompareTag("n4")&& Input.GetKeyDown(KeyCode.Mouse0))
        {
            n4= true;
            audioSource.PlayOneShot(itemClip);
            Destroy(other.gameObject);
            
        }
       
       if (n1 && n2 && n3 && n4)
        {
            objText[3].SetActive(true);  
            Destroy(objText[2]);
            fullnote.SetActive(true);
        }

        if(n1 && n2 && n3 && n4 && other.CompareTag("canvas")){
            Destroy(objText[3]);
            objText[4].SetActive(true);
            StartCoroutine(delay()); 
        }
        
    }

    private void OnTriggerEnter(Collider other){

        if(other.CompareTag("entry")){
            objText[1].SetActive(true);  
            Destroy(objText[0]);
            foreach (var item in pieces)
            {
                item.SetActive(true);
            }
            fullnote.SetActive(false);
            //aniL.SetBool("c",true);
            //aniR.SetBool("c",true);
            Destroy(other);
            
        }

        if(other.CompareTag("canvas")){
            objText[2].SetActive(true);  
            Destroy(objText[1]);
            
        } 

        if(other.CompareTag("Exit")){
            sn.Fadeto("test3");
        }
    }

    public IEnumerator delay(){
        scare.SetActive(true);
        escape.SetActive(true);
        yield return new WaitForSeconds(5);
        audioSource.loop=true;
        audioSource.clip= clip2;
        audioSource.volume = 0.4f;
        audioSource.Play();
        print("se debio de prender");
    }

}
