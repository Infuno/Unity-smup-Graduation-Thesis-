using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHealth;
    public float CurrentHealth;
    public PlayerLife playerLife;
    public GameObject GameOverPanel;

    public Animator DeadEffectCore;
    public Animator DeadEffect1;
    public Animator DeadEffect2;
    public Animator DeadEffect3;
    public Animator DeadEffect4;

    public Animator HitBox;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }
    public void PlayerTakeDamage(float damge)
    {
        CurrentHealth -= damge;
        if(CurrentHealth <= 0)
        {
            playerLife.IsDead();
        }
    }
    public void PlayerDie(bool status)
    {
        DeadEffectCore.SetBool("IsDead", status);
        DeadEffect1.SetBool("IsDead", status);
        DeadEffect2.SetBool("IsDead", status);
        DeadEffect3.SetBool("IsDead", status);
        DeadEffect4.SetBool("IsDead", status);
        HitBox.SetBool("IsFocus", false);
        
    }
    public float GetPlayerMaxHealth()
    {
        return MaxHealth;
    }
    public float GetPlayerCurrentHealth()
    {
        return CurrentHealth;
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.C))
        {
            PlayerTakeDamage(70);
        }
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            PlayerDie(true);
            this.GetComponent<PlayerMovement>().enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<PlayerBomb>().enabled = false;
            this.GetComponent<CircleCollider2D>().enabled = false;
            StartCoroutine(ReSpawn());
        }
        
        if (playerLife.GeCurrenttLife() == 0)
        {
            StartCoroutine(GameOver());
        }
    }
    IEnumerator ReSpawn()
    {
        yield return new WaitForSeconds(1.0f);
        PlayerDie(false); 
        yield return new WaitForSeconds(1.2f);
        CurrentHealth = MaxHealth;
        
        this.GetComponent<PlayerMovement>().enabled = true;
        this.GetComponent<SpriteRenderer>().enabled = true;
        this.GetComponent<PlayerBomb>().enabled = true;
        StartCoroutine(IFrame());
    }
    IEnumerator IFrame()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.2f);
            this.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.2f);
            this.GetComponent<SpriteRenderer>().enabled = true;
        }
        yield return new WaitForSeconds(2f);
        this.GetComponent<CircleCollider2D>().enabled = true;
    }
    IEnumerator GameOver()
    {
        GameOverPanel.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Time.timeScale = 0;
    }

}
