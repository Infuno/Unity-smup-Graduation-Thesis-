using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnOnDead : MonoBehaviour
{
    public Transform Player;
    public GameObject[] Life;
    public int MaxLife;
    public int CurrentLife;

    private void Start()
    {
        CurrentLife = MaxLife+1;
        DisplayLife();
    }
    public void ResetPlayer()
    {
        Player.localPosition = new Vector2(0, -4);
    }
    public void DisplayLife()
    {
        for (int i = CurrentLife; i <= MaxLife; i++)
        {
            Life[i-1].SetActive(false);
        }
    }
    public void IsDead()
    {
        CurrentLife -=1;
        DisplayLife();
    }
}
