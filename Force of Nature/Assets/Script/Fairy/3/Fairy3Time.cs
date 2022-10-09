using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy3Time : MonoBehaviour
{
    public void ConcealBreak()
    {
        GetComponent<Collider2D>().enabled = true;
        GetComponent<Fairy3Behavior>().enabled = true;
    }
}
