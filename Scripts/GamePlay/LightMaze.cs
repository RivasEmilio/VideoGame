using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightMaze : MonoBehaviour
{
    public GameObject light;

    public GameObject lampara;

    public GameObject battery;
    
    private bool prendido = true;
    private bool status = true;

    AudioSource audioSource;
    public AudioClip on;
    public AudioClip off;

    private bool holds = true;
    public Image pirul;
    public GameObject text;
    float fill= 0.006f;
    // Start is called before the first frame update
    void Start()
    {
        battery.SetActive(true);
        text.SetActive(false); 
        lampara.SetActive(true);
        audioSource = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && !prendido && status && holds)
        {
            light.SetActive(true);  
            text.SetActive(false); 
            prendido = true;
            audioSource.PlayOneShot(on);
        }

        else if (Input.GetKeyDown(KeyCode.E) && prendido || !status)
        {
            light.SetActive(false); 
            if(holds)
            {
                text.SetActive(true);
            }
            prendido = false;
            audioSource.PlayOneShot(off);

        }

        if(prendido && holds && Time.timeScale>0){

            pirul.fillAmount = (pirul.fillAmount-(fill*Time.deltaTime));

        }else if(!prendido){
            pirul.fillAmount = pirul.fillAmount;
        }
        
        if(pirul.fillAmount<=0){
            status=false;

        }

        if(pirul.fillAmount<.3){
            pirul.color = Color.red;

        }

    }
    private void OnTriggerStay(Collider  other){

        if(other.CompareTag("energy") && holds){

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
               Destroy(other.gameObject);
                status=true;
                pirul.fillAmount=1;
                light.SetActive(true);
                prendido = true;
                pirul.color = Color.white; 
            }
            
            
        }
    }
    
}
