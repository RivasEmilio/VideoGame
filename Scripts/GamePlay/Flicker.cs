using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    
    public Light[] light;

    public float MinTime;
    public float Maxtime;
    public float Timer;
    void Start()
    {
        Timer = Random.Range(MinTime,Maxtime);
    }
    void Update()
    {
        FlickerLight();
    }

    void FlickerLight(){

        if(Timer > 0){
            Timer -= Time.deltaTime;

        }

        if(Timer<=0){

           
            light[0].enabled = !light[0].enabled;
            light[1].enabled = !light[1].enabled;
            Timer = Random.Range(MinTime, Maxtime);
        }
    }
}
