using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerIgnore : MonoBehaviour
{
    private void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 8);
        Physics2D.IgnoreLayerCollision(7, 8);
        Physics2D.IgnoreLayerCollision(8, 7);

        Physics2D.IgnoreLayerCollision(6, 8);
        Physics2D.IgnoreLayerCollision(9, 0);
        Physics2D.IgnoreLayerCollision(2, 7);
    }
}
