using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy1MoveSequence : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public NonBossHealth nonBossHealth;
    public float RotationSpeed;

    public bool Rolling = false;

    private void Start()
    {
        StartCoroutine(MoveSequence());
        StartCoroutine(TimeOut());
    }
    void Update()
    {
        CheckMove();
        rb.velocity = transform.right * speed;
        
        Roll();

        ifDead();
    }
    public void CheckMove()
    {
        if (rb.velocity.x > 0.2 * speed)
        {
            animator.SetBool("IsMoving", true);
            spriteRenderer.flipX = false ;
        }
        if (rb.velocity.x < -0.2 * speed)
        {
            animator.SetBool("IsMoving", true);
            spriteRenderer.flipX = true;
        }
        if(rb.velocity.x < 0.2 * speed && rb.velocity.x > -0.2 * speed)
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
    IEnumerator MoveSequence()
    {
        yield return new WaitForSeconds(1f);
        Rolling = true;
        yield return new WaitForSeconds(2f);
        Rolling = false;
        transform.eulerAngles = new Vector3(0,0,0);
    }
    IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
    private void Roll()
    {
        if(Rolling == true)
        {
            transform.eulerAngles += new Vector3(0, 0, RotationSpeed * Time.deltaTime);
        }
    }
}
