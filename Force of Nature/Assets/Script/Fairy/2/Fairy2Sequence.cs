using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy2Sequence : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public NonBossHealth nonBossHealth;

    private bool IsMove = false;

    private void Start()
    {
        StartCoroutine(Conceal());
        StartCoroutine(Moving());
        StartCoroutine(TimeOut());
    }
    private void Update()
    {
        CheckMove();
        ifDead();
        if(IsMove == true)
        {
            rb.velocity = transform.right * speed;
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
    IEnumerator Conceal()
    {
        animator.SetBool("Conceal", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("Conceal", false);
    }
    IEnumerator Moving()
    {
        yield return new WaitForSeconds(3.3f);
        IsMove = true;
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
        yield return new WaitForSeconds(15f);
        Destroy(gameObject);
    }
}
