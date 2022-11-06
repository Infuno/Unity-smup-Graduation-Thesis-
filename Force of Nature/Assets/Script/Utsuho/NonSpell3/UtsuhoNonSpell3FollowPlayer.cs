using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtsuhoNonSpell3FollowPlayer : MonoBehaviour
{
    public Transform Player;

    private void Update()
    {
        transform.position = Player.position;
    }
}
