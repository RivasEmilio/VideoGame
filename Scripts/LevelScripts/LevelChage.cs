using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChage : MonoBehaviour
{
    // Start is called before the first frame update
   public Animator animator;
   private string level;

    // Update is called once per frame
    void Update()
    {
    }

    public void Fadeto(string name){

        animator.SetTrigger("End");
        level = name;
    }

    public void OnfadeComplete(){
        SceneManager.LoadScene(level);
    }
}
