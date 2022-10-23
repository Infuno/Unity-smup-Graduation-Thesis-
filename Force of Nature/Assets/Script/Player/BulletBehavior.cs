using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float Damage;

    ScoreBehavior score;
    private void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreBehavior>();
        rb.velocity = transform.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyHealth boss = hitInfo.GetComponent<EnemyHealth>();
        if (boss != null)
        {
            score.TotalScore += 11;
            boss.TakeDamage(Damage);
        }
        NonBossHealth enemy = hitInfo.GetComponent<NonBossHealth>();
        if (enemy != null)
        {
            score.TotalScore += 21;
            enemy.TakeDamage(Damage);
        }
        Destroy(gameObject);
    }
}
