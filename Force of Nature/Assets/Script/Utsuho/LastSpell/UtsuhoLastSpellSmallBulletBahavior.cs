using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtsuhoLastSpellSmallBulletBahavior : MonoBehaviour
{
    public float Speed;
    public float Damage;
    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = transform.right * Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.PlayerTakeDamage(Damage);
            Destroy(gameObject);
        }

        if (collision.gameObject.layer == 2)
        {
            this.GetComponent<Animator>().SetTrigger("IsHit");
        }
    }
    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
