using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxSpin : MonoBehaviour
{
    public Transform HitBox;
    public float Speed;
    void Update()
    {
        HitBox.transform.eulerAngles += new Vector3(0, 0, Speed * Time.deltaTime);
    }
}
