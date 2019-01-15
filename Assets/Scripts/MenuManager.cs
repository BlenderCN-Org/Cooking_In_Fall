using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    public static bool menuState = true;

    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject levelSelector;

    public void ShowLevelSelector()
    {
        menuPanel.SetActive(false);
        levelSelector.SetActive(true);
    }

    public void ShowMenuScreen()
    {
        menuPanel.SetActive(true);
        levelSelector.SetActive(false);
    }

    public void LoadLevel(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
