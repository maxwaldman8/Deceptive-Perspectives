using UnityEngine;

public class FakePause : MonoBehaviour
{

    private bool paused = false;
    private float delayTime = 1f;
    private float delay = 0f;
    public bool unpausedYet = false;

    private Vector3 prevPos;
    private Quaternion prevRot;
    private Vector3 prevVel;
    private Quaternion prevCRot;

    [field: SerializeField]
    private GameObject FakePauseMenuObj;
    [field: SerializeField]
    private GameObject MenuButton;
    [field: SerializeField]
    private GameObject PauseButton;
    [field: SerializeField]
    private GameObject overlay;
    
    void Update(){
        if (paused && delay <= delayTime){
            delay += Time.deltaTime;
        }else if (!paused && delay != 0f){
            delay = 0f;
        }
        if (delay >= delayTime){
            GetComponent<move>().enabled = true;
        }
        if (paused && Input.GetKeyDown(KeyCode.Escape)){
            Unpause();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !paused && !unpausedYet){
            FakePauseMenu();
        }
        if (paused && !unpausedYet && (Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f || Input.GetKeyDown(KeyCode.Space)) && delay >= delayTime){
            UnlockControls();
        }
    }

    void FakePauseMenu(){
        paused = true;
        prevPos = transform.position;
        prevRot = transform.localRotation;
        prevVel = GetComponent<Rigidbody>().velocity;
        prevCRot = transform.GetChild(0).localRotation;
        transform.position = new Vector3(0,0,0);
        transform.localRotation = Quaternion.Euler(0,0,0);
        transform.GetChild(0).transform.localRotation = Quaternion.Euler(0,0,0);
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        transform.GetChild(0).GetComponent<Camera>().orthographic = true;
        transform.GetChild(0).GetComponent<CameraFollow>().enabled = false;
        GetComponent<move>().enabled = false;
        PauseButton.transform.GetChild(0).gameObject.SetActive(true);
        MenuButton.transform.GetChild(0).gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        FakePauseMenuObj.SetActive(true);
        overlay.SetActive(false);
        //disable inventory
    }

    void UnlockControls(){
        unpausedYet = true;
        transform.position = new Vector3(0,0,2.225f);
        GetComponent<move>().enabled = true;
        transform.GetChild(0).GetComponent<CameraFollow>().enabled = true;
        transform.GetChild(0).GetComponent<CameraFollow>().xRotation = 0;
        transform.GetChild(0).GetComponent<Camera>().orthographic = false;
        Cursor.lockState = CursorLockMode.Locked;
        PauseButton.transform.GetChild(0).gameObject.SetActive(false);
        MenuButton.transform.GetChild(0).gameObject.SetActive(false);
        Cursor.visible = false;
        MenuButton.GetComponent<InteractableObject>().active = true;
        PauseButton.GetComponent<InteractableObject>().active = true;
        overlay.SetActive(true);
        //enable inventory
    }

    public void Unpause(){
        paused = false;
        transform.position = prevPos;
        transform.localRotation = prevRot;
        GetComponent<Rigidbody>().velocity = prevVel;
        GetComponent<move>().enabled = true;
        transform.GetChild(0).localRotation = prevCRot;
        transform.GetChild(0).GetComponent<CameraFollow>().enabled = true;
        transform.GetChild(0).GetComponent<Camera>().orthographic = false;
        PauseButton.transform.GetChild(0).gameObject.SetActive(false);
        MenuButton.transform.GetChild(0).gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        FakePauseMenuObj.SetActive(false);
        overlay.SetActive(true);
        //enable inventory
    }

}
