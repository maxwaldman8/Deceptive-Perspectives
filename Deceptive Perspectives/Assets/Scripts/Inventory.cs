using UnityEngine;
using UnityEngine.UI;

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
    private Sprite HardHat;

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
            case "Empty":
                image.sprite = Empty;
                break;
            case "Key":
                image.sprite = Key;
                break;
            case "UnpauseLeft":
                image.sprite = UnpauseLeft;
                break;
            case "UnpauseRight":
                image.sprite = UnpauseRight;
                break;
            case "HardHat":
                image.sprite = HardHat;
                break;
        }
    }

}
