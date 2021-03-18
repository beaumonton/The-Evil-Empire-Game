using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;

    public Animator anim;

    public float jumpForce = 30f;
    public Transform feet;
    public LayerMask groundLayers;

    float movementX;

    public void Update()
    {
        movementX = Input.GetAxisRaw("Horizontal"); 
        //movementX = Input.GetAxis("Horizontal"); Smoother Movement

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            Jump();
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
        }
        else if (movementX < 0f)//If Player is moving left
        {
            transform.localScale = new Vector3(-3f, 3f, 3f); //Must equal Player Object's scale values with -1 * x value
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
