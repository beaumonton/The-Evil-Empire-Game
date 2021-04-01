using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float fireRate = 5f;
    public Transform firingPoint;
    public GameObject bulletPrefab;
    public Animator anim;

    float timeUntilFire;
    EnemyPatrol ep;

    // Start is called before the first frame update
    void Start()
    {
        ep = gameObject.GetComponent<EnemyPatrol>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeUntilFire < Time.time)
        {
            Shoot();
            timeUntilFire = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        float angle = ep.isFacingRight ? 0f : 180f;
        Instantiate(bulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }
}
