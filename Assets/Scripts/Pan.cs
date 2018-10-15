using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Pan : MonoBehaviour {

    public AudioSource hitPan;

    private GameObject cookedIngredient;
    private int currentScore;
    public bool cookedIngredientInPan;

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


            currentScore++;
            //score.text = currentScore.ToString("0");
        }
    }

    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ingredient"))
        {
            if (other.gameObject == cookedIngredient)
            {
                Debug.Log("Ingredient stayed");
            }
        }
    }*/

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ingredient"))
        {
            cookedIngredientInPan = false;
        }
    }

    IEnumerator DoCheck()
    {
        yield return new WaitForSeconds(1.5f);
        if (cookedIngredientInPan&& cookedIngredient!=null)
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
