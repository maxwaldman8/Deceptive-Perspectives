using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ItemHolder : MonoBehaviour
{
    
    public string item;
    public bool hasItem;

    [field: SerializeField]
    private Image image;
    [field: SerializeField]
    private string neededItem;
    // set to nothing for not usable
    [field: SerializeField]
    private UnityEvent action;
    // set to true if it is just for an action and does not hold an item
    [field: SerializeField]
    private bool isAction = false;

    void Update()
    {
        image.enabled = hasItem;
    }

    public string Interact (string heldItem)
    {
        if (heldItem == "" && !isAction && hasItem){
            hasItem = false;
            return item;
        }else if (heldItem == item && !isAction){
            hasItem = true;
            return "";
        }else if (hasItem && heldItem == neededItem){
            action.Invoke();
            return "Success";
        }else{
            return "Failed";
        }
    }

    public void ChangeItem(string newItem){
        item = newItem;
    }

}
