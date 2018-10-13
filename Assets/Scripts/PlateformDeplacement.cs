using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class PlateformDeplacement : MonoBehaviour {

    [SerializeField]
    public enum TypeOfDeplacement {None, Horizontal, Vertical, DiagonalLeftToRight, DiagonalRightToLeft };

    [SerializeField]
    private TypeOfDeplacement direction; // down or left by default

    // animate the game object from -1 to +1 and back => move first towards min value
    public float minimum = -1.0F;
    public float maximum = 1.0F;

    public float speed = 0.5f;
    // starting value for the Lerp
    private float t = 0.0f;

    //Damp values
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    private Vector3 targetPosition;
    
	// Update is called once per frame
	void Update ()
    {
        // transform.position = new Vector3(Mathf.Lerp(minimum, maximum, t), 0, 0); => Default movment

        targetPosition = transform.position;
        switch (direction)
        {
            // Define target position, Lerp will be used to define min and max position
            case TypeOfDeplacement.Horizontal:
                targetPosition += new Vector3(Mathf.Lerp(minimum, maximum, t), 0, 0);
                break;
            case TypeOfDeplacement.Vertical:
                targetPosition += new Vector3(0, Mathf.Lerp(minimum, maximum, t), 0);
                break;
            case TypeOfDeplacement.DiagonalLeftToRight:
                targetPosition += new Vector3(Mathf.Lerp(minimum, maximum, t), Mathf.Lerp(minimum, maximum, t), 0);
                break;
            case TypeOfDeplacement.DiagonalRightToLeft:
                targetPosition += new Vector3(Mathf.Lerp(minimum, maximum, t), Mathf.Lerp(maximum, minimum, t), 0);
                break;
        }

        // Define a target position above and behind the target transform
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // .. and increase the t interpolater
        t += speed * Time.deltaTime;

        // now check if the interpolator has reached 1.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }
}
