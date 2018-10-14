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
        
        [Header("Recipes for this Level")]
        public List<RecipeTemplate> recipes;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
        }

        public void Start()
        {
            //if (numberReceipesArray.Length != 0)
            //{
            //    gameRecipes = new Receipe[numberReceipesArray.Length];
            //    for (int i = 0; i < gameRecipes.Length; i++)
            //    {
            //        gameRecipes[i] = this.GetComponent<ReceipeTemplate>().availableRecipes[numberReceipesArray[i]];
            //    }
            //}
            //else {
            //    Debug.Log("Empty numberReceipesArray");
            //}
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
            Debug.Log("FINISH");
        }

    }
}

