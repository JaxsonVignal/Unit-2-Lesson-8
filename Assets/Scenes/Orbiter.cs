// Gives access to MonoBehaviour and Mathf
using UnityEngine;

// Moves this object around another object using Cos and Sin
public class Orbiter : MonoBehaviour
{
    // The object to circle around
    [SerializeField] private Transform center;
    // How far across the circle reaches
    [SerializeField] private float width = 1.5f;
    // How far up and down it reaches
    [SerializeField] private float height = 1.5f;
    // How many degrees it turns each second
    [SerializeField] private float degreesPerSecond = 180f;

    // Where it is around the circle right now, in degrees
    private float angle;

    // Runs every frame
    private void Update()
    {
        // Turn a little further around the circle
        angle += degreesPerSecond * Time.deltaTime;
        // Mathf.Sin and Mathf.Cos want radians
        float radians = angle * Mathf.Deg2Rad;

        // Cos gives how far across, Sin gives how far up
        float x = Mathf.Cos(radians) * width;
        float y = Mathf.Sin(radians) * height;

        // The same point, but around the center instead of around (0, 0)
        transform.position = center.position + new Vector3(x, y, 0f);
    }
}