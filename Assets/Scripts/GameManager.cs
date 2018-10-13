using UnityEngine;
using UnityEngine.SceneManagement;

namespace FallingCooking
{
    public class GameManager : MonoBehaviour
    {
        public enum Type // Ingredient Type
        {
            Tomato,
            Apricot,
            Watermelon,
            Herb,
            Banana,
            Apple,
            Cherry
        };

        //public int[] numberReceipesArray;
        //public Receipe[] gameRecipes; 

        public static GameManager instance = null;

        public enum gameStates { Playing, End };
        public gameStates gameState = gameStates.Playing;

        [Header("Recipes for this Level")]
        public RecipeTemplate[] recipes;

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

    }
}

