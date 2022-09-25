using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
    public Transform Player;
    public GameObject[] Spell;
    public GameObject BombPrefab;

    public int MaxBomb;
    public int CurrentBomb;

    private void Start()
    {
        CurrentBomb = MaxBomb + 1;
        DisplayBomb();
    }
    public void DisplayBomb()
    {
        for (int i = CurrentBomb; i <= MaxBomb; i++)
        {
            Spell[i - 1].SetActive(false);
        }
    }
    public void SpellUse()
    {
        CurrentBomb -= 1;
        DisplayBomb();
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.X))
        {
            Instantiate(BombPrefab, Player.position, Player.rotation);
            SpellUse();
        }
    }
}
