using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public GameObject[] Life;
    public int MaxLife;
    public static int CurrentLife;

    private void Start()
    {
        CurrentLife = MaxLife + 1;
        DisplayLife();
    }
    public void DisplayLife()
    {
        try
        {
            for (int i = 0; i < CurrentLife; i++)
            {
                Life[i].SetActive(true);
            }
            for (int i = CurrentLife; i <= Life.Length; i++)
            {
                Life[i-1].SetActive(false);
            }
        }
        catch(System.IndexOutOfRangeException ex)
        {

        }

        
    }
    public void IsDead()
    {
        CurrentLife -= 1;
        DisplayLife();
    }
}
