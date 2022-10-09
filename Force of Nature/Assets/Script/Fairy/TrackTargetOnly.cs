using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackTargetOnly : MonoBehaviour
{
    private GameObject Player;
    private Transform PlayerTranform;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerTranform = Player.transform;
    }
    private void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, GetRotate());
    }
    private float GetRotate()
    {
        Vector3 difference = PlayerTranform.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        return rotationZ - 90;
    }
}
