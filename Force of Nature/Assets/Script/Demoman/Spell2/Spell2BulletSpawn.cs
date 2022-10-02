using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell2BulletSpawn : MonoBehaviour
{
    public Transform DownLeft;
    public Transform DownRight;
    public Transform UpLeft;
    public Transform UpRight;

    public GameObject BulletPrefab1;
    public GameObject BulletPrefab2;
    public GameObject BulletPrefab3;
    public GameObject BulletPrefab4;
    public GameObject BulletPrefab5;

    public float RateOfFire;
    public float SpinSpeed;
    public GameObject Lazer;

    private float BulletCooldown;
    private void Start()
    {
        Lazer.SetActive(true);
    }
    private void FixedUpdate()
    {
        BulletCooldown += Time.deltaTime;
        SpinDownLeft();

        SpinDownRight();
        SpinUpLeft();
        SpinUpRight();

        Shoot(BulletPrefab1);
        Shoot(BulletPrefab2);
        Shoot(BulletPrefab3);
        Shoot(BulletPrefab4);
        Shootend(BulletPrefab5);
        
    }
    private void Shoot(GameObject BulletPrefab)
    {
        if (BulletCooldown > RateOfFire)
        {
            Instantiate(BulletPrefab, DownLeft.position, DownLeft.rotation);
            Instantiate(BulletPrefab, DownRight.position, DownRight.rotation);
            Instantiate(BulletPrefab, UpLeft.position, UpLeft.rotation);
            Instantiate(BulletPrefab, UpRight.position, UpRight.rotation);
            
            //Shoot(BulletPrefab);
        }
    }
    private void Shootend(GameObject BulletPrefab)
    {
        if (BulletCooldown > RateOfFire)
        {
            Instantiate(BulletPrefab, DownLeft.position, DownLeft.rotation);
            Instantiate(BulletPrefab, DownRight.position, DownRight.rotation);
            Instantiate(BulletPrefab, UpLeft.position, UpLeft.rotation);
            Instantiate(BulletPrefab, UpRight.position, UpRight.rotation);
            BulletCooldown = 0;
            Shoot(BulletPrefab);
        }
    }
    private void SpinDownLeft()
    {
        DownLeft.transform.eulerAngles += new Vector3(0, 0, SpinSpeed * Time.deltaTime);
    }
    private void SpinDownRight()
    {
        DownRight.transform.eulerAngles -= new Vector3(0, 0, SpinSpeed * Time.deltaTime);
    }
    private void SpinUpLeft()
    {
        UpLeft.transform.eulerAngles += new Vector3(0, 0, SpinSpeed/2 * Time.deltaTime);
    }
    private void SpinUpRight()
    {
        UpRight.transform.eulerAngles -= new Vector3(0, 0, SpinSpeed/2 * Time.deltaTime);
    }
}
