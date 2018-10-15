using FallingCooking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    [SerializeField]
    private GameObject menuPanel;
    [SerializeField]
    private GameObject levelSelector;

    // Use this for initialization
    private void Awake()
    {
        if (GameManager.menuState)
        {
            menuPanel.SetActive(true);
            levelSelector.SetActive(false);
        }
        else
        {
            menuPanel.SetActive(false);
            levelSelector.SetActive(true);
        }
    }

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
