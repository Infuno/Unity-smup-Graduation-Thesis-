using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtsuhoSpell3ObjectFollow : MonoBehaviour
{
    public Transform Following;

    private void Update()
    {
        transform.position = Following.position;
    }
}
