using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyholeAnimationController : MonoBehaviour
{
    public Animator animator;
    public GameObject gameObject;

    public Rigidbody floorRigidBody;

    public void StartAnimation()
    {
        animator.SetTrigger("Start");
    }

    public void End()
    {

        gameObject.SetActive(false);
        floorRigidBody.isKinematic = false;

    }

}
