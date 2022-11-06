using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtsuhoNonSpell2BulletBehavior : MonoBehaviour
{
    public Rigidbody2D rb;
    public float Damage;
    public bool RedBullet;
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHealth playerHealth = hitInfo.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.PlayerTakeDamage(Damage);
            this.GetComponent<Animator>().SetTrigger("IsHit");
        }

        if(hitInfo.gameObject.tag == "BlueLazer" && RedBullet == true)
        {
            this.GetComponent<Animator>().SetTrigger("IsHit");
        }
        if (hitInfo.gameObject.tag == "RedLazer" && RedBullet == false)
        {
            this.GetComponent<Animator>().SetTrigger("IsHit");
        }
        if(hitInfo.gameObject.tag != "BlueLazer" && hitInfo.gameObject.tag != "RedLazer")
        {
            this.GetComponent<Animator>().SetTrigger("IsHit");
        }


    }
    public void HitBoxOff()
    {
        this.GetComponent<Collider2D>().enabled = false;
    }
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
