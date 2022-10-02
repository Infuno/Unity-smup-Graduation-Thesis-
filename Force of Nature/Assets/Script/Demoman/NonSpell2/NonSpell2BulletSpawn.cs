using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonSpell2BulletSpawn : MonoBehaviour
{
    public Transform[] FirePoint;
    public GameObject BulletPrefab;
    public Transform Player;

    public float RateOfFire;
    public bool TurnLeft = true;

    private float BulletCooldown;
    private void FixedUpdate()
    {
        Rotate();
        BulletCooldown += Time.deltaTime;
        Shoot();
    }
    private void Rotate()
    {
        if (TurnLeft == true)
        {
            transform.eulerAngles += new Vector3(0, 0, 1);
        }
        if (TurnLeft == false)
        {
            transform.eulerAngles -= new Vector3(0, 0, 1);
        }
        if (transform.eulerAngles.z >= 250 )
        {
            TurnLeft = false;
        }
        if (transform.eulerAngles.z <= 120 )
        {
            TurnLeft = true;
        }
    }
    private void Shoot()
    {
        if (BulletCooldown >= RateOfFire)
        {
            Instantiate(BulletPrefab, FirePoint[0].position, FirePoint[0].rotation);
            Instantiate(BulletPrefab, FirePoint[1].position, FirePoint[1].rotation);
            Instantiate(BulletPrefab, FirePoint[2].position, FirePoint[2].rotation);
            Instantiate(BulletPrefab, FirePoint[3].position, FirePoint[3].rotation);
            Instantiate(BulletPrefab, FirePoint[4].position, FirePoint[4].rotation);
            Instantiate(BulletPrefab, FirePoint[5].position, FirePoint[5].rotation);
            Instantiate(BulletPrefab, FirePoint[6].position, FirePoint[6].rotation);
            Instantiate(BulletPrefab, FirePoint[7].position, FirePoint[7].rotation);
            Instantiate(BulletPrefab, FirePoint[8].position, FirePoint[8].rotation);
            BulletCooldown = 0;
            Shoot();
        }
    }
}

