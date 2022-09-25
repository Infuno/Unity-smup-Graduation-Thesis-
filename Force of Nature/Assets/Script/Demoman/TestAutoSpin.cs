using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAutoSpin : MonoBehaviour
{
    public GameObject Spinner;
    public float SpinSpeed;

    private void FixedUpdate()
    {
        Spinner.transform.eulerAngles += new Vector3(0,0, SpinSpeed * Time.deltaTime);
    }
}
