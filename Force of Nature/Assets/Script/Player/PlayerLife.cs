using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public GameObject[] Life;
    public int MaxLife;
    public int CurrentLife;

    private void Start()
    {
        CurrentLife = MaxLife + 1;
        DisplayLife();
    }
    public void DisplayLife()
    {
        for (int i = CurrentLife; i <= 5; i++)
        {
            Life[i - 1].SetActive(false);
        }
    }
    public void IsDead()
    {
        CurrentLife -= 1;
        DisplayLife();
    }
    public int GeCurrenttLife()
    {
        return CurrentLife;
    }
}
