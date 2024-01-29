using UnityEngine;

public class Camera2Follow : MonoBehaviour
{
    [Tooltip("Reference to the player's Transform component. Assign the player GameObject here.")]
    [SerializeField] Transform player;

    [Tooltip("Vertical offset for the camera relative to the player's position.")]
    [SerializeField] float offsetY = 1.0f;

    private bool shouldFollow = false; // Flag to determine if the camera should start following the player.

    void Start()
    {
        // Set the initial camera position based on the player's position plus the vertical offset.
        // This is done to align the camera with the player at the start of the game.
        if (player != null)
        {
            Vector3 startPosition = new Vector3(transform.position.x, player.position.y + offsetY, transform.position.z);
            transform.position = startPosition;
        }
    }

    void Update()
    {
        // Check if the camera should start following the player. This is dependent on the race start condition.
        if (!shouldFollow)
        {
            // Accessing the 'raceStarted' variable from the player's script to check if the race has begun.
            // Ensure the player's script with the 'raceStarted' variable is correctly referenced here.
            shouldFollow = Move2.raceStarted;
            if (!shouldFollow)
            {
                return; // If the race hasn't started, exit the update function and don't move the camera.
            }
        }

        // Once the race starts, follow the player's movement along the Y axis.
        // The camera maintains its original X and Z positions and only changes its Y position.
        if (player != null)
        {
            Vector3 newPosition = new Vector3(transform.position.x, player.position.y + offsetY, transform.position.z);
            transform.position = newPosition;
        }
    }
}
