// Gives access to MonoBehaviour and Mathf
using UnityEngine;

// Floats this object up and down forever using Sin
public class Bobber : MonoBehaviour
{
    // How far up and down it floats
    [SerializeField] private float bobHeight = 0.5f;
    // How fast it floats
    [SerializeField] private float bobSpeed = 3f;

    // Where it started, so it floats around that height
    private float startY;

    // Runs once when the scene starts
    private void Start()
    {
        // Remember the starting height
        startY = transform.position.y;
    }

    // Runs every frame
    private void Update()
    {
        // Sin swings between -1 and 1; times bobHeight makes the swing bigger
        float y = startY + Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        // Same x, new y
        transform.position = new Vector3(transform.position.x, y, 0f);
    }
}