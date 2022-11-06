using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UtsuhoGetPlayerLocation : MonoBehaviour
{
    public Transform player;
    private float x;
    private float y;

    public float GetCurrentZ()
    {
        x = transform.localPosition.x;
        y = transform.localPosition.y;
        double CurrentZ = Math.Sqrt(x * x + y * y);
        return (float)CurrentZ;
    }
    private void Update()
    {
        transform.position = player.position;
    }
}
