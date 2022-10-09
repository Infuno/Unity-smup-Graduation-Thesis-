using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy5MoveSequence : MonoBehaviour
{
    public Rigidbody2D rb;
    private float speed;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public NonBossHealth nonBossHealth;

    public bool MoveToRight;

    private void Start()
    {
        speed = Random.Range(2, 3);
        StartCoroutine(TimeOut());
        if(MoveToRight == false)
        {
            speed = speed * -1;
        }
    }
    void Update()
    {
        CheckMove();
        rb.velocity = transform.right * speed;

        ifDead();
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
    private void ifDead()
    {
        if (nonBossHealth.GetCurrentHealth() <= 0)
        {
            speed = 0;
        }
    }
    IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

}
