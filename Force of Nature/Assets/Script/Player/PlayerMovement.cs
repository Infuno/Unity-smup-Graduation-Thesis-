using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform player;
    public float Nomalspeed;
    public float FocusSpeed;
    public Rigidbody2D rb;
    public Animator HitBoxAnimator;

    bool IsFocus;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    float currentSpeed;
    private void Update()
    {
        if (Input.GetButtonDown("SlowMode"))
        {
            IsFocus = true;
            
        }
        if (Input.GetButtonUp("SlowMode"))
        {
            IsFocus = false;
        }
        if (IsFocus == false)
        {
            currentSpeed = Nomalspeed;
            HitBoxAnimator.SetBool("IsFocus", false);
        }
        if (IsFocus == true)
        {
            currentSpeed = FocusSpeed;
            HitBoxAnimator.SetBool("IsFocus", true);
        }
        horizontalMove = Input.GetAxisRaw("Horizontal") * currentSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * currentSpeed;
        //CoreMoveCode();
    }
    private void FixedUpdate()
    {
        CoreMoveCode();
        InvisibleWall();
    }
    private void CoreMoveCode()
    {
        player.transform.localPosition += new Vector3(horizontalMove * Time.deltaTime, 0, 0);
        player.transform.localPosition += new Vector3(0, verticalMove * Time.deltaTime, 0);
    }
    private void InvisibleWall()
    {
        if (player.transform.position.x >= 3.7f)
        {
            player.transform.position = new Vector3(3.7f, player.transform.position.y, 0);
        }
        if (player.transform.position.x <= -3.7f)
        {
            player.transform.position = new Vector3(-3.7f, player.transform.position.y, 0);
        }
        if (player.transform.position.y >= 4.5)
        {
            player.transform.position = new Vector3(player.transform.position.x, 4.5f, 0);
        }
        if (player.transform.position.y <= -4.5)
        {
            player.transform.position = new Vector3(player.transform.position.x, -4.5f, 0);
        }
    }
}
