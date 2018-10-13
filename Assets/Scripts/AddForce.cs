using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour {

    public float power;

    private void Update()
    {
        Debug.DrawLine(transform.position, transform.position + transform.up * power, Color.red);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ingredient"))
        {
            other.GetComponent<Rigidbody>().AddForce(transform.up * power);
        }
    }
}
