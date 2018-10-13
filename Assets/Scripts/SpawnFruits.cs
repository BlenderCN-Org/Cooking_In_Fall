using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpawnFruits : MonoBehaviour {

    [Header("All Ingredients List")]
    // On récupère tout les prefabs ingredients
    public Ingredient[] ingredients;

    [Header("Current Order Spawning")]
    // On crée notre liste d'attente
    public Ingredient[] ingredientsOrder = new Ingredient[3];

    [Header("Texts Order Spawning")]
    public Text[] orders = new Text[3];

    [Header("Settings")]
    public float reloadTime;
    public Transform spawnPoint;

    [Space(15)]
    public Text buttonText;

    private float _reloadTime;
    private bool canSpawn = true;

	// Use this for initialization
	void Start () {
        _reloadTime = reloadTime;

        // Initialisation de la liste d'attente
        for (int i = 0; i < ingredientsOrder.Length; i++)
        {
            int rand = Random.Range(0, ingredients.Length);
            ingredientsOrder[i] = ingredients[rand];
            orders[i].text = ingredientsOrder[i].name;
        }

        buttonText.text = "Launch";
	}

    public void Spawn() {

        if (canSpawn)
        {
            Instantiate(ingredientsOrder[0], spawnPoint.position, Quaternion.identity);

            // Update Order
            ingredientsOrder[0] = ingredientsOrder[1];
            ingredientsOrder[1] = ingredientsOrder[2];
            ingredientsOrder[2] = ingredients[Random.Range(0, ingredients.Length)];

            // Update Texts
            for (int i = 0; i < orders.Length; i++)
            {
                orders[i].text = ingredientsOrder[i].name;
            }

            // On recharge le temps de spawn
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        canSpawn = false;

        // On affiche le temps sur le boouton
        _reloadTime = reloadTime;
        buttonText.text = _reloadTime.ToString("0");

        while (_reloadTime > 0)
        {
            yield return new WaitForSeconds(1f);
            _reloadTime -= 1;
            buttonText.text = _reloadTime.ToString("0");
        }

        // Spawn de nouveau possible
        canSpawn = true;
        buttonText.text = "Launch";
        yield break;
    }
}
