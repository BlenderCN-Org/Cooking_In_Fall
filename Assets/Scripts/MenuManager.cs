using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    public static bool menuState = true;

    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject levelSelector;

    public void Play()
    {
        menuPanel.SetActive(false);
        levelSelector.SetActive(true);
    }

    public void Menu()
    {
        menuPanel.SetActive(true);
        levelSelector.SetActive(false);
    }

    public void LoadMenu(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
