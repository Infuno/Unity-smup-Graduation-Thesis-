using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBackgroundSpin : MonoBehaviour
{
    void Update()
    {
        transform.eulerAngles += new Vector3(0,0,20 * Time.deltaTime);
    }
}
