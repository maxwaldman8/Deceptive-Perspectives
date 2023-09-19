using UnityEngine;
using UnityEngine.UI;

public class ItemHolder : MonoBehaviour
{
    
    public string item;
    public bool hasItem;

    [field: SerializeField]
    private Image image;

    void Update()
    {
        image.enabled = hasItem;
    }

    public string Interact (string heldItem)
    {
        if (heldItem == ""){
            hasItem = false;
            return item;
        }else if (heldItem == item){
            hasItem = true;
            return "";
        }else{
            return "Failed";
        }
    }

}
