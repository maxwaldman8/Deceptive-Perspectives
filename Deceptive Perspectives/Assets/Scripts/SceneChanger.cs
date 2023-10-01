using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChanger : MonoBehaviour
{
    
    
    public float wait = 1;
    public Animator animator;

    public bool WaitForTrig = true;

    public float InbetweenTime = 0f;
    public float InbetweenTimeElapsed = 0;


    public string SceneName = "";
    public bool hasStarted = false;
    void Update()
    {
        
        if(hasStarted)
        {
            ChangeScene(SceneName);
        }
        if(WaitForTrig == false)
        {
            InbetweenTimeElapsed+=1*Time.deltaTime;
            if(InbetweenTimeElapsed > InbetweenTime)
            {
                ChangeScene(SceneName);
            }
        }



    }
    public void ChangeScene(string sceneID)
    {
           
            
            StartCoroutine(LoadScene(sceneID));
    }
    IEnumerator LoadScene(string sceneID)    
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(wait);

        SceneManager.LoadScene(sceneID);
    }

    public void Starter()
    {
        hasStarted = true;
    }


}
