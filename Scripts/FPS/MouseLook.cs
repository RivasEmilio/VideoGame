using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Start is called before the first frame update
    public float sensitivity =100f;

    public Transform playerB;

    private float Xrot = 0f;
    void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")*sensitivity*Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")*sensitivity*Time.deltaTime;

        Xrot-=mouseY;
        Xrot=Mathf.Clamp(Xrot,-50f,50f);

        transform.localRotation =Quaternion.Euler(Xrot,0f,0f);

        playerB.Rotate(Vector3.up*mouseX);

        
    }
}
