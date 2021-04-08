using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ending, mes, mon;

    void Start()
    {
        ending.SetActive(false);
        mes.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other){

        if(other.tag =="Door"){
            if(Input.GetKeyDown(KeyCode.Mouse0)){
                ending.SetActive(true);
                Time.timeScale = 0f;
                Destroy(other);
                Destroy(mes);
                Destroy(mon);
            }

            mes.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other){

        mes.SetActive(false);
    }
}
