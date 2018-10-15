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
    public float turnForce = 40;
    public Transform spawnPoint;

    [Space(15)]
    public Text spawnButtonText;

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

        spawnButtonText.text = "Launch";
	}

    public void Spawn() {

        if (canSpawn)
        {
            // Instantiate Ingredient and apply a torque
            Ingredient ingredient;
            ingredient = Instantiate(ingredientsOrder[0], spawnPoint.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
            Vector3 directionTorque = new Vector3(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            ingredient.gameObject.GetComponent<Rigidbody>().AddTorque(directionTorque * turnForce);

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
        spawnButtonText.text = _reloadTime.ToString("0");

        while (_reloadTime > 0)
        {
            yield return new WaitForSeconds(1f);
            _reloadTime -= 1;
            spawnButtonText.text = _reloadTime.ToString("0");
        }

        // Spawn de nouveau possible
        canSpawn = true;
        spawnButtonText.text = "Launch";
        yield break;
    }
}
