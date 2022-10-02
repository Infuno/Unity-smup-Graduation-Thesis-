using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackOnly : MonoBehaviour
{
    public Transform Player;

    public bool Tracking = true;
    private void Update()
    {
        if (Tracking == true)
        {
        Vector3 difference = Player.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        }
    }
    public void StartTracking()
    {
        Tracking = true;
    }
    public void StopTracking()
    {
        Tracking = false;
    }
}
