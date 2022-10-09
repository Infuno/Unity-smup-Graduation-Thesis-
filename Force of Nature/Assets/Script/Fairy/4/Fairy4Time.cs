using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy4Time : MonoBehaviour
{
    public void ConcealBreak()
    {
        GetComponent<Collider2D>().enabled = true;
        GetComponent<Fairy4Behavior>().enabled = true;
    }
}
