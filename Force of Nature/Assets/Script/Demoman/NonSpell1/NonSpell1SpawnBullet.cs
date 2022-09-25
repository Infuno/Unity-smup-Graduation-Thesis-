using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonSpell1SpawnBullet : MonoBehaviour
{
    public Transform firepoint1;
    public Transform firepoint2;
    public Transform firepoint3;
    public GameObject BulletPrefab;
    public GameObject Spinner;
    public float RateOfFire;
    public float FiringDurarion;
    public float ShotCooldown;
    public float SpinSpeed;

    private bool IsFire;
    private float BulletCooldown;
    private void FixedUpdate()
    {
        BulletCooldown += Time.deltaTime;
        if (IsFire == true)
        {
            Shoot();
            StartCoroutine(Duration(FiringDurarion));
            Spin();
        }
        if (IsFire == false)
        {
            StartCoroutine(Cooldown(ShotCooldown));
            Spinner.transform.eulerAngles = new Vector3(0, 0, 270);
        }
    }
    private void Shoot()
    {
        if (BulletCooldown > RateOfFire)
        {
            Instantiate(BulletPrefab, firepoint1.position, firepoint1.rotation);
            Instantiate(BulletPrefab, firepoint2.position, firepoint2.rotation);
            Instantiate(BulletPrefab, firepoint3.position, firepoint3.rotation);
            BulletCooldown = 0;
            Shoot();
        }

    }
    private void Spin()
    {
        Spinner.transform.eulerAngles += new Vector3(0, 0, SpinSpeed * Time.deltaTime);
    }
    IEnumerator Duration(float timer)
    {
        yield return new WaitForSeconds(timer);
        IsFire = false;
    }
    IEnumerator Cooldown(float timer)
    {
        yield return new WaitForSeconds(timer);
        IsFire = true;
    }
}
