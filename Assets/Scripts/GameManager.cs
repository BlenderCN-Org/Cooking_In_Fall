using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FallingCooking
{
    public class GameManager : MonoBehaviour
    {

        public enum gameStates { Playing, End };
        public gameStates gameState = gameStates.Playing;

        private GameObject menuPanel;
        private GameObject levelSelector;

        public static GameManager instance = null;
 
        void Awake()
        {
            menuPanel = GameObject.Find("CanvasMenu/MenuPanel");
            levelSelector = GameObject.Find("CanvasMenu/Lvl Selector");
            levelSelector.SetActive(false); // Because uniyt can't find inactive object LOL
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(this.gameObject);
        }

        // Use this for initialization
        void Start()
        {
            Debug.Log("start");
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

        public void LoadScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}