using UnityEngine;
using UnityEngine.SceneManagement;

public class Move2 : MonoBehaviour
{
    [Tooltip("The movement speed of the player.")]
    [SerializeField] float speed = 5f;

    public static bool raceStarted = false; // A flag to determine if the race has begun. It's static so it can be accessed by other scripts like CameraFollow.

    void Start()
    {
        // Setting raceStarted to false initially, ensuring the player doesn't move until the race starts.
        raceStarted = false;
    }

    void Update()
    {
        // Handling player movement using keyboard inputs.
        if (Input.GetKey(KeyCode.A))
        {
            // Move left when the 'A' key is pressed.
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            // Move right when the 'D' key is pressed.
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            // Move up when the 'W' key is pressed.
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            // Move down when the 'S' key is pressed.
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
        // Starting the race if it hasn't already started.
        if (!raceStarted)
        {
            StartRace();
        }
    }

    // This method is called to officially start the race.
    public void StartRace()
    {
        raceStarted = true; // Setting the flag to true allows the player to start moving.
    }

    // This method handles collision events with other objects.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Checking the tag of the colliding object to determine the appropriate action.
        if (other.tag == "bomb")
        {
            // If collided with a bomb, destroy the bomb and adjust speed accordingly.
            Destroy(other.gameObject); // Destroy the bomb.
            // Adjust the speed based on current speed.
            if (speed >= 2)
            {
                speed -= 1f;
            }
            else if (speed >= 0.2f)
            {
                speed -= 0.1f;
            }
        }
        else if (other.tag == "speed")
        {
            // If collided with a speed power-up, destroy it and increase speed.
            Destroy(other.gameObject); // Destroy the speed power-up.
            speed += 1f;
        }
        else if (other.tag == "Finish")
        {
            // If the player reaches the finish line, load the winning scene.
            SceneManager.LoadScene("blue_fairy_win"); // Load the scene where the blue fairy wins.
        }
    }
}
