using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    public Animator BossAnimator;

    public void Boss1isHover()
    {
        BossAnimator.SetBool("IsHover",true);
    }
    public void Boss1isOut()
    {
        BossAnimator.SetBool("IsHover", false);
    }
    public void LoadMap1()
    {
        SceneManager.LoadScene(1);
    }
}
