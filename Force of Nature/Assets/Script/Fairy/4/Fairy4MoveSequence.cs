using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy4MoveSequence : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public NonBossHealth nonBossHealth;
    
    private bool Moving = false;
    private bool Turnning = false;

    private void Start()
    {
        StartCoroutine(TimeOut());
        StartCoroutine(SetMove());
        StartCoroutine(MoveSequence());
    }
    void Update()
    {
        CheckMove();
        if(Moving == true)
        {
            rb.velocity = transform.up * -speed;
        }
        
        Turn();

        ifDead();
    }
    private void ifDead()
    {
        if (nonBossHealth.GetCurrentHealth() <= 0)
        {
            speed = 0;
        }
    }
    IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(20f);
        Destroy(gameObject);
    }
    private void Turn()
    {
        if (Turnning == true)
        {
            transform.eulerAngles += new Vector3(0, 0, 180 * Time.deltaTime);
        }
    }
    public void CheckMove()
    {
        if (rb.velocity.x > 0.2 * speed)
        {
            animator.SetBool("IsMoving", true);
            spriteRenderer.flipX = false;
        }
        if (rb.velocity.x < -0.2 * speed)
        {
            animator.SetBool("IsMoving", true);
            spriteRenderer.flipX = true;
        }
        if (rb.velocity.x < 0.2 * speed && rb.velocity.x > -0.2 * speed)
        {
            animator.SetBool("IsMoving", false);
        }
    }
    IEnumerator MoveSequence()
    {
        yield return new WaitForSeconds(7f);
        Turnning = true;
        yield return new WaitForSeconds(1f);
        Turnning = false;
        transform.eulerAngles = new Vector3(180, 0, 0);
    }
    IEnumerator SetMove()
    {
        yield return new WaitForSeconds(2f);
        Moving = true;
    }
}
