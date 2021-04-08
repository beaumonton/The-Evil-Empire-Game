using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public float maxHealth = 1f;
    private float curHealth;
    public GameObject bulletPrefab;

    private void Start()
    {
        curHealth = maxHealth;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            curHealth -= bulletPrefab.GetComponent<Bullet>().bulletDamage;
            if(curHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
