using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPressPause : MonoBehaviour
{
    public GameObject pausePanel;
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
