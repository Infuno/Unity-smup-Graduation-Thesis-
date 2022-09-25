using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackTarget : MonoBehaviour
{

    public Transform Player;
    public GameObject prefab;

    void Update()
    {
        Vector3 difference = Player.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ); ;

        if(Input.GetKeyDown(KeyCode.C))
        {
            Instantiate(prefab, transform.position, transform.rotation);
        }
    }
}
