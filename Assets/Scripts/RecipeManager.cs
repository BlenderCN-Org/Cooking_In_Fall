using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FallingCooking;
using UnityEngine.UI;

public class RecipeManager : MonoBehaviour {

    public static RecipeManager recipeManagerInstance;
    public GameObject prefabRecipeUI;

    private Transform parentIngredients;
    public GameObject prefabIngredient;

    [SerializeField]
    public List<Ingredients[]> recipes;

    //SINGLETON
    private void Awake()
    {
        if (recipeManagerInstance == null)
        {
            // recipes = new Recipe[5];
            recipeManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        //DontDestroyOnLoad(recipeManagerInstance); // We keep one instance for music that should never be destroyed
    }
    // Use this for initialization
    private void Start () {

        // Init UI
        foreach (Receipe recipe in GameManager.instance.gameRecipes) // Create ingredients
        {
            GameObject newRecipe = Instantiate(prefabRecipeUI, this.transform);
            // Init UI
            newRecipe.transform.Find("Name").GetComponent<Text>().text = recipe.recipeName; // Replace recipe name
            parentIngredients = newRecipe.transform.Find("Ingredients");
            foreach (Ingredients ing in recipe.ingredientsArray) // Create ingredients
            {
                GameObject newIng = Instantiate(prefabIngredient, parentIngredients);
                newIng.transform.GetChild(0).GetComponent<Text>().text = ing.number + " : " + ing.type;
            }
        }
    }
}
