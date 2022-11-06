using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtsuhoSpell1Spawn : MonoBehaviour
{
    [Header("Big Red Bullet")]
    public Transform[] BigBulletInner;
    public Transform[] BigBulletOuter;

    public Transform InnerController;
    public Transform OuterController;

    public float SpinSpeed;

    [Header("Small Bullet")]
    public Transform SmallBulletSpawner;
    public GameObject SmallBulletPrefab;
    public int NumberOfBulletPoint;
    public float RateOfFire;

    private float InnerDistance;
    private bool InnerExpand = true;
    private float OuterDistance;
    private bool OuterExpand = true;
    public bool ShootSmallBullet = false;
    private float BulletCooldown;
    private void Start()
    {
        StartCoroutine(EnableFire());
    }
    void Update()
    {
        BulletCooldown += Time.deltaTime;
        InnerBulletRange();
        OuterBulletRange();
        BigBulletSpin();
        SpawnSmallBullet();
    }

    private void BigBulletSpin()
    {
        InnerController.eulerAngles +=  new Vector3(0, 0, SpinSpeed * Time.deltaTime);
        OuterController.eulerAngles -= new Vector3(0, 0, SpinSpeed * Time.deltaTime);
    }
    private void InnerBulletRange()
    {
        if (InnerExpand == true)
        {
            InnerDistance += Time.deltaTime;
            if (InnerDistance >=2)
            {
                InnerDistance = 2;
                InnerExpand = false;
            }
        }
        for (int i = 0; i < BigBulletInner.Length; i++)
        {
            BigBulletInner[i].transform.localPosition = new Vector3(0, InnerDistance, 0);
        }
    }
    private void OuterBulletRange()
    {
        if (OuterExpand == true)
        {
            OuterDistance += Time.deltaTime;
            if (OuterDistance >= 4.5f)
            {
                OuterDistance = 4.5f;
                OuterExpand = false;
            }
        }
        for (int i = 0; i < BigBulletOuter.Length; i++)
        {
            BigBulletOuter[i].transform.localPosition = new Vector3(0, OuterDistance, 0);
        }
    }
    public void SpawnSmallBullet()
    {
        float RotagePoint = 360 / NumberOfBulletPoint;
        SmallBulletSpawner.localEulerAngles += new Vector3(0, 0, 0.1f);
        if (BulletCooldown > RateOfFire && ShootSmallBullet == true)
        {
            FindObjectOfType<AudioManager>().Play("BulletShoot");
            for (int i = 0; i <= NumberOfBulletPoint - 1; i++)
            {
                Instantiate(SmallBulletPrefab, SmallBulletSpawner.position, SmallBulletSpawner.rotation * Quaternion.Euler(0f, 0f, RotagePoint * i));
            }
            BulletCooldown = 0;
        }
    }

    IEnumerator EnableFire()
    {
        yield return new WaitForSeconds(5);
        ShootSmallBullet = true;
    }   
    public void text()
    {
        if(Input.GetKey(KeyCode.C))
        {
            SpawnSmallBullet();
        }
    }
}
