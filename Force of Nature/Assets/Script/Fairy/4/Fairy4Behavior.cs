using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy4Behavior : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject BulletPrefab;
    public Transform BulletPoint;
    public float RateOfFire;
    public Transform ParentPoint;
    public float ShotDuration;
    public float ShotCooldown;


    private bool IsShoot = true;
    private float BulletCooldown;

    private void Start()
    {
        StartCoroutine(ShootOn());
    }
    private void Update()
    {

        transform.position = ParentPoint.position;
        transform.rotation = Quaternion.Euler(0, 0, 0);

        BulletCooldown += Time.deltaTime;
        if(IsShoot == true)
        {
            Shoot();
        }
        
    }
    private void Shoot()
    {
        if (BulletCooldown > RateOfFire)
        {
            Instantiate(BulletPrefab, BulletPoint.position, BulletPoint.rotation);
            BulletCooldown = 0;
        }
    }
    IEnumerator ShootOn()
    {
        yield return new WaitForSeconds(ShotDuration);
        IsShoot = false;
        StartCoroutine(ShootOff());
    }
    IEnumerator ShootOff()
    {
        yield return new WaitForSeconds(ShotCooldown);
        IsShoot = true;
        StartCoroutine(ShootOn());
    }
}
