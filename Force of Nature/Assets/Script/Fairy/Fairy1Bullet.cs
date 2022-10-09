using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy1Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float Damage;


    private void Start()
    {
        rb.velocity = transform.up * speed;
        StartCoroutine(TimeOut());
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHealth playerHealth = hitInfo.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.PlayerTakeDamage(Damage);
        }
        Destroy(gameObject);
    }
    IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
