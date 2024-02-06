using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Collections;
using UnityEngine.UI;
using TMPro;

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

    [field: SerializeField]
    private float thoughtDisplayDuration = 5f;
    [field: SerializeField]
    private GameObject thoughtProcess;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Game")
            Load();
    }
    
    public void GoToScene(string scene){
        if (SceneManager.GetActiveScene().name == "Game" && PlayerPrefs.GetString("Autosave") == "True")
            Save();
        if (SceneManager.GetActiveScene().name == "MainMenu" && scene == "Game")
            SaveSettings();
        SceneManager.LoadScene(scene);
    }

    public void Save()
    {
        PlayerPrefs.SetString("CurrentItem", Inventory.GetComponent<Inventory>().currentItem);
        PlayerPrefs.SetString("FakePauseMenu", (Player.GetComponent<FakePause>().unpausedYet && FakePauseMenu.activeSelf).ToString());
        PlayerPrefs.SetString("FakeMainMenu", FakeMainMenu.activeSelf.ToString());
        PlayerPrefs.SetString("HiddenKey", (!HiddenKey.GetComponent<ItemHolder>().hasItem).ToString());
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

    IEnumerator DisplayThoughtC(string thought) {
        //animation for popping up maybe
        thoughtProcess.SetActive(true);
        thoughtProcess.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = thought;
        yield return new WaitForSeconds(thoughtDisplayDuration);
        //animation for fading out maybe
        if (thoughtProcess.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == thought)
            thoughtProcess.SetActive(false);
    }

    public void DisplayThought(string thought) {
        StartCoroutine(DisplayThoughtC(thought));
    }

}
