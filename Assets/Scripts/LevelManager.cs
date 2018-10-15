using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FallingCooking
{
    public class LevelManager : MonoBehaviour
    {
        public enum Type // Ingredient Type
        {
            Apricot,
            Cheese,
            Egg,
            Eggplant,
            Fish,
            Potato,
            Pumpkin,
            Steak,
        };

        public static LevelManager instance = null;
        public  GameObject levelFinishedUI;
        public GameObject canvasReceipe;
        public GameObject pauseUI;

         [Header("Recipes for this Level")]
        public List<RecipeTemplate> recipes;

        public bool pauseState;

        void Awake()
        {
            pauseState = false;
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        public void Start()
        {}


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
        }


        public void LoadScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void FinishedLevel()
        {
            levelFinishedUI.SetActive(true);
            canvasReceipe.SetActive(false);
        }

        private void Pause()
        {
            if (!pauseState)
            {
                pauseState = true;
                Time.timeScale = 0;
                pauseUI.SetActive(true);
            }
            else
            {
                pauseState = false;
                Time.timeScale = 1;
                pauseUI.SetActive(false);
            }
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}

