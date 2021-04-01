using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletRight: MonoBehaviour
{
    public float bulletSpeed = 50f;
    public float bulletDamage = 10f;
    public Rigidbody2D rb;

    private void FixedUpdate()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
