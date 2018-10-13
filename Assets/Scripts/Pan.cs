using UnityEngine;
using UnityEngine.UI;

public class Pan : MonoBehaviour {

    public Text score;

    private int currentScore;

	// Use this for initialization
	void Start () {
        currentScore = 0;
        //score.text = currentScore.ToString("0");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ingredient"))
        {
            RecipeManager.recipeManagerInstance.IngredientInPan(other.gameObject);
            Destroy(other.gameObject);
            currentScore++;
            score.text = currentScore.ToString("0");
        }
    }
}
