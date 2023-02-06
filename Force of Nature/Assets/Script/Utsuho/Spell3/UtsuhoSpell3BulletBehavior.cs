using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtsuhoSpell3BulletBehavior : MonoBehaviour
{
    public float Speed;
    public float Damage;

    private void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = transform.up * Speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            this.GetComponent<Animator>().SetBool("IsFlower",true);
        }
        if (collision.gameObject.layer == 0)
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.layer == 9)
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.layer == 2)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            this.GetComponent<Animator>().SetBool("IsFlower", false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.PlayerTakeDamage(Damage);
        }
    }

}
