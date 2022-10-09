using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float Damage;

    private void Start()
    {
        rb.velocity = transform.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyHealth boss = hitInfo.GetComponent<EnemyHealth>();
        if (boss != null)
        {
            boss.TakeDamage(Damage);
        }
        NonBossHealth enemy = hitInfo.GetComponent<NonBossHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(Damage);
        }
        Destroy(gameObject);
    }
}
