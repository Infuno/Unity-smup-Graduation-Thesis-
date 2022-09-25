using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBehavior : MonoBehaviour
{
    public Image image;
    public EnemyHealth enemyHealth;


    private float MaxHealth;
    private float CurrentHealth;
    private void Update()
    {
        MaxHealth = enemyHealth.MaxHealth;
        CurrentHealth = enemyHealth.CurrentHealth;

        image.fillAmount = CurrentHealth / MaxHealth;
    }
}
