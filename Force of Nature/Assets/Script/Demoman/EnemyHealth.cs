using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float MaxHealth;
    public float CurrentHealth;

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
        }
    }
    public void Die()
    {
        print("I am Dead");
    }

    public float GetMaxHealth()
    {
        return MaxHealth;
    }
    public float GetCurrentHealth()
    {
        return CurrentHealth;
    }
    public float SetMaxHealth(float MHealth)
    {
        MaxHealth = MHealth;
        return MaxHealth;
    }
    public float SetCurrentHealth(float CHelath)
    {
        CurrentHealth = CHelath;
        return CurrentHealth;
    }
}
