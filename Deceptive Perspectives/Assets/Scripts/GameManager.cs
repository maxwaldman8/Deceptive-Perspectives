using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [field: SerializeField]
    private GameObject Inventory;
    [field: SerializeField]
    private GameObject FakePauseMenu;
    [field: SerializeField]
    private GameObject FakeMainMenu;
    [field: SerializeField]
    private GameObject HiddenKey;
    [field: SerializeField]
    private GameObject Player;

    [field: SerializeField]
    private GameObject Settings;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Game"){
            Load();
        }
    }
    
    public void GoToScene(string scene){
        if (SceneManager.GetActiveScene().name == "Game" && PlayerPrefs.GetString("Autosave") == "True"){
            Save();
        }
        if (SceneManager.GetActiveScene().name == "MainMenu" && scene == "Game"){
            SaveSettings();
        }
        SceneManager.LoadScene(scene);
    }

    public void Save()
    {
        Debug.Log("ahoy");
        PlayerPrefs.SetString("CurrentItem", Inventory.GetComponent<Inventory>().currentItem);
        PlayerPrefs.SetString("FakePauseMenu", (Player.GetComponent<FakePause>().unpausedYet && FakePauseMenu.activeSelf).ToString());
        PlayerPrefs.SetString("FakeMainMenu", FakeMainMenu.activeSelf.ToString());
        PlayerPrefs.SetString("HiddenKey", (!HiddenKey.GetComponent<ItemHolder>().hasItem).ToString());
        Debug.Log("hi");
    }

    public void Load()
    {
        Inventory.GetComponent<Inventory>().currentItem = PlayerPrefs.GetString("CurrentItem");
        FakePauseMenu.SetActive(PlayerPrefs.GetString("FakePauseMenu") == "True");
        FakeMainMenu.SetActive(PlayerPrefs.GetString("FakeMainMenu") == "True");
        HiddenKey.GetComponent<ItemHolder>().hasItem = !(PlayerPrefs.GetString("HiddenKey") == "True");
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetString("Autosave", Settings.GetComponent<Settings>().autosave.ToString());
    }

}
