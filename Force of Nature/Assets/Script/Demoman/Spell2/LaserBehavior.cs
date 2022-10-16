using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : MonoBehaviour
{
    public float Damage;
    public Collider2D lazercollider;
    public void OnCollider()
    {
        lazercollider.enabled = true;
        FindObjectOfType<AudioManager>().Play("Lazer1");
    }
    public void OffCollider()
    {
        lazercollider.enabled = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.PlayerTakeDamage(Damage);
        }
    }
    public void PlaySound()
    {
        FindObjectOfType<AudioManager>().Play("Lazer2");
    }
}
