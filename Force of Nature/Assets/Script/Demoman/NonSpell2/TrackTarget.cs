using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackTarget : MonoBehaviour
{

    public Transform Player;
    public bool Tracking = true;

    void Update()
    {
        if (Tracking == true)
        {
            Vector3 difference = Player.position - transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90);
        }
    }
    public void StartTracking1()
    {
        Tracking = true;
    }
    public void StopTracking1()
    {
        Tracking = false;
    }
    public float getDirection()
    {
        float direction = transform.eulerAngles.z;
        return direction;
    }
}
