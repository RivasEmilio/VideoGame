using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOff : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] lights;
    float tiempoAct;
    float rate = 0.01f;
    public GameObject[] objText;
    public GameObject[] trigs;
    private bool on1 = false, on2 = false, on3 = false;  
    private bool range1 = false, range2 = false, range3 = false;
    AudioSource audioSource;
    public AudioClip clipClass;
    public AudioClip clipGym;
    public AudioClip clipTheater;
    public GameObject[] jumpscares;
    void Start()
    {
        
        objText[0].SetActive(false);  

        audioSource = GetComponent<AudioSource>();

        foreach (var item in jumpscares)
        {
            item.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time >  tiempoAct) {
            tiempoAct = Time.time + rate;
        }
       
        if (range1 && Input.GetKeyDown(KeyCode.Mouse0)&& trigs[0]!=null)
        {
            on1= true;
            audioSource.PlayOneShot(clipClass);
            print("luz 1 prendida");
            Object.Destroy(trigs[0]);
            jumpscares[0].SetActive(true);  
            StartCoroutine(aptest(jumpscares[0],5));  
        }

         if (range2 && Input.GetKeyDown(KeyCode.Mouse0)&&trigs[2]!=null)
        {
            on2= true;
            audioSource.PlayOneShot(clipGym);
            Object.Destroy(trigs[2]);
            jumpscares[1].SetActive(true);  
            StartCoroutine(aptest(jumpscares[1],9));  
        }

         if (range3 && Input.GetKeyDown(KeyCode.Mouse0)&&trigs[1]!=null)
        {
            on3= true;
            audioSource.PlayOneShot(clipTheater);
            jumpscares[2].SetActive(true);  
            Object.Destroy(trigs[1]);
            StartCoroutine(aptest(jumpscares[2],5));    
        }

        if (on1 && on2 && on3)
        {
            foreach (var light in lights)
            {
                light.SetActive(true);   
            }
            objText[1].SetActive(true);  
            Object.Destroy(objText[0]);
        }
        
    }

    private void OnTriggerStay(Collider s){
        if (s.tag== "Switch1")
        {
            range1= true;
    
        }

        if (s.tag== "Switch2")
        {
            range2= true;
    
        }
        if (s.tag== "Switch3")
        {
            range3= true;
        
        }
       
     
    }

    private void OnTriggerExit(Collider s){

       if (s.tag== "Switch1")
        {
            range1= false;
        }

         if (s.tag== "Switch2")
        {
            range2= false;
        }
        if (s.tag== "Switch3")
        {
            range3= false;
        }

    }

    public void apagar(GameObject s){

        s.SetActive(false);
    }

    public IEnumerator aptest(GameObject s, int i){
        yield return new WaitForSeconds(i);
        print("se debio de prender");
        s.SetActive(false);
    }
    
}
