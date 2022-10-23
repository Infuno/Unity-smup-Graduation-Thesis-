using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BonusScore : MonoBehaviour
{
    public Text Score;
    public TimerCounter timerCounter;
    public ScoreBehavior scoreBehavior;
    private void Start()
    {
        Score.text = timerCounter.GetCurrentScore().ToString();
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void AddScore()
    {
        scoreBehavior.AddScore((long)timerCounter.GetCurrentScore());
    }
}
