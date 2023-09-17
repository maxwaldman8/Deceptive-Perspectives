using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePause : MonoBehaviour
{

    private bool pausedYet = false;
    private bool unpausedYet = false;

    [field: SerializeField]
    private GameObject FakePauseMenuObj;
    
    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape) && !pausedYet){
            FakePauseMenu();
        }
        if (pausedYet && !unpausedYet && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Space))){
            UnlockControls();
        }
    }

    void FakePauseMenu(){
        pausedYet = true;
        transform.position = new Vector3(0,0,0);
        transform.localRotation = Quaternion.Euler(0,0,0);
        transform.GetChild(0).GetComponent<Camera>().transform.localRotation = Quaternion.Euler(0,0,0);
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        transform.GetChild(0).GetComponent<Camera>().orthographic = true;
        transform.GetChild(0).GetComponent<CameraFollow>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        FakePauseMenuObj.SetActive(true);
        //disable inventory
    }

    void UnlockControls(){
        unpausedYet = true;
        transform.GetChild(0).GetComponent<CameraFollow>().enabled = true;
        transform.GetChild(0).GetComponent<Camera>().orthographic = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //enable inventory
    }

}
