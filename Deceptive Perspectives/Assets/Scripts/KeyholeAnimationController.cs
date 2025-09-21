using UnityEngine;
using UnityEngine.Events;

public class KeyholeAnimationController : MonoBehaviour
{
    public Animator animator;
    public UnityEvent endEvent;
    public GameObject playButton;

    

    public void StartAnimation()
    {
        animator.SetTrigger("Start");
        playButton.GetComponent<InteractableObject>().active = false;
    }

    public void End()
    {
        endEvent.Invoke();
        playButton.GetComponent<InteractableObject>().active = true;
        gameObject.SetActive(false);
    }

}
