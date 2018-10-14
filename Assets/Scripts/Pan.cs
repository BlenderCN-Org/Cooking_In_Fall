using UnityEngine;
using UnityEngine.UI;

public class Pan : MonoBehaviour {

    public GameObject effects;

    private GameObject cookedIngredient;

    private int currentScore;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ingredient"))
        {
            RecipeManager.recipeManagerInstance.IngredientInPan(other.gameObject);
            cookedIngredient = other.gameObject;
            currentScore++;
            //score.text = currentScore.ToString("0");
        }
    }


}
