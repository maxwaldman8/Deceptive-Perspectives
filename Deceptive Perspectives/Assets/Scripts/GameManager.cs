using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public void GoToScene(string scene){
        SceneManager.LoadScene(scene);
    }

}
