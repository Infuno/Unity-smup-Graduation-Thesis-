using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigFairy2Behavior : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject BulletPrefab;
    public Transform BulletPoint1;
    public Transform BulletPoint2;
    public Transform BulletPoint3;
    public Transform BulletPoint4;
    public Transform BulletPoint5;
    public Transform BulletPoint6;

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
            Instantiate(BulletPrefab, BulletPoint3.position, BulletPoint3.rotation);
            Instantiate(BulletPrefab, BulletPoint4.position, BulletPoint4.rotation);
            Instantiate(BulletPrefab, BulletPoint5.position, BulletPoint5.rotation);
            Instantiate(BulletPrefab, BulletPoint6.position, BulletPoint6.rotation);
            BulletCooldown = 0;
        }
    }
    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(1f);
        IsShoot = true;
    }
}
