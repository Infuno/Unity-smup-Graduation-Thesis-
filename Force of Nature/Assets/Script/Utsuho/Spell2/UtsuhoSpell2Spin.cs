using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtsuhoSpell2Spin : MonoBehaviour
{
    public float SpinSpeed;
    void Update()
    {
        transform.localEulerAngles += new Vector3(0, 0, SpinSpeed * Time.deltaTime);
    }
}
