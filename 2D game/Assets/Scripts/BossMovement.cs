using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 25f;
    public Rigidbody2D rb;

    public Animator anim;

    public Transform feet;
    public LayerMask groundLayers;

    public Transform groundCheck;
    public Transform wallCheck;

    public bool isFacingRight = true;

    RaycastHit2D hitGround;
    RaycastHit2D hitWall;

    float mx;

    private void Update()
    {
        hitGround = Physics2D.Raycast(groundCheck.position, -transform.up, 1f, groundLayers);
        hitWall = Physics2D.Raycast(wallCheck.position, transform.right, 1f, groundLayers);
        anim.SetBool("isRunning", true);
        anim.SetBool("isGrounded", isGrounded());
    }

    private void FixedUpdate()
    {
        if (hitWall.collider != true)
        {
            if (isFacingRight)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }
        else
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(-transform.localScale.x, 3f, 3f); //These numbers MUST match transform values of sprite
            //Debug.Log("not hitting wall");
        }


        if (hitGround.collider != false)
        {
            if (isFacingRight)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            //Debug.Log("hitting ground");
        }
        else
        {
            if(isGrounded())
            {
                Jump();
            }
            //isFacingRight = !isFacingRight;
            //transform.localScale = new Vector3(-transform.localScale.x, 3f, 3f); //These numbers MUST match transform values of sprite
            //Debug.Log("not hitting ground");
        }
    }

    void Jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
        rb.velocity = movement;
    }

    public bool isGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if (groundCheck != null)
        {
            return true;
        }
        return false;
    }
}
