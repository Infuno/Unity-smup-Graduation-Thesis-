using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    public float Speed = 4f;
    public Vector3 StartPosition;
    public float ResetPosition;

    private void FixedUpdate()
    {
        transform.Translate(translation:Vector3.left * Speed * Time.deltaTime);
        if(transform.position.y <= ResetPosition)
        {
            transform.localPosition = StartPosition;
        }
    }
}
