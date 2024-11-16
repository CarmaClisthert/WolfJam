using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private float horizontal;
    public float jump = 16f;
    private bool isFacingRight = true;
    public float speed = 8f; // Speed of horizontal movement


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Handle jumping
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.linearVelocity.y) < 0.01f) // Ensure the player can only jump if nearly grounded
        {
            rb.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
        }

        // Handle horizontal movement
        float moveInput = Input.GetAxis("Horizontal"); // Get input for horizontal movement (A/D or Left/Right keys)
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        
    }

    private void flip()
    {
        if (isFacingRight && horizontal < 0f || isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
