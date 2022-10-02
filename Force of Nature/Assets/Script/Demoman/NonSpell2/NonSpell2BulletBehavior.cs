using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonSpell2BulletBehavior : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float Damage;

    private GameObject Player;
    private Transform PlayerTranform;
    public bool SlowingDown = true;
    private float AimingAngel;

    private void Start()
    {
        rb.velocity = transform.up * speed;
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerTranform = Player.transform;
        AimingAngel = GetRotate();
    }

    private void Update()
    {
        if(SlowingDown == true)
        {
            rb.velocity -= rb.velocity * speed/10 * Time.deltaTime;
        }
        StartCoroutine(HoldAndFire());

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.PlayerTakeDamage(Damage);
        }
        Destroy(gameObject);
    }
    private float GetRotate()
    {
        Vector3 difference = PlayerTranform.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        return rotationZ-90;
    }
    IEnumerator HoldAndFire()
    {
        yield return new WaitForSeconds(1);
        SlowingDown = false;
        yield return new WaitForSeconds(0.1f);
        transform.eulerAngles = new Vector3(0,0, AimingAngel);
        rb.velocity = transform.up * speed;
    }
}
