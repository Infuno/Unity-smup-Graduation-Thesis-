using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehavior : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float Damage;

    public ParticleSystem particleStar;

    public GameObject Engine;
    public GameObject Trail;

    public Collider2D AreaClear;

    public Animator animator;

    private bool IsRotate;

    void Start()
    {
        rb.velocity = transform.up * speed;
        StartCoroutine(TimeDestroy());
    }

    private void FixedUpdate()
    {
        if (IsRotate == true)
        {
            RandomRotate();
        }
    }

    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyHealth enemyhealth = hitInfo.GetComponent<EnemyHealth>();
        if (enemyhealth != null)
        {
            rb.velocity = transform.up * speed*0;
            animator.SetTrigger("IsHit");
            particleStar.loop = false;
            Engine.SetActive(false);
            enemyhealth.TakeDamage(Damage);
        }
        NonBossHealth nonbosshealth = hitInfo.GetComponent<NonBossHealth>();
        if (nonbosshealth != null)
        {
            rb.velocity = transform.up * speed * 0;
            animator.SetTrigger("IsHit");
            particleStar.loop = false;
            Engine.SetActive(false);
            nonbosshealth.TakeDamage(Damage);
        }
    }
    private void OnTriggerStay2D(Collider2D hitInfo)
    {
        EnemyHealth enemyhealth = hitInfo.GetComponent<EnemyHealth>();
        if (enemyhealth != null)
        {
            enemyhealth.TakeDamage(Damage);
        }
        NonBossHealth nonbosshealth = hitInfo.GetComponent<NonBossHealth>();
        if (nonbosshealth != null)
        {
            nonbosshealth.TakeDamage(Damage);
        }
    }


    public void RandomRotate()
    {
        transform.Rotate(0, 0, Random.Range(0f, 360f));
    }
    public void RotateTrue()
    {
        IsRotate = true; 
    }
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
    IEnumerator TimeDestroy()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
    public void DisableCollider()
    {
        this.GetComponent<Collider2D>().enabled = false;
        AreaClear.GetComponent<Collider2D>().enabled = false;
    }
}
