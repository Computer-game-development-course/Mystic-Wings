using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{

    [Tooltip("The movement speed of the player.")]
    [SerializeField] float speed = 5f;

    public static bool raceStarted = false; // A flag to check if the race has started. It's static so other scripts can access it.

    void Start()
    {
        // Setting raceStarted to false initially. This prevents the player from moving until the race officially starts.
        raceStarted = false;
    }

    void Update()
    {
        // Check for player inputs to move the character.
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Move left if the left arrow key is pressed.
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Move right if the right arrow key is pressed.
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // Move up if the up arrow key is pressed.
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            // Move down if the down arrow key is pressed.
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }

        // Start the race if it hasn't already started.
        if (!raceStarted)
        {
            StartRace();
        }
    }

    // This function is called to start the race.
    public void StartRace()
    {
        raceStarted = true; // Setting the flag to true, which enables the player's movement.
    }

    // This function is triggered when the player collides with another object.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check what the player has collided with.
        if (other.tag == "bomb")
        {
            // Destroy the bomb and reduce speed.
            Destroy(other.gameObject);
            // Reduce speed more drastically if the speed is higher.
            if (speed >= 2)
            {
                speed -= 1f;
            }
            else if (speed >= 0.2f)
            {
                // For lower speeds, reduce it gradually.
                speed -= 0.1f;
            }
        }
        else if (other.tag == "speed")
        {
            // Destroy the speed power-up and increase the player's speed.
            Destroy(other.gameObject);
            speed += 1f;
        }
        else if (other.tag == "Finish")
        {
            // Load the 'red_fairy_win' scene when the player reaches the finish line.
            SceneManager.LoadScene("red_fairy_win");
        }
    }
}