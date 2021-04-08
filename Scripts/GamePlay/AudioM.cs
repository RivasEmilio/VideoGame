using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioM : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioSource;

    public AudioClip itemClip;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other){

        if(other.CompareTag("Player")){    
            audioSource.PlayOneShot(itemClip); 
        }
    }
}
