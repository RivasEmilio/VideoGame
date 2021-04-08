using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
   LevelChage sn;
    void Start(){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("empezo escena");
        sn = GameObject.FindObjectOfType(typeof(LevelChage)) as LevelChage;
     }
   public void PlayGame()
    {
        Cursor.visible = false;
        sn.Fadeto("test2");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
