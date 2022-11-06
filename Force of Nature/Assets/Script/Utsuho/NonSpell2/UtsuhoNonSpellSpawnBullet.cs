using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtsuhoNonSpellSpawnBullet : MonoBehaviour
{
    public GameObject BulletPrefab;
    public UtsuhoGetPlayerLocation PlayerZLocation;
    public float RateOfFire;

    private float BulletCooldown;
    private void SetLocation()
    {
        transform.localPosition = new Vector3 (0, -PlayerZLocation.GetCurrentZ(),0);
    }
    private void Update()
    {
        BulletCooldown += Time.deltaTime;
        SetLocation();
        Fire();
    }
    private void Fire()
    {
        if (BulletCooldown > RateOfFire)
        {
            Instantiate (BulletPrefab, transform.position, transform.rotation);
            BulletCooldown = 0;
        } 
    }

}
