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
        CurrentBomb = MaxBomb;
        DisplayBomb();
    }
    public void DisplayBomb()
    {
        for(int i = 0; i < CurrentBomb; i++)
        {
            Spell[i].SetActive(true);
        }
        for (int i = CurrentBomb+1; i <= Spell.Length; i++)
        {
            Spell[i-1].SetActive(false);
        }
    }
    public void SpellUse()
    {
        CurrentBomb -= 1;
        DisplayBomb();
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.X) && CurrentBomb >0)
        {
            Instantiate(BombPrefab, Player.position, Player.rotation);
            this.GetComponent<CircleCollider2D>().enabled = false;
            SpellUse();
            StartCoroutine(IFrame());
        }
    }
    IEnumerator IFrame()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.2f);
            this.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.2f);
            this.GetComponent<SpriteRenderer>().enabled = true;
        }
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<CircleCollider2D>().enabled = true;
    }
}
