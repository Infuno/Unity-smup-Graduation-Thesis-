using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigFairy1MoveSequence : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public NonBossHealth nonBossHealth;

    private int Sequence;
    private void Start()
    {
        StartCoroutine(MoveSequence());
    }
    private void Update()
    {
        if (Sequence == 0)
        {
            rb.velocity = transform.up * -speed;
        }
        if (Sequence == 1)
        {
            rb.velocity = transform.up * 0;
        }
        if (Sequence == 2)
        {
            rb.velocity = transform.up * speed/3;
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
        yield return new WaitForSeconds(2f);
        Sequence = 1;
        yield return new WaitForSeconds(5f);
        Sequence = 2;
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

}
