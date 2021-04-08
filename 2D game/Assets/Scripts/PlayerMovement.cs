using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;
    public Animator anim;
    public BoxCollider2D playerCollider;
    public CircleCollider2D playerCrouchCollider;

    //stores jump force
    public float jumpForce = 25f;
 
    public Transform feet;
    public LayerMask groundLayers;

    [HideInInspector] public bool isFacingRight = true;

    float movementX;


    public void Update()
    {
        movementX = Input.GetAxisRaw("Horizontal"); 
        //movementX = Input.GetAxis("Horizontal"); Smoother Movement

        //Jump
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            Jump();
        }

        //Crouch with no horizontal movement
        if(Input.GetKey(KeyCode.S) && Mathf.Abs(movementX) == 0f && isGrounded())
        {
            anim.SetBool("isCrouching", true);
            DisableBoxCollider();
        }
        else
        {
            anim.SetBool("isCrouching", false);
            EnableBoxCollider();
        }

        //Sets run animation
        if (Mathf.Abs(movementX) > 0.05f/*&& sliding == false*/ && isGrounded())
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }


        //Flip player depending on direction
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
        //Debug.Log("SLIDING? " + sliding + " GROUNDED? = " + isGrounded());
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

    void DisableBoxCollider()
    {
        playerCollider.enabled = false;
        //Debug.Log("Collider.enabled = " + playerCollider.enabled);
    }

    void EnableBoxCollider()
    {
        playerCollider.enabled = true;
        //Debug.Log("Collider.enabled = " + playerCollider.enabled);
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
