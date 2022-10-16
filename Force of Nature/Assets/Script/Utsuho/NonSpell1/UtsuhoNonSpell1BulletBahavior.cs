using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtsuhoNonSpell1BulletBahavior : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float Damage;

    private void Start()
    {
        rb.velocity = transform.up * speed;
        StartCoroutine(SpeedUp());
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHealth playerHealth = hitInfo.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.PlayerTakeDamage(Damage);
        }
        this.GetComponent<Animator>().SetTrigger("IsHit");

    }
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
    public void HitBoxOn()
    {
        this.GetComponent<Collider2D>().enabled = true;
    }
    IEnumerator SpeedUp()
    {
        yield return new WaitForSeconds(1);
        rb.velocity = transform.up * speed *3;
    }
}
