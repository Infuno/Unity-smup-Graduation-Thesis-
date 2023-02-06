using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtsuhoNonSpell3BulletSpawner : MonoBehaviour
{
    public float MaxX;
    public float MinX;
    public float MaxY;
    public float MinY;

    public float GapRate;
    public int NumberOfBulletPoint;
    public GameObject BulletPrefab;

    public EnemyMove MoveScript;

    public GameObject PurpleBullet;
    public GameObject BlueBullet;
    public GameObject CyanBullet;
    public GameObject GreenBullet;
    public GameObject YellowBullet;    
    public GameObject OrangeBullet;
    public GameObject RedBullet;

    public GameObject ChargeEffect;

    private bool Moving = false;

    private void Start()
    {
        MoveScript.ReturnCenter();
        StartCoroutine(CornerAttack());
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.K))
        {
            StartCoroutine(Charging());
        }
        CheckMove();
    }
    public void SpawnLeftSide()
    {
        for (float i = MinY; i < MaxY; i += GapRate)
        {
            Instantiate(BulletPrefab, new Vector3(MinX, i,0), Quaternion.Euler(0,0,270));
        }
    }
    public void SpawnRightSide()
    {
        for (float i = MinY; i < MaxY; i += GapRate)
        {
            Instantiate(BulletPrefab, new Vector3(MaxX, i, 0), Quaternion.Euler(0, 0, 90));
        }
    }
    public void SpawnUp()
    {
        for (float i = MinX; i < MaxX; i += GapRate)
        {
            Instantiate(BulletPrefab, new Vector3(i, MaxY, 0), Quaternion.Euler(0, 0, 180));
        }
    }
    public void SpawnCurrent()
    {
        float RotagePoint = 360f / NumberOfBulletPoint;
        for (int i = 0; i <= NumberOfBulletPoint; i++)
        {
            Instantiate(PurpleBullet, transform.position, transform.rotation * Quaternion.Euler(0f, 0f, RotagePoint * i));
            Instantiate(BlueBullet, transform.position, transform.rotation * Quaternion.Euler(0f, 0f, RotagePoint * i));
            Instantiate(CyanBullet, transform.position, transform.rotation * Quaternion.Euler(0f, 0f, RotagePoint * i));
            Instantiate(GreenBullet, transform.position, transform.rotation * Quaternion.Euler(0f, 0f, RotagePoint * i));
            Instantiate(YellowBullet, transform.position, transform.rotation * Quaternion.Euler(0f, 0f, RotagePoint * i));
            Instantiate(OrangeBullet, transform.position, transform.rotation * Quaternion.Euler(0f, 0f, RotagePoint * i));
            Instantiate(RedBullet, transform.position, transform.rotation * Quaternion.Euler(0f, 0f, RotagePoint * i));
        }
    }
    IEnumerator CornerAttack()
    {
        yield return new WaitForSeconds(1);
        SpawnLeftSide();
        SpawnRightSide();
        SpawnUp();
        yield return new WaitForSeconds(2);
        StartCoroutine(Charging());
    }
    private void CheckMove()
    {
        if (Moving == true)
        {
            MoveScript.MoveTo();
        }
        if (Moving == false)
        {
            MoveScript.ChangeLocation();
        }
    }
    IEnumerator Charging()
    {
        ChargeEffect.SetActive(true);
        yield return new WaitForSeconds(3);
        ChargeEffect.SetActive(false);
        SpawnCurrent();
        Moving = true;
        yield return new WaitForSeconds(3);
        Moving = false;
        StartCoroutine(CornerAttack());
    }
}
