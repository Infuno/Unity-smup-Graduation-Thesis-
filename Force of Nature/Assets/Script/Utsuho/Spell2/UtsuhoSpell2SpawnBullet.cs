using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtsuhoSpell2SpawnBullet : MonoBehaviour
{
    public int NumberOfBulletPoint;
    public float RateOfFire;
    public GameObject BulletPrefab;

    public float BulletCooldown;
    private void Update()
    {
        BulletCooldown += Time.deltaTime;
        SpawnSmallBullet();
    }
    public void SpawnSmallBullet()
    {
        float RotagePoint = 360 / NumberOfBulletPoint;
        transform.localEulerAngles += new Vector3(0, 0, 0.1f);
        if (BulletCooldown > RateOfFire)
        {
            FindObjectOfType<AudioManager>().Play("BulletShoot");
            for (int i = 0; i <= NumberOfBulletPoint - 1; i++)
            {
                Instantiate(BulletPrefab, transform.position, transform.rotation * Quaternion.Euler(0f, 0f, RotagePoint * i));
            }
            BulletCooldown = 0;
        }
    }
}
