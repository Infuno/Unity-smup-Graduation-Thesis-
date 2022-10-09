using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigFairy1Behavior : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject BulletPrefab;
    public Transform BulletPoint1;
    public Transform BulletPoint2;

    public float RateOfFire;
    public Transform ParentPoint;

    private bool IsShoot = false;
    private float BulletCooldown;
    private void Start()
    {
        StartCoroutine(Shooting());
    }
    private void Update()
    {
        transform.position = ParentPoint.position;
        transform.rotation = Quaternion.Euler(0, 0, 0);

        BulletCooldown += Time.deltaTime;
        Shoot();
    }
    private void Shoot()
    {
        if (BulletCooldown > RateOfFire && IsShoot == true)
        {
            Instantiate(BulletPrefab, BulletPoint1.position, BulletPoint1.rotation);
            Instantiate(BulletPrefab, BulletPoint2.position, BulletPoint2.rotation);
            BulletCooldown = 0;
        }
    }
    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(1f);
        IsShoot = true;
    }
}

