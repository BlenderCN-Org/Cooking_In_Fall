using UnityEngine;

public class DealDamage : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ingredient"))
        {
            Destroy(other.gameObject);
        }
    }
}
