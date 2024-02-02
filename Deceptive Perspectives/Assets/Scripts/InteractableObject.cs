using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{

    [field: SerializeField]
    private UnityEvent Event;

    [field: SerializeField]
    private UnityEvent AnimateEvent;

    public bool active;

    void OnMouseUpAsButton(){
        if (active){
            Event.Invoke();
        }
    }

    public void Aninmate (){
         if (active){
            AnimateEvent.Invoke();
        }
    
    }

    // void OnMouseUp(){
    //     if (active){
    //     Event.Invoke();
    //     }
    // }

}
