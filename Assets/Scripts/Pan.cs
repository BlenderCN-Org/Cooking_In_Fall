using System.Collections;
using UnityEngine;

public class Pan : MonoBehaviour {

    public AudioSource hitPan;
    public bool cookedIngredientInPan;

    private GameObject cookedIngredient;
    //private int currentScore;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ingredient"))
        {
            cookedIngredient = other.gameObject;
            cookedIngredientInPan = true;
            StartCoroutine("DoCheck");

            //Play Sound
            hitPan.pitch = Random.Range(0.5f, 2f);
            hitPan.Play();

            //currentScore++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ingredient"))
        {
            cookedIngredientInPan = false;
        }
    }

    IEnumerator DoCheck()
    {
        yield return new WaitForSeconds(1f);
        if (cookedIngredientInPan && cookedIngredient!=null)
        {
            RecipeManager.recipeManagerInstance.IngredientInPan(cookedIngredient);
            Destroy(cookedIngredient);
            cookedIngredient = null;
        }
        else
        {
            cookedIngredientInPan = false;
        }
    }
}
