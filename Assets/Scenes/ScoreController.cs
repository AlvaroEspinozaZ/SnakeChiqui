using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreController : MonoBehaviour
{
    [SerializeField] Text[] CurretnScoreTxt;
    [SerializeField] Text[] HighScoreTxt;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UI_ManagerSinglenton.Instance.UpdateScore(CurretnScoreTxt[0]);
        UI_ManagerSinglenton.Instance.UpdateMaxScore(HighScoreTxt[0]);
        UI_ManagerSinglenton.Instance.UpdateScore(CurretnScoreTxt[1]);
        UI_ManagerSinglenton.Instance.UpdateMaxScore(HighScoreTxt[1]);
    }
}
