using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtsuhoSpell2BulletBehavior : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float Damage;
    private void Start()
    {
        rb.velocity = transform.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.PlayerTakeDamage(Damage);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
