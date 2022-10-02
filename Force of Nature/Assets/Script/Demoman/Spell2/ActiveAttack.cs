using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAttack : MonoBehaviour
{
    public Spell2BulletSpawn Attack;
    public GameObject Lazer;

    public void Activate()
    {
        Attack.enabled = true;
        Lazer.SetActive(true);
    }
}
