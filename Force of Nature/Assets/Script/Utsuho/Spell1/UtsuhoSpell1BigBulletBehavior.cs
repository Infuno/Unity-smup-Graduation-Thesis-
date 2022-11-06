using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtsuhoSpell1BigBulletBehavior : MonoBehaviour
{
    public float Damage;
    public Rigidbody2D rb;
    public Collider2D collider;
    private void Start()
    {
        StartCoroutine(HitBoxOn());
    }
    private void OnTriggerStay2D(Collider2D hitInfo)
    {
        PlayerHealth playerHealth = hitInfo.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.PlayerTakeDamage(Damage);
        }
    }
    IEnumerator HitBoxOn()
    {
        yield return new WaitForSeconds(1f);
        collider.enabled = true;
    }
}
