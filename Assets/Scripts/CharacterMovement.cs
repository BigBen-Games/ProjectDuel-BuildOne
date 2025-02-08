using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;    // Speed of movement
    public float jumpForce = 5f;    // Force applied when jumping
    public int maxJumpCount; //how many times a character can jump
    float jumpCount = 0; //the current number of jumps
    private Rigidbody2D rb;         // Rigidbody2D component

    private bool isGrounded;        // Check if the player is on the ground

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    void Update()
    {
        // Equations for this build by Microsoft Copilot
        
        // Move left and right
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Jumping
        if (Input.GetKeyDown(KeyCode.W) && (isGrounded | jumpCount < maxJumpCount))
        {
            rb.velocity = new Vector2(rb.velocity.x, (jumpForce + jumpCount));
            jumpCount++;
            isGrounded = false; // Player is no longer on the ground
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }
}
