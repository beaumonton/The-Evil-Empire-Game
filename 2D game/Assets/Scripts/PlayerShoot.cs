
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float fireRate = 5f;
    public Transform firingPoint;
    public Transform firingCrouchPoint;
    public Transform firingRunPoint;
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
        if (anim.GetBool("isCrouching"))
        {
            Instantiate(bulletPrefab, firingCrouchPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
        }
        else if(anim.GetBool("isRunning"))
        {
            Instantiate(bulletPrefab, firingRunPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
        }
        else
        {
            Instantiate(bulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
        }
    }
}
