using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTest : MonoBehaviour
{
    public AudioSource Instrumental;
    public AudioSource Vocal;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Instrumental.volume = 0;
            Vocal.volume = 1;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instrumental.volume = 1;
            Vocal.volume = 0;
        }
    }
}
