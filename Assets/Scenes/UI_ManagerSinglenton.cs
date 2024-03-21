using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_ManagerSinglenton : MonoBehaviurSinglenton<UI_ManagerSinglenton>
{
    public int score1;
    public int score2;
    //private static UI_ManagerSinglenton _instance;
    //public static UI_ManagerSinglenton Instance { get { return _instance; } }

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
    public override void Prueba()
    {
        base.Prueba();
        Debug.Log(",mira");
    }
}
