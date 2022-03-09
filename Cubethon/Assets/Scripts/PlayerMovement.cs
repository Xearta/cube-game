using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 2000f;
    private float touchSidewaysForce = 500f;
    private float keyboardSidewaysForce = 50f;
    public float sidewaysForce = 500f;
    public float levelNumber = 1;

    // We marked this as "Fixed"Update because we
    // are using it to mess with physics.
    void FixedUpdate()
    {
        // Forward force
        // Time.deltaTime will normalize the physics based on framerate
        rb.AddForce(0, 0, (forwardForce * levelNumber * Time.deltaTime));

        // Right Force
        if (SwipeManager.swipeRight)
        {
            rb.AddForce(touchSidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        } 
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(keyboardSidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        // Left Force
        if (SwipeManager.swipeLeft)
        {
            rb.AddForce(-touchSidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-keyboardSidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        // If you fall off, restart level
        if (rb.position.y < 0f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

    }
}
