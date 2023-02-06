using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtsuhoLastSpellBulletControl : MonoBehaviour
{
    public float SpinSpeed;
    public float Distance;
    public GameObject BulletPrefab;

    public GameObject Caution1;
    public GameObject Caution2;


    private float BulletCooldown;
    private bool MoveBack = false;
    private int ShootType = 0;

    public Transform[] Spawner;

    private void Start()
    {
        StartCoroutine(SetUpPattern());
    }
    private void FixedUpdate()
    {
        BulletCooldown += Time.deltaTime;
        transform.eulerAngles += new Vector3(0,0, SpinSpeed * Time.deltaTime);
        SpawnDistance();
        ShootBullet();
    }

    private void SpawnDistance()
    {
        if(MoveBack == true)
        {
            ShootType = 1;
            for (int i = 0; i < Spawner.Length; i++)
            {
                Spawner[i].localPosition += new Vector3 (0,5 * Time.deltaTime, 0);
                if(Spawner[i].localPosition.y >= Distance)
                {
                    Spawner[i].localPosition = new Vector3 (0, Distance, 0);
                    MoveBack = false;
                    ShootType = 0;
                }
            }
        }
        
    }
    private void ShootBullet()
    {
        for (int i = 0; i < Spawner.Length; i++)
        {
            if (ShootType == 1 && BulletCooldown >= 0.05)
            {
                Instantiate(BulletPrefab, Spawner[i].position, Spawner[i].rotation);
                if(i == Spawner.Length -1)
                {
                    BulletCooldown = 0;
                }
                
            }

            if (ShootType == 2 && BulletCooldown >= 0.5)
            {
                Instantiate(BulletPrefab, Spawner[i].position, Spawner[i].rotation);
                if (i == Spawner.Length - 1)
                {
                    BulletCooldown = 0;
                }
            }
        }
    }
    IEnumerator SetUpPattern()
    {
        yield return new WaitForSeconds(1);
        MoveBack = true;
        yield return new WaitForSeconds(1);
        Caution1.SetActive(true);
        Caution2.SetActive(true);
        yield return new WaitForSeconds(3);
        UtsuhoLastSpellSUN.SetPullSpeed1();
        UtsuhoLastSpellSmallBulletControll.IsShootTrue();
        ShootType = 2;
    }
}
