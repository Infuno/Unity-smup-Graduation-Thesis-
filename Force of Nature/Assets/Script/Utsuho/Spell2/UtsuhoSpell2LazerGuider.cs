using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtsuhoSpell2LazerGuider : MonoBehaviour
{
    public Transform Player;
    public Animator LazerAnimator;
    public void OffSignal()
    {
        LazerAnimator.SetBool("IsShow",false);
    }
    public void MoveToPlayer()
    {
        this.transform.position = Player.transform.position;
        if (transform.position.x >= 2.0f)
        {
            transform.position = new Vector3(2.0f, transform.position.y, 0);
        }
        if (transform.position.x <= -2.0f)
        {
            transform.position = new Vector3(-2.0f, transform.position.y, 0);
        }
        if (transform.position.y >= 3.0)
        {
            transform.position = new Vector3(transform.position.x, 3.5f, 0);
        }
        if (transform.position.y <= -3.0)
        {
            transform.position = new Vector3(transform.position.x, -3.5f, 0);
        }
    }
}
