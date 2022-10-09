using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningPoint : MonoBehaviour
{
    public float SpinSpeed;
    void Update()
    {
        transform.eulerAngles += new Vector3(0,0,SpinSpeed*Time.deltaTime);
    }
}
