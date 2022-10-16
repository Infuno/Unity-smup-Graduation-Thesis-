using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy1Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float Damage;
    public Animator animator;

    private void Start()
    {
        rb.velocity = transform.up * speed;
        StartCoroutine(TimeOut());
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        rb.velocity = new Vector2 (0,0);
       PlayerHealth playerHealth = hitInfo.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.PlayerTakeDamage(Damage);
        }
        animator.SetTrigger("IsHit");
    }
    IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
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
