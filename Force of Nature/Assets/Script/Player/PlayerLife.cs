using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public GameObject[] Life;
    public int MaxLife;
    public int CurrentLife;
    public GameObject GameOverPanel;
    public bool LostLife = true;

    private void Start()
    {
        CurrentLife = MaxLife;
        DisplayLife();
    }
    public void DisplayLife()
    {
        /*try
        {
            for (int i = 0; i < CurrentLife; i++)
            {
                Life[i+1].SetActive(true);
            }
            for (int i = CurrentLife; i <= Life.Length; i++)
            {
                Life[i-2].SetActive(false);
            }
        }
        catch(Exception ex)
        {
            print(ex);
        }*/
        if (CurrentLife == 5)
        {
            Life[0].SetActive(true);
            Life[1].SetActive(true);
            Life[2].SetActive(true);
            Life[3].SetActive(true);
            Life[4].SetActive(true);
        }
        if (CurrentLife == 4)
        {
            Life[0].SetActive(true);
            Life[1].SetActive(true);
            Life[2].SetActive(true);
            Life[3].SetActive(true);
            Life[4].SetActive(false);
        }
        if (CurrentLife == 3)
        {
            Life[0].SetActive(true);
            Life[1].SetActive(true);
            Life[2].SetActive(true);
            Life[3].SetActive(false);
            Life[4].SetActive(false);
        }
        if (CurrentLife == 2)
        {
            Life[0].SetActive(true);
            Life[1].SetActive(true);
            Life[2].SetActive(false);
            Life[3].SetActive(false);
            Life[4].SetActive(false);
        }
        if (CurrentLife == 1)
        {
            Life[0].SetActive(true);
            Life[1].SetActive(false);
            Life[2].SetActive(false);
            Life[3].SetActive(false);
            Life[4].SetActive(false);
        }
        if (CurrentLife == 0)
        {
            Life[0].SetActive(false);
            Life[1].SetActive(false);
            Life[2].SetActive(false);
            Life[3].SetActive(false);
            Life[4].SetActive(false);
        }
    }
    public void IsDead()
    {
        if(LostLife == true)
        {
            CurrentLife -= 1;
            DisplayLife();
            if(CurrentLife == -1)
            {
                print("ded");
                StartCoroutine(GameOver());
            }
            LostLife = false;
            StartCoroutine(DeadAgain());
        }
        
    }
    IEnumerator GameOver()
    {
        GameOverPanel.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Time.timeScale = 0;
    }
    IEnumerator DeadAgain()
    {
        yield return new WaitForSeconds(1f);
        LostLife = true;
    }
}
