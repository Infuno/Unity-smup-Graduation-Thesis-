using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy2Time : MonoBehaviour
{
    public void ConcealBreak()
    {
        GetComponent<Collider2D>().enabled = true;
        GetComponent<Fairy2Behavior>().enabled = true;
    }
}
