using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class YouDiedButtonBehavior : MonoBehaviour
{
    public GameObject PauseMenu;
    public void Continue()
    {
        print("Continue");
    }
    public void Retry2()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1.0f;
        print("Retry");
    }
    public void Retry()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
        print("Retry");
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
        print("Exit");
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
        PauseMenu.SetActive(false);
    }
}
