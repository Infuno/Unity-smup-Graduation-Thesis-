using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell1BulletSpawn : MonoBehaviour
{
    public Transform firepoint1;
    public Transform firepoint2;
    public Transform firepoint3;
    public Transform firepoint4;
    public Transform firepoint5;
    public Transform firepoint6;
    public Transform firepoint7;
    public Transform firepoint8;

    public GameObject BulletPrefab;
    public GameObject Spinner;
    public float RateOfFire;
    public float FiringDurarion;
    public float ShotCooldown;
    public float SpinSpeed;

    public float SpawnerDistance;
    public float BackwardRate;

    public EnemyMove moveScript;

    private bool IsFire = true;
    private float BulletCooldown;

    private void FixedUpdate()
    {
        BulletCooldown += Time.deltaTime;
        if (IsFire == true)
        {
            Shoot();
            StartCoroutine(Duration(FiringDurarion));
            Spin();
            MoveSpawner(BackwardRate);
            moveScript.ChangeLocation();
        }
        if (IsFire == false)
        {
            StartCoroutine(Cooldown(ShotCooldown));
            Spinner.transform.eulerAngles = new Vector3(0, 0, 0);
            ResetSpawner(SpawnerDistance);
            moveScript.MoveTo();
        }
    }
    private void Shoot()
    {
        if (BulletCooldown > RateOfFire)
        {
            FindObjectOfType<AudioManager>().Play("NonSpell1");
            Instantiate(BulletPrefab, firepoint1.position, firepoint1.rotation);
            Instantiate(BulletPrefab, firepoint2.position, firepoint2.rotation);
            Instantiate(BulletPrefab, firepoint3.position, firepoint3.rotation);
            Instantiate(BulletPrefab, firepoint4.position, firepoint4.rotation);
            Instantiate(BulletPrefab, firepoint5.position, firepoint5.rotation);
            Instantiate(BulletPrefab, firepoint6.position, firepoint6.rotation);
            Instantiate(BulletPrefab, firepoint7.position, firepoint7.rotation);
            Instantiate(BulletPrefab, firepoint8.position, firepoint8.rotation);
            BulletCooldown = 0;
            Shoot();
        }
    }
    private void MoveSpawner(float Move)
    {
        firepoint1.transform.localPosition -= new Vector3(0, Move * Time.deltaTime, 0);
        firepoint2.transform.localPosition -= new Vector3(0, Move * Time.deltaTime, 0);
        firepoint3.transform.localPosition -= new Vector3(0, Move * Time.deltaTime, 0);
        firepoint4.transform.localPosition -= new Vector3(0, Move * Time.deltaTime, 0);
        firepoint5.transform.localPosition -= new Vector3(0, Move * Time.deltaTime, 0);
        firepoint6.transform.localPosition -= new Vector3(0, Move * Time.deltaTime, 0);
        firepoint7.transform.localPosition -= new Vector3(0, Move * Time.deltaTime, 0);
        firepoint8.transform.localPosition -= new Vector3(0, Move * Time.deltaTime, 0);
    }
    private void ResetSpawner(float Distance)
    {
        firepoint1.transform.localPosition = new Vector3(0, Distance, 0);
        firepoint2.transform.localPosition = new Vector3(0, Distance, 0);
        firepoint3.transform.localPosition = new Vector3(0, Distance, 0);
        firepoint4.transform.localPosition = new Vector3(0, Distance, 0);
        firepoint5.transform.localPosition = new Vector3(0, Distance, 0);
        firepoint6.transform.localPosition = new Vector3(0, Distance, 0);
        firepoint7.transform.localPosition = new Vector3(0, Distance, 0);
        firepoint8.transform.localPosition = new Vector3(0, Distance, 0);
    }
    private void Spin()
    {
        Spinner.transform.eulerAngles += new Vector3(0, 0, SpinSpeed * Time.deltaTime);
    }
    IEnumerator Duration(float timer)
    {
        yield return new WaitForSeconds(timer);
        IsFire = false;
    }
    IEnumerator Cooldown(float timer)
    {
        yield return new WaitForSeconds(timer);
        IsFire = true;
    }
}
 