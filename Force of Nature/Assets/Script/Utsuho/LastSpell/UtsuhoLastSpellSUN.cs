using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtsuhoLastSpellSUN : MonoBehaviour
{
    public Transform player;
    public EnemyHealth enemyHealth;
    static float PullSpeed = 0;

    private void FixedUpdate()
    {
        player.position = Vector2.MoveTowards(player.position, transform.position, PullSpeed * Time.deltaTime);
        if(enemyHealth.CurrentHealth <= 2000 && enemyHealth.CurrentHealth > 1000)
        {
            SetPullSpeed2();
        }
        if (enemyHealth.CurrentHealth <= 1000)
        {
            SetPullSpeed3();
        }
    }
    public static float GetPullSpeed()
    {
        return PullSpeed;
    }
    public static void SetPullSpeed1()
    {
        PullSpeed = 1;
    }
    public static void SetPullSpeed2()
    {
        PullSpeed = 1.4f;
    }
    public static void SetPullSpeed3()
    {
        PullSpeed = 1.8f;
    }
}
