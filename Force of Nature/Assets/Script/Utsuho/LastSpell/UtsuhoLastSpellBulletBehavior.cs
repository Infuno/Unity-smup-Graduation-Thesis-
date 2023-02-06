using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtsuhoLastSpellBulletBehavior : MonoBehaviour
{
    Transform SUN;
    public float Damage;
    private void Start()
    {
        SUN = GameObject.FindWithTag("SUN").transform;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, SUN.position, UtsuhoLastSpellSUN.GetPullSpeed() * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.PlayerTakeDamage(Damage);
            this.GetComponent<Animator>().SetTrigger("IsHit");
        }

        if (collision.gameObject.tag == "SUN")
        {
            this.GetComponent<Animator>().SetTrigger("IsHit");
        }

        if(collision.gameObject.layer == 2)
        {
            this.GetComponent<Animator>().SetTrigger("IsHit");
        }
    }
    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
