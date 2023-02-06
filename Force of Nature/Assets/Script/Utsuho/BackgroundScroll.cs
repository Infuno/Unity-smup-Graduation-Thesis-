using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroll : MonoBehaviour
{
    public RawImage Image;
    public float x, y;

    private void Update()
    {
        Image.uvRect = new Rect(Image.uvRect.position + new Vector2(x, y) * Time.deltaTime, Image.uvRect.size);
    }
}
