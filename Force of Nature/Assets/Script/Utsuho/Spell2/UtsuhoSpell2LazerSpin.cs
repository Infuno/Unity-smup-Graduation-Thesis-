using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtsuhoSpell2LazerSpin : MonoBehaviour
{
    public Transform MoveToObject;

    public float MoveSpeed;
    public float SwitchTime;
    public UtsuhoSpell2LazerGuider LazerGuider;
    public Rigidbody2D Rigidbody;
    public Animator LazerAnimator;
    public float Damage;

    Vector2 MoveToPosition = Vector2.zero;
    private void Start()
    {
        StartCoroutine(SwitchLocation());
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, MoveToPosition, MoveSpeed * Time.deltaTime);

    }

    IEnumerator SwitchLocation()
    {
        yield return new WaitForSeconds(SwitchTime / 2);
        LazerAnimator.SetBool("IsShow",true);

        yield return new WaitForSeconds(SwitchTime/2 - 0.5f);
        MoveToPosition = MoveToObject.position;

        yield return new WaitForSeconds(SwitchTime);
        StartCoroutine(SwitchLocation());
    }
    private void OnTriggerStay2D(Collider2D hitInfo)
    {
        PlayerHealth playerHealth = hitInfo.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.PlayerTakeDamage(Damage);
        }
    }
}
