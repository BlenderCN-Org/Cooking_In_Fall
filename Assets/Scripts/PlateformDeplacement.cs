using UnityEngine;

public class PlateformDeplacement : MonoBehaviour
{
    public enum TypeOfDeplacement { None, Horizontal, Vertical, DiagonalLeftToRight, DiagonalRightToLeft };

    [SerializeField] private TypeOfDeplacement direction; // down or left by default

    [SerializeField] private float minimum = -1.0F;
    [SerializeField] private float maximum = 1.0F;
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private float smoothTime = 0.3F; //Damp values

    private float t = 0.0f;
    private Vector3 velocity = Vector3.zero;
    private Vector3 targetPosition;

    // Update is called once per frame
    void Update()
    {
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
