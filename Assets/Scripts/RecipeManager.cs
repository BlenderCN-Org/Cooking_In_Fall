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

    private RecipeTemplate currentRecipe;
    [HideInInspector]
    public List<GameObject> recipesUI;


    [SerializeField]
    private GameObject goodEffect;
    [SerializeField]
    private GameObject badEffect;


    private bool checkIngredientValue;

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
        foreach (RecipeTemplate recipe in LevelManager.instance.recipes) // Create ingredients
        {
            GameObject newRecipe = Instantiate(prefabRecipeUI, this.transform);
            newRecipe.transform.Find("Name").GetComponent<Text>().text = recipe.name; // Replace recipe name
            parentIngredients = newRecipe.transform.Find("Ingredients");
            // Init UI for ingredients
            foreach (Ingredient ing in recipe.listIngredients)
            {
                GameObject newIng = Instantiate(prefabIngredient, parentIngredients);
                newIng.GetComponent<Image>().sprite = ing.icon;
                newRecipe.GetComponent<RecipeUIManager>().ingredientListsUI.Add(newIng);
                newRecipe.GetComponent<RecipeUIManager>().ingredientListsEnum.Add(ing.type);
            }
            recipesUI.Add(newRecipe);
        }
        currentRecipe = LevelManager.instance.recipes[0];
        checkIngredientValue = true;
    }

    public void IngredientInPan(GameObject ingredient)
    {
        if (!checkIngredientValue) {
            return;
        }
        StartCoroutine(DestroyObject(ingredient, 1.5f));
        // Check ingredient in list
        if (CheckIngredient(ingredient)) //ingredient.GetComponent<Ingredient>().type == GameManager.Type.Egplant
        {
            // Generate Effect
            GameObject effect = Instantiate(goodEffect,ingredient.transform);
            StartCoroutine(DestroyObject(effect, 1.5f));

            // Find Ui ingredient
            GameObject uiToremove = recipesUI[0].GetComponent<RecipeUIManager>().ingredientListsUI.Find(x => x.GetComponent<Image>().sprite == ingredient.GetComponent<Ingredient>().icon); 
            Destroy(uiToremove); // Destroy ingredient UI
            recipesUI[0].GetComponent<RecipeUIManager>().ingredientListsUI.Remove(uiToremove); // remove  UI ingredient in the list

            recipesUI[0].GetComponent<RecipeUIManager>().ingredientListsEnum.Remove(ingredient.GetComponent<Ingredient>().type); // remove  ingredient in Recipe

            // Check if Recipe is complete
            if (recipesUI[0].GetComponent<RecipeUIManager>().ingredientListsUI.Count == 0) // If there is no more ingredients in recipe
            {
                Destroy(recipesUI[0]);
                recipesUI.RemoveAt(0);
                LevelManager.instance.recipes.RemoveAt(0);
                if (LevelManager.instance.recipes.Count != 0)
                {
                    currentRecipe = LevelManager.instance.recipes[0];
                }
            }

            // Check if level is complete
            if (recipesUI.Count == 0)
            {
                checkIngredientValue = false;
                LevelManager.instance.FinishedLevel();
            }
        }
        else
        {
            // Generate Effect
            GameObject effect = Instantiate(badEffect);
            effect.transform.position = ingredient.transform.position;
            StartCoroutine(DestroyObject(effect, 2f));
        }
    }

    private bool CheckIngredient(GameObject ingredient) {
        bool result = false;
        result = recipesUI[0].GetComponent<RecipeUIManager>().ingredientListsEnum.Contains(ingredient.GetComponent<Ingredient>().type);

        return result;
    }


    IEnumerator DestroyObject(GameObject objectToDestroy, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Destroy(objectToDestroy);
    }
}
