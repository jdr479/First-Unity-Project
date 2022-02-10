using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Reference to the Rigidbody component called rb
    public Rigidbody rb;

    public float forwardForce = 1000;
    public float sidewaysForce = 500;
    public bool moveRight = false;
    public bool moveLeft = false;

    // Update is called once per frame
    void Update()
    {
        moveRight = false;
        
        // Check if the "d" key is being pressed
        // Allows player to move right if so
        if(Input.GetKey("d"))
        {
            moveRight = true;
        }
        else
        {
            moveRight = false;
        }

        // Checks if the "a" key is being pressed
        // Allows player to move left if so
        if(Input.GetKey("a"))
        {
            moveLeft = true;
        }
        else
        {
            moveLeft = false;
        }
    }
    
    // Marked as "FixedUpdate" because we are
    // Using it to mess with physics
    void FixedUpdate()
    {
        // Add a forward force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        // Check if player is pressing "d" key
        // Adds a rightward force if so
        if(moveRight)
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        // Check if player is pressing "a" key
        // Adds a leftward force if so
        if (moveLeft)
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
