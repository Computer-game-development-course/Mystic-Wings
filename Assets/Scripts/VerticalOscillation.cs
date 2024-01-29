using UnityEngine;

public class VerticalOscillation : MonoBehaviour
{
    [Tooltip("The maximum vertical distance the player moves up or down from the starting point.")]
    [SerializeField] float amplitude = 5f;

    [Tooltip("The speed of the vertical oscillation. Higher values make the movement faster.")]
    [SerializeField] float frequency = 1f;

    private float originalY; // Variable to keep track of the player's original y-position.

    void Start()
    {
        // Storing the initial y-position of the player to use as a base for the oscillation.
        originalY = transform.position.y;
    }

    void Update()
    {
        // Creating a vertical oscillation effect using the sine function.
        // The sine wave creates a smooth up-and-down motion.
        float newY = originalY + amplitude * Mathf.Sin(Time.time * frequency);

        // Applying the calculated y-position to the player while keeping the x and z positions the same.
        // This results in a vertical movement only.
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
