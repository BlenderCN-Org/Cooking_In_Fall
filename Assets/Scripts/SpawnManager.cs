using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    [Header("All Ingredients List")]
    [SerializeField] private Ingredient[] ingredients;

    [Header("Texts Order Spawning")]
    [SerializeField] private Text[] orders = new Text[3];

    [Header("Settings")]
    [SerializeField] private float reloadTime;
    [SerializeField] private float turnForce = 40;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Text spawnButtonText;

    private Ingredient[] ingredientsOrder = new Ingredient[3];
    private float reloadTimeTemp;
    private bool canSpawn = true;

    void Start()
    {
        InitializeOrderList();

        reloadTimeTemp = reloadTime;
        spawnButtonText.text = "Launch";
    }

    void InitializeOrderList()
    {
        for (int i = 0; i < ingredientsOrder.Length; i++)
        {
            int rand = Random.Range(0, ingredients.Length);
            ingredientsOrder[i] = ingredients[rand];
            orders[i].text = ingredientsOrder[i].name;
        }
    }

    public void Spawn()
    {
        if (canSpawn)
        {
            // Instantiate Ingredient and apply a torque
            Ingredient ingredient = Instantiate(ingredientsOrder[0], spawnPoint.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
            Vector3 directionTorque = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
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
        reloadTimeTemp = reloadTime;
        spawnButtonText.text = reloadTimeTemp.ToString("0");

        while (reloadTimeTemp > 0)
        {
            yield return new WaitForSeconds(1f);
            reloadTimeTemp -= 1;
            spawnButtonText.text = reloadTimeTemp.ToString("0");
        }

        // Spawn de nouveau possible
        canSpawn = true;
        spawnButtonText.text = "Launch";
        yield break;
    }
}
