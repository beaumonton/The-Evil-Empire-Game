
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float fireRate = 5f;
    public Transform firingPoint;
    public GameObject bulletPrefab;
    public Animator anim;

    float timeUntilFire;
    PlayerMovement pm;

    private void Start()
    {
        pm = gameObject.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        anim.SetBool("isShooting", false);
        if (Input.GetMouseButtonDown(0) && timeUntilFire < Time.time)
        {
            anim.SetBool("isShooting", true);
            Shoot();
            timeUntilFire = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        float angle = pm.isFacingRight ? 0f : 180f;
        Instantiate(bulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }
}
