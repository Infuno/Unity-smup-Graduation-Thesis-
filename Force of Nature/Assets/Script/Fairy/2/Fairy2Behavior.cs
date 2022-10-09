using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy2Behavior : MonoBehaviour
{
    public Transform BulletPoint;
    public float RateOfFire;
    public float ShootTime;
    public float Cooldown;
    public GameObject BulletPrefab;
    public Transform ParentPoint;

    private float BulletCooldown;
    
    private bool attack = true;

    private void Update()
    {
        transform.position = ParentPoint.position;
    }
    void FixedUpdate()
    {
        BulletCooldown += Time.deltaTime;
        if(attack == true)
        {
            Shoot();
            StartCoroutine(ShootDuration(ShootTime));
            return;
        }
        if (attack == false)
        {
            StartCoroutine(HoldDuration(Cooldown));
            return;
        }
    }
    public void Shoot()
    {
        if (BulletCooldown > RateOfFire)
        {
            Instantiate(BulletPrefab, BulletPoint.position, BulletPoint.rotation);
            BulletCooldown = 0;
        }
    }
    IEnumerator ShootDuration(float timer)
    {
        yield return new WaitForSeconds(timer);
        attack = false;
    }
    IEnumerator HoldDuration(float timer)
    {
        yield return new WaitForSeconds(timer);
        attack = true;
    }


}
