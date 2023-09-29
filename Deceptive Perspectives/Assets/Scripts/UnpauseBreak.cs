using UnityEngine;
using UnityEngine.Events;

public class UnpauseBreak : MonoBehaviour
{
    
    [field: SerializeField]
    private GameObject UnpauseLeft;
    [field: SerializeField]
    private GameObject UnpauseRight;

    private int frame = 0;

    public void Pressing(){
        frame++;
        //put particles here
    }

    void Update(){
        if (frame >= 5){
            UnpauseLeft.SetActive(true);
            UnpauseRight.SetActive(true);
            gameObject.SetActive(false);
        }
    }

}
