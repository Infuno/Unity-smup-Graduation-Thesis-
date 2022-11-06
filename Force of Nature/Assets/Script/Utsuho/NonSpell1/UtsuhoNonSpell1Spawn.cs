using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtsuhoNonSpell1Spawn : MonoBehaviour
{
    public int NumberOfBulletPoint;
    public GameObject BulletPrefab;
    public Animator animator;
    public EnemyMove MoveScript;
    public float RateOfFire;

    private bool Moving = false;
    private bool IsFire = false;
    private float BulletCooldown;
    private void Start()
    {
        StartCoroutine(FireOff());
    }
    private void FixedUpdate()
    {
        BulletCooldown += Time.deltaTime;
        if (IsFire == true)
        {
            Shoot();
        }
        CheckMove();
    }

    public void SpawnDirection()
    {
        float RotagePoint = 360 / NumberOfBulletPoint;
        for (int i = 0; i <= NumberOfBulletPoint-1; i++)
        {
            Instantiate(BulletPrefab, transform.position, transform.rotation * Quaternion.Euler(0f, 0f, RotagePoint * i));
        }
    }
    private void Shoot()
    {
        if (BulletCooldown > RateOfFire)
        {
            SpawnDirection();
            BulletCooldown = 0;
        }
    }
    IEnumerator FireOn()
    {
        Moving = false;
        IsFire = true;
        
        yield return new WaitForSeconds(2);
        animator.SetBool("Charge", false);
        StartCoroutine(FireOff());
        
    }
    IEnumerator FireOff()
    {
        
        IsFire = false;

        yield return new WaitForSeconds(1);
        
        Moving = true;
        yield return new WaitForSeconds(1);
        animator.SetBool("Charge", true);
        yield return new WaitForSeconds(1);
        
        StartCoroutine(FireOn());
    }
    private void CheckMove()
    {
        if(Moving == true)
        {
            MoveScript.MoveTo();
        }
        if (Moving == false)
        {
            MoveScript.ChangeLocation();
        }
    }
}
