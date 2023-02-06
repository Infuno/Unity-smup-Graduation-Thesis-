using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtsuhoSpell3TurnerBehavior : MonoBehaviour
{
    public Transform Player;
    public float Speed;
    bool Turning = true;
    public GameObject ChargeEffect;

    private void Start()
    {
        StartCoroutine(TimeToMove(3));
    }
    private void Update()
    {
        Behavior();
    }
    private void Behavior()
    {
        if(Turning == true)
        {
            Vector3 difference = Player.position - transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90);
        }
        if (Turning == false)
        {
            this.GetComponent<Rigidbody2D>().velocity = transform.up * Speed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            this.GetComponent<Rigidbody2D>().velocity = transform.up * 0;
            Turning = true;
            StartCoroutine(TimeToMove(2));
        }
    }
    IEnumerator TimeToMove(float Wait)
    {
        ChargeEffect.SetActive(true);
        yield return new WaitForSeconds(Wait);
        ChargeEffect.SetActive(false);
        Turning = false;
    }
}
