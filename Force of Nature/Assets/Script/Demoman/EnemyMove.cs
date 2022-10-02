using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float MovingSpeed;
    public Transform Boss;

    private float RangeX;
    private float RangeY = 2;

    public void ChangeLocation()
    {
        RangeX = Random.Range(-2.0f, 2.0f);
        RangeY = Random.Range(1.0f, 4.0f);
    }
    public void MoveTo()
    {
        Boss.position = Vector2.MoveTowards(transform.position, new Vector2(RangeX, RangeY), MovingSpeed* Time.deltaTime);
    }
    public void ReturnCenter()
    {
        Boss.position = Vector2.MoveTowards(transform.position, new Vector2(0, 2), MovingSpeed * Time.deltaTime);
    }
}
