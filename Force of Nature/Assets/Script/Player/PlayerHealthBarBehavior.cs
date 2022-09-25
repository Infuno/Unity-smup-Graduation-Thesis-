using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarBehavior : MonoBehaviour
{
    public Image image;
    public PlayerHealth playerHealth;
    public Text HealthNumber;
    public Animator animator;


    private float MaxHealth;
    private float CurrentHealth;
    private void Update()
    {
        MaxHealth = playerHealth.MaxHealth;
        CurrentHealth = playerHealth.CurrentHealth;

        image.fillAmount = CurrentHealth / MaxHealth;
        HealthNumber.text = CurrentHealth.ToString("0");

        if(CurrentHealth <= 50)
        {
            animator.SetBool("IsLow",true);
        }
        if (CurrentHealth >= 50)
        {
            animator.SetBool("IsLow", false);
        }
    }
}
