using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtsuhoNonSpell3HeatSeekerBulletBehavior : MonoBehaviour
{
    public float Speed;
    public float Damage;

    private GameObject Player;

    private bool IsChange = false;
    private bool Tracking = false;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        this.GetComponent<Rigidbody2D>().velocity = transform.up * Speed;
        StartCoroutine(TimeOut());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 2)
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.layer == 11 && IsChange == false)
        {
            this.GetComponent<Animator>().SetTrigger("IsChange");
            Changing();
        }
        if(IsChange == true && collision.gameObject.layer != 11)
        {
            Destroy(this.gameObject);
        }

        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.PlayerTakeDamage(Damage);
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (Tracking == true)
        {
            Vector3 difference = Player.transform.position - transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90);
        }
    }
    public void Changing()
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Tracking = true;
        IsChange = true;
        StartCoroutine(ChangeDone());
    }
    IEnumerator ChangeDone()
    {
        yield return new WaitForSeconds(3);
        Tracking = false;
        this.GetComponent<Rigidbody2D>().velocity = transform.up * 2;
    }
    IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(6);
        if(IsChange == false)
        {
            Destroy(this.gameObject);
        }
        
    }
}
