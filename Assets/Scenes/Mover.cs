// Gives access to MonoBehaviour and Vector2
using UnityEngine;
// Gives access to Keyboard
using UnityEngine.InputSystem;

// Moves this object with WASD; diagonals are the same speed as straight lines
public class KeyMover : MonoBehaviour
{
    // How fast it moves
    [SerializeField] private float speed = 4f;

    // Runs every frame
    private void Update()
    {
        // Start with no movement
        Vector2 direction = Vector2.zero;

        // Up and down
        if (Keyboard.current.wKey.isPressed)
        {
            direction.y = 1f;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            direction.y = -1f;
        }

        // Left and right
        if (Keyboard.current.aKey.isPressed)
        {
            direction.x = -1f;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            direction.x = 1f;
        }

        // Length 1, so diagonals aren't faster
        direction = direction.normalized;

        // Start from the normal speed
        float currentSpeed = speed;
        // Shift held: multiply by a scalar to go twice as fast
        if (Keyboard.current.leftShiftKey.isPressed)
        {
            currentSpeed = speed * 2f;
        }

        // Vector times scalars
        transform.Translate(direction * currentSpeed * Time.deltaTime);
    }
}