using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float mouseSensitivity = 500f;
    float xRotation;
    public GameObject playerObj;

    void OnEnable()
    {
        xRotation = 0f;
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerObj.transform.Rotate(Vector3.up * mouseX);
    }

}