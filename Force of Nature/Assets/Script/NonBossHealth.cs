using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonBossHealth : MonoBehaviour
{
    public float MaxHealth;
    public float CurrentHealth;
    //public anim

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }
    public void TakeDamage(float damge)
    {
        CurrentHealth -= damge;

        if (CurrentHealth <= 0)
        {
            Die();
            this.GetComponent<Collider2D>().enabled = false;
        }
    }
    public void Die()
    {
        this.GetComponent<Animator>().SetTrigger("IsDead");
    }
    public float GetCurrentHealth()
    {
        return CurrentHealth;
    }
    public void Dissapear()
    {

        Destroy(transform.parent.gameObject);
    }    
}
