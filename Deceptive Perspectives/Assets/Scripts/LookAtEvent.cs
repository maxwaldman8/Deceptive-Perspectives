using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LookAtEvent : MonoBehaviour
{

    [field: SerializeField]
    private UnityEvent Event;
    [field: SerializeField]
    private bool onlyFirstLook = true;

    public bool active;

    private bool lookedAt = false;

    void OnMouseOver(){
        if (active && !(lookedAt && onlyFirstLook)){
            Event.Invoke();
            lookedAt = true;
        }
    }

}
