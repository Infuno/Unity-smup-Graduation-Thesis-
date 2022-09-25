using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float MovingSpeed;
    public float SwitchTime;

    private float RangeX;
    private float RangeY;

    private void Start()
    {
        StartCoroutine(MoveIt(SwitchTime));
    }
    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(RangeX,RangeY), MovingSpeed * Time.deltaTime);
    }

    IEnumerator MoveIt(float timer)
    {
        RangeX = Random.Range(-5.0f, 5.0f);
        RangeY = Random.Range(0.0f, 4.0f);
        yield return new WaitForSeconds(timer);
        StartCoroutine(MoveIt(SwitchTime));
    }
}
