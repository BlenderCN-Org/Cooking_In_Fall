using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Generates UI for recipe
// Ex : Tomato soup = 2 tomatoes
// Tomato soup
// 2 Tomato
public class RecipeNew : MonoBehaviour {
    public string recipeName;
    public Ingredients[] recipe;

    public Transform parentIngredients;
    public GameObject prefabIngredient;

    private void Start()
    {
        // Init UI
        this.gameObject.transform.Find("Name").GetComponent<Text>().text = recipeName; // Replace recipe name
        foreach (Ingredients ing in recipe) // Create ingredients
        {
            GameObject newIng = Instantiate(prefabIngredient,parentIngredients);
            newIng.transform.GetChild(0).GetComponent<Text>().text = ing.number + " : "+ ing.type;
        }

    }
}
