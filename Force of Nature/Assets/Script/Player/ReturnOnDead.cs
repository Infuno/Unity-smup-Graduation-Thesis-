using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnOnDead : MonoBehaviour
{
    public Transform Player;

    public void ResetPlayer()
    {
        Player.localPosition = new Vector2(0, -4);
    }
}
