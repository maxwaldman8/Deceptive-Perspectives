using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ItemHolder : MonoBehaviour
{
    
    public string item;
    public bool hasItem;

    public string Type;


    [field: SerializeField]
    private Image image;

    [field: SerializeField]
    private GameObject gameObject;

    [field: SerializeField]
    private MeshRenderer meshRenderer;

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
        if (!isAction) {
            if (Type == "Image") {
                image.enabled = hasItem;
            } else if (Type == "Mesh") {
                meshRenderer.enabled = hasItem;
            } else if (Type == "Object") {
                //be carful, this will not work if the game object input is the game object with this script,
                // as the script will stop running and you will not be able to put the item back. 
                gameObject.SetActive(hasItem);
            }
        }
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
