using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell1BulletBehavior : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float Damage;

    private void Start()
    {
        rb.velocity = transform.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHealth playerHealth = hitInfo.GetComponent<PlayerHealth>();
        if(playerHealth != null)
        {
            playerHealth.PlayerTakeDamage(Damage);
        }
        this.GetComponent<Animator>().SetTrigger("IsHit");
    }
    public void HitBoxOn()
    {
        this.GetComponent<Collider2D>().enabled = true;
    }
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
