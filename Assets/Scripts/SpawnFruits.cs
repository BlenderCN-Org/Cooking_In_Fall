using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpawnFruits : MonoBehaviour {

    public GameObject fruit;
    public Text buttonText;
    public Transform spawnPoint;
    public float reloadTime;

    private float _reloadTime;
    private bool canSpawn = true;

	// Use this for initialization
	void Start () {
        _reloadTime = reloadTime;
        buttonText.text = fruit.name;
	}

    public void Spawn() {

        if (canSpawn)
        {
            Instantiate(fruit, spawnPoint.position, Quaternion.identity);

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
        buttonText.text = fruit.name;
        yield break;
    }

}
