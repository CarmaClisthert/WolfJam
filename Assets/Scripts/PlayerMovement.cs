using System.Collections;
using Unity.VisualScripting;
//using UnityEditor.Tilemaps;
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

    public GameObject dialogueBox;

    private Animator animator;

    public bool isGrounded;

    public DialogueTrigger dialogueTrigger;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.L) || (Input.GetKey(KeyCode.F)))
        {
            CutScene();
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        // Handle jumping
        if (Input.GetButtonDown("Jump") && IsGround()) // Ensure the player can only jump if nearly grounded
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
            //animator.SetFloat("JumpPower", jumpingPower);
            animator.SetBool("isJumping", true);
        }
        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
            //animator.SetTrigger("Jump");
            
        }

        isGrounded = IsGround();
        animator.SetBool("IsGrounded", isGrounded);
        if (!isGrounded && animator.GetBool("isJumping") ){ animator.SetBool("isJumping", false); }

        flip();

        
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);

        //if (rb.linearVelocityX > 0.1f)
        //{
            animator.SetFloat("HorizontalVelocity",rb.linearVelocityX);
        //}
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

    private void CutScene()
    {
        // var gooncontainer = GameObject.Find("UIPrefab");
        //dialogueBox.SetActive(true);
        dialogueTrigger.isBanished = true;
    }
}
