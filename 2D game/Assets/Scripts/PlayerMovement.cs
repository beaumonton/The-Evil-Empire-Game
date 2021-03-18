using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;
    public Animator anim;
    public BoxCollider2D playerCollider;

    public float crouchHeightPercent = 0.5f;
    private Vector2 standColliderSize;
    private Vector2 standColliderOffset;
    private Vector2 crouchColliderSize;
    private Vector2 crouchColliderOffset;


    public float jumpForce = 30f;
    public Transform feet;
    public LayerMask groundLayers;

    [HideInInspector] public bool isFacingRight = true;

    float movementX;

    private void Awake()
    {
        standColliderSize = playerCollider.size;
        standColliderOffset = playerCollider.offset;

        crouchColliderSize = new Vector2(standColliderSize.x, standColliderSize.y * crouchHeightPercent);
        crouchColliderOffset = new Vector2(standColliderOffset.x, standColliderOffset.y * crouchHeightPercent);
    }

    public void Update()
    {
        movementX = Input.GetAxisRaw("Horizontal"); 
        //movementX = Input.GetAxis("Horizontal"); Smoother Movement

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            Jump();
        }

        if(Input.GetKey(KeyCode.S) && isGrounded())
        {
            anim.SetBool("isCrouching", true);
            Crouch();
        }
        else
        {
            anim.SetBool("isCrouching", false);
            StandUp();
        }

        if(Mathf.Abs(movementX) > 0.05f)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (movementX > 0f) //If Player is moving right
        {
            transform.localScale = new Vector3(3f, 3f, 3f); //Must equal Player Object's scale values
            isFacingRight = true;
        }
        else if (movementX < 0f)//If Player is moving left
        {
            transform.localScale = new Vector3(-3f, 3f, 3f); //Must equal Player Object's scale values with -1 * x value
            isFacingRight = false;
        }

        anim.SetBool("isGrounded", isGrounded());
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(movementX * movementSpeed, rb.velocity.y);

        rb.velocity = movement;
    }

    void Jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);

        rb.velocity = movement;
    }

    void Crouch()
    {
        playerCollider.size = crouchColliderSize;
        playerCollider.offset = crouchColliderOffset;
    }

    void StandUp()
    {
        playerCollider.size = standColliderSize;
        playerCollider.offset = standColliderOffset;
    }

    public bool isGrounded() //Returns true if player is on the ground
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if(groundCheck != null)
        {
            return true;
        }
        return false;
    }
}
