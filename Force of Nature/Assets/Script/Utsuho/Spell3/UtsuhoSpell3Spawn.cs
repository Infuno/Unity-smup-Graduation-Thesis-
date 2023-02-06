using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtsuhoSpell3Spawn : MonoBehaviour
{
    public Transform BulletDownController;
    public Transform BulletLeftController;

    public Transform DownSpawner1;
    public Transform DownSpawner2;
    public Transform DownSpawner3;
    public Transform DownSpawner4;
    public Transform DownSpawner5;
    public Transform DownSpawner6;

    public Transform LeftSpawner1;
    public Transform LeftSpawner2;
    public Transform LeftSpawner3;
    public Transform LeftSpawner4;
    public Transform LeftSpawner5;
    public Transform LeftSpawner6;

    public GameObject BulletPrefab;


    [Header("Reapeater Spawn")]

    public float RateOfFire;
    public float MoveDistance;
    public float DelayPerShot;
    private bool SecondShot = false;

    [Header("UtsuhoCharge")]
    public Transform Boss;
    public Transform Player;
    public Transform Turner;

    private void Start()
    {
        StartCoroutine(Shoot());
        StartCoroutine(SecondAttack());
    }
    private void Update()
    {
        FollowObject();
    }

    IEnumerator MovePointDown()
    {
        yield return new WaitForSeconds(RateOfFire);
        DownShoot();
        BulletDownController.position += new Vector3(MoveDistance, 0, 0);

        yield return new WaitForSeconds(RateOfFire);
        DownShoot();
        BulletDownController.position += new Vector3(MoveDistance, 0, 0);

        yield return new WaitForSeconds(RateOfFire);
        DownShoot();
        BulletDownController.position += new Vector3(MoveDistance, 0, 0);


        BulletDownController.position -= new Vector3(MoveDistance * 3, 0, 0);
    }

    IEnumerator MovePointLeft()
    {
        yield return new WaitForSeconds(RateOfFire);
        LeftShoot();
        BulletLeftController.position -= new Vector3(0, MoveDistance, 0);

        yield return new WaitForSeconds(RateOfFire);
        LeftShoot();
        BulletLeftController.position -= new Vector3(0, MoveDistance, 0);

        yield return new WaitForSeconds(RateOfFire);
        LeftShoot();
        BulletLeftController.position -= new Vector3(0, MoveDistance, 0);


        BulletLeftController.position += new Vector3(0, MoveDistance * 3, 0);
    }

    private void DownShoot()
    {
        Instantiate(BulletPrefab, DownSpawner1.position, DownSpawner1.rotation);
        Instantiate(BulletPrefab, DownSpawner2.position, DownSpawner2.rotation);
        Instantiate(BulletPrefab, DownSpawner3.position, DownSpawner3.rotation);
        Instantiate(BulletPrefab, DownSpawner4.position, DownSpawner4.rotation);
        Instantiate(BulletPrefab, DownSpawner5.position, DownSpawner5.rotation);
        Instantiate(BulletPrefab, DownSpawner6.position, DownSpawner6.rotation);
    }

    private void LeftShoot()
    {
        Instantiate(BulletPrefab, LeftSpawner1.position, LeftSpawner1.rotation);
        Instantiate(BulletPrefab, LeftSpawner2.position, LeftSpawner2.rotation);
        Instantiate(BulletPrefab, LeftSpawner3.position, LeftSpawner3.rotation);
        Instantiate(BulletPrefab, LeftSpawner4.position, LeftSpawner4.rotation);
        Instantiate(BulletPrefab, LeftSpawner5.position, LeftSpawner5.rotation);
        Instantiate(BulletPrefab, LeftSpawner6.position, LeftSpawner6.rotation);
    }

    IEnumerator Shoot()
    {
        StartCoroutine(MovePointDown());
        if(SecondShot == true)
        {
            StartCoroutine(MovePointLeft());
        }
        yield return new WaitForSeconds(DelayPerShot);
        StartCoroutine(Shoot());
    }
    IEnumerator SecondAttack()
    {
        yield return new WaitForSeconds(10);
        SecondShot = true;
    }

    private void FollowObject()
    {
        Boss.position = Turner.position;
    }
}
