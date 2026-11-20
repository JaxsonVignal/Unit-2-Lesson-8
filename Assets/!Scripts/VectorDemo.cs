using UnityEngine;

public class VectorDemo : MonoBehaviour
{
    [SerializeField] Vector2 direction = new Vector2(1f, 0f);
    [SerializeField] private float speed = 5f;

    [SerializeField] private bool normalized;

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = direction;

        if (normalized)
        {
            moveDirection = direction;
        }

        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}
