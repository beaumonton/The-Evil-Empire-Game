using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody2D rb;
    public LayerMask groundLayers;

    public Transform groundCheck;
    public Transform wallCheck;

    [HideInInspector] public bool isFacingRight = true;

    RaycastHit2D hitGround;
    RaycastHit2D hitWall;

    private void Update()
    {
        hitGround = Physics2D.Raycast(groundCheck.position, -transform.up, 1f, groundLayers);
        hitWall = Physics2D.Raycast(wallCheck.position, transform.right, 1f, groundLayers);
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
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(-transform.localScale.x, 3f, 3f); //These numbers MUST match transform values of sprite
            //Debug.Log("not hitting ground");
        }
    }
}
