using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    
    [field: SerializeField]
    private Sprite Empty;
    [field: SerializeField]
    private Sprite Key;
    [field: SerializeField]
    private Sprite UnpauseLeft;
    [field: SerializeField]
    private Sprite UnpauseRight;
    [field: SerializeField]
    private Sprite Hole;
    [field: SerializeField]
    private Sprite Y;
    [field: SerializeField]
    private Sprite HardHat;

    [field: SerializeField]
    private TMP_Text description;

    private Image image;

    // public because it will be used when saving game
    public string currentItem;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        switch (currentItem){
            case "":
                image.sprite = Empty;
                description.text = "";
                break;
            case "Key":
                image.sprite = Key;
                description.text = "Key";
                break;
            case "UnpauseLeft":
                image.sprite = UnpauseLeft;
                description.text = "Left HALF of Unpause Button";
                break;
            case "UnpauseRight":
                image.sprite = UnpauseRight;
                description.text = "Right HALF of Unpause Button";
                break;
            case "Hole":
                image.sprite = Hole;
                description.text = "Hole";
                break;
            case "Y":
                image.sprite = Y;
                description.text = "Y";
                break;
            case "HardHat":
                image.sprite = HardHat;
                description.text = "Hard Hat";
                break;
        }
    }

    public void SetItem(string item)
    {
        currentItem = item;
    }

    public void MoveItem(ItemHolder itemHolder)
    {
        string result = itemHolder.Interact(currentItem);
        if (result != "Failed" && result != "Success"){
            currentItem = result;
        }
    }

}
