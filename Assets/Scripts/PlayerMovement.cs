using System.Collections;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    private float horizontal;
    public float jumpingPower = 16f;
    public float speed = 8f; // Speed of horizontal movement
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundChecker;
    [SerializeField] private LayerMask groundLayer; 

    private Animator animator;

    public bool isGrounded;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        isGrounded = IsGround();
        animator.SetBool("IsGrounded", isGrounded);
        

        horizontal = Input.GetAxisRaw("Horizontal");

        // Handle jumping
        if (Input.GetButtonDown("Jump") && IsGround()) // Ensure the player can only jump if nearly grounded
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
            //animator.SetFloat("JumpPower", jumpingPower);
            animator.SetTrigger("Jump");
        }
        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
            //animator.SetTrigger("Jump");
            
        }

       

        flip();

        
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
<<<<<<< HEAD

=======
        //if (rb.linearVelocityX > 0.1f)
        //{
            animator.SetFloat("HorizontalVelocity",rb.linearVelocityX);
        //}
>>>>>>> chris-animator-dumb
    }

    private bool IsGround()
    {
        //if(IsGround())
        bool isGround = Physics2D.OverlapCircle(groundChecker.position, 0.2f, groundLayer);
        
        return isGround;
    }
    /*
    private IEnumerator returnToIdle()
    {
        yield return new WaitForSeconds(0.2f);
        if (isGrounded) { animator.SetTrigger("ReturnToIdle"); }
    }*/

    private void flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
