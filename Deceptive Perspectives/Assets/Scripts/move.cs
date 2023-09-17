using UnityEngine;

public class move : MonoBehaviour
{

    [field: SerializeField]
    private float speed;
    [field: SerializeField]
    private float JumpMult;
    private bool sprinting = false;
    private bool grounded = false;

    [field: SerializeField]
    private Rigidbody rb;
    [field: SerializeField]
    private LayerMask ground;

    void FixedUpdate()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        grounded = Physics.Raycast(transform.position, -1 * transform.up, 1.1f, ground);

        if (Input.GetKey(KeyCode.LeftShift)){
            sprinting = true;
        }else{
            sprinting = false;
        }

        if (!sprinting){
        rb.AddForce((transform.forward * inputZ + transform.right * inputX).normalized * speed, ForceMode.Force);
        }else{
            rb.AddForce((transform.forward * inputZ + transform.right * inputX).normalized * speed * 1.25f, ForceMode.Force);
        }

        if (grounded && Input.GetKey(KeyCode.Space)){
            rb.AddForce(transform.up * JumpMult, ForceMode.Impulse);
        }
    }
}
