using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public float fireRate = 5f;
    public Transform firingPoint;
    public GameObject bulletPrefab;
    //public Animator anim;

    float timeUntilFire;
    BossMovement bm;

    // Start is called before the first frame update
    void Start()
    {
        bm = gameObject.GetComponent<BossMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeUntilFire < Time.time)
        {
            Shoot();
            timeUntilFire = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        float angle = bm.isFacingRight ? 0f : 180f;
        Instantiate(bulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }
}
