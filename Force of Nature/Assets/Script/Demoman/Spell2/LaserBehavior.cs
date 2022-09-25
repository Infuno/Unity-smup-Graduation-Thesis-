using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : MonoBehaviour
{
    public float Damage;
    public Collider2D collider;
    public void OnCollider()
    {
        collider.enabled = true;
    }
    public void OffCollider()
    {
        collider.enabled = false;
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
