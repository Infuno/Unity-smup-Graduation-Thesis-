using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform firepoint1;
    public Transform firepoint2;
    public GameObject BulletPrefab;
    public float RateOfFire;
    
    private bool IsFire;
    private float BulletCooldown;

    private void Update()
    {
        BulletCooldown += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Z))
        {
            IsFire = true;
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            IsFire = false;
        }
        if (IsFire == true)
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        if(BulletCooldown > RateOfFire)
        {
        Instantiate(BulletPrefab, firepoint1.position, firepoint1.rotation);
        Instantiate(BulletPrefab, firepoint2.position, firepoint2.rotation);
        BulletCooldown = 0;
            Shoot();
        }
        
    }


}
