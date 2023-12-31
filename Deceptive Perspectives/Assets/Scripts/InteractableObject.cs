using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{

    [field: SerializeField]
    private UnityEvent Event;

    public bool active;

    void OnMouseUpAsButton(){
        if (active){
        Event.Invoke();
        Debug.Log("event");
        }
    }

    // void OnMouseUp(){
    //     if (active){
    //     Event.Invoke();
    //     }
    // }

}
