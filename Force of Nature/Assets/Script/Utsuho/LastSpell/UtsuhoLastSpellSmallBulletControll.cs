using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtsuhoLastSpellSmallBulletControll : MonoBehaviour
{
    public float SpinSpeed;
    public float BulletCooldown;
    public GameObject BulletPrefab;

    public Transform Spawner1;
    public Transform Spawner2;

    static bool IsShoot = false;

    private void FixedUpdate()
    {
        BulletCooldown += Time.deltaTime;
        transform.eulerAngles += new Vector3(0, 0, SpinSpeed * Time.deltaTime);
        if(IsShoot == true)
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        float RandomNumber = Random.Range(0.02f, 0.2f);
        if(BulletCooldown > RandomNumber)
        {
            Instantiate(BulletPrefab, Spawner1.position, Spawner1.rotation);
            Instantiate(BulletPrefab, Spawner2.position, Spawner2.rotation);
            BulletCooldown = 0;
        }
        
    }
    public static void IsShootTrue()
    {
        IsShoot = true;
    }
}
