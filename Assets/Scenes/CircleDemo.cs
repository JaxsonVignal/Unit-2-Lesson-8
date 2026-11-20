// Gives access to MonoBehaviour and Mathf
using UnityEngine;

// Moves this object around a circle (or an ellipse) using Cos and Sin
public class CircleDemo : MonoBehaviour
{
    // How far across the circle reaches
    [SerializeField] private float width = 3f;
    // How far up and down it reaches; different from width makes an ellipse
    [SerializeField] private float height = 3f;
    // How many degrees it turns each second
    [SerializeField] private float degreesPerSecond = 90f;

    // Where it is around the circle right now, in degrees
    private float angle;

    // Runs every frame
    private void Update()
    {
        // Turn a little further around the circle
        angle += degreesPerSecond * Time.deltaTime;

        // Mathf.Sin and Mathf.Cos want radians, not degrees
        float radians = angle * Mathf.Deg2Rad;

        // Cos gives how far across, Sin gives how far up
        float x = Mathf.Cos(radians) * width;
        float y = Mathf.Sin(radians) * height;

        // Put the object at that point
        transform.position = new Vector3(x, y, 0f);
    }
}