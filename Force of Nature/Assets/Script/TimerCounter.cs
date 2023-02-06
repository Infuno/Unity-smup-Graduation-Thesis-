using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class TimerCounter : MonoBehaviour
{
    public float MaxTimer;
    public float CurrentTimer;
    public double MaxBonusScore;
    public double CurrentBonusScore;

    public Text BonusScoreText;

    private bool IsRunning = true;
    private int TimeColor=0;
    private bool TimerSound = true;
    private void FixedUpdate()
    {
        CountingDown();
        BonusScoreText.text = SetBonusPoint().ToString("0");
        if(CurrentBonusScore == double.PositiveInfinity)
        {
            BonusScoreText.text = MaxBonusScore.ToString("0");
        }
    }
    public void CountingDown()
    {
        if (IsRunning == true)
        {
            CurrentTimer -= Time.deltaTime;
            string SetTimer = CurrentTimer.ToString("0.00");
            this.GetComponent<Text>().text = SetTimer;
        }
        if (CurrentTimer <=0)
        {
            CurrentTimer = 0;
            string GetTimer = CurrentTimer.ToString("0.00");
            this.GetComponent<Text>().text = GetTimer;
            IsRunning = false;
        }
        if(CurrentTimer < 10)
        {
            
            TimeColor = 1;
            if(CurrentTimer < 5)
            {
                TimeColor = 2;
            }
        }
        if (CurrentTimer > 10)
        {
            TimeColor = 0;
        }
        if (CurrentTimer < 10 && TimerSound == true)
        {
            StartCoroutine(TimeSound());
            TimerSound = false;
        }
        if (TimeColor == 0)
        {
            this.GetComponent<Text>().color = new Color(1f, 1f, 1f);
        }
        if (TimeColor == 1)
        {
            this.GetComponent<Text>().color = new Color(1f, 0.5f, 0.5f);
        }
        if (TimeColor == 2)
        {
            this.GetComponent<Text>().color = new Color(1f, 0f, 0f);
        }
    }
    public void ActiveTimer(float SetTime)
    {
        MaxTimer = SetTime;
        CurrentTimer = MaxTimer;
        IsRunning = true;
        TimerSound = true;
    }
    public double SetBonusPoint()
    {
        float Percent = CurrentTimer / MaxTimer;
        CurrentBonusScore = MaxBonusScore * Percent;
        CurrentBonusScore = Math.Round(CurrentBonusScore,0);
        return CurrentBonusScore;
    }
    public void SetMaxScore(double score)
    {
        MaxBonusScore = score;
    }
    public double GetCurrentScore()
    {
        return CurrentBonusScore;
    }
    IEnumerator TimeSound()
    {
        FindObjectOfType<AudioManager>().Play("Time10");
        yield return new WaitForSeconds(1);
        FindObjectOfType<AudioManager>().Play("Time10");
        yield return new WaitForSeconds(1);
        FindObjectOfType<AudioManager>().Play("Time10");
        yield return new WaitForSeconds(1);
        FindObjectOfType<AudioManager>().Play("Time10");
        yield return new WaitForSeconds(1);
        FindObjectOfType<AudioManager>().Play("Time10");
        yield return new WaitForSeconds(1);
        FindObjectOfType<AudioManager>().Play("Time5");
        yield return new WaitForSeconds(1);
        FindObjectOfType<AudioManager>().Play("Time5");
        yield return new WaitForSeconds(1);
        FindObjectOfType<AudioManager>().Play("Time5");
        yield return new WaitForSeconds(1);
        FindObjectOfType<AudioManager>().Play("Time5");
        yield return new WaitForSeconds(1);
        FindObjectOfType<AudioManager>().Play("Time5");
        yield return new WaitForSeconds(1);

    }
}
