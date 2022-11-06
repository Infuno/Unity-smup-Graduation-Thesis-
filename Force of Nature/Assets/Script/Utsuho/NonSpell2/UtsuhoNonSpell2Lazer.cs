using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtsuhoNonSpell2Lazer : MonoBehaviour
{
    public float Damage;
    public GameObject BulletSpawner;
    private void OnTriggerStay2D(Collider2D hitInfo)
    {
        PlayerHealth playerHealth = hitInfo.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.PlayerTakeDamage(Damage);
        }
    }
    public void LazerOn()
    {
        this.GetComponent<Collider2D>().enabled = true;
        BulletSpawner.SetActive(true);
    }
    public void avc()
    {

    }
}
