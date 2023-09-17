using UnityEngine;

public class FakePause : MonoBehaviour
{

    private bool paused = false;
    private bool unpausedYet = false;

    [field: SerializeField]
    private GameObject FakePauseMenuObj;
    [field: SerializeField]
    private GameObject MenuButton;
    
    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape) && !paused && !unpausedYet){
            FakePauseMenu();
        }
        if (paused && !unpausedYet && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Space))){
            UnlockControls();
        }
    }

    void FakePauseMenu(){
        paused = true;
        transform.position = new Vector3(0,0,0);
        transform.localRotation = Quaternion.Euler(0,0,0);
        transform.GetChild(0).GetComponent<Camera>().transform.localRotation = Quaternion.Euler(0,0,0);
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        transform.GetChild(0).GetComponent<Camera>().orthographic = true;
        transform.GetChild(0).GetComponent<CameraFollow>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        FakePauseMenuObj.SetActive(true);
        //disable inventory and ui
    }

    void UnlockControls(){
        unpausedYet = true;
        transform.GetChild(0).GetComponent<CameraFollow>().enabled = true;
        transform.GetChild(0).GetComponent<Camera>().orthographic = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        MenuButton.GetComponent<InteractableObject>().active = true;
        //enable inventory and ui
    }

}
