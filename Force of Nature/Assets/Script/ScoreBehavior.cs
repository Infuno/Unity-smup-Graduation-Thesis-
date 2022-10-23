using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehavior : MonoBehaviour
{
    public long TotalScore;

    private void FixedUpdate()
    {
        this.GetComponent<Text>().text = TotalScore.ToString();
    }
    public long AddScore(int Score)
    {
        TotalScore += Score;
        return TotalScore;
    }
    public long AddScore(long Score)
    {
        TotalScore += Score;
        return TotalScore;
    }
}
