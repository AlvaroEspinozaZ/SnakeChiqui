using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score_ManagerSinglenton : MonoBehaviurSinglenton<Score_ManagerSinglenton>
{
    public int score1;
    public int score2;

    public override void Awake()
    {
        base.Awake();
    }
    public void UpdateScore()
    {
        score1 += 1;
        if(score2< score1)
        {
            score2 = score1;
        }
    }
    public void UpdateScore(Text Score)
    {
        Score.text = "Score: " + score1;
    }
    public void UpdateMaxScore(Text MaxScore)
    {
        MaxScore.text = "MaxScore: " + score2;
    }
}
