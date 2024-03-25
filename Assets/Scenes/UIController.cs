using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{
    [SerializeField] Text[] CurretnScoreTxt;
    [SerializeField] Text[] HighScoreTxt;
    [SerializeField] Button btnRefresh;
    void Start()
    {
        btnRefresh.onClick.AddListener(() => Reload());
    }

    // Update is called once per frame
    void Update()
    {
        Score_ManagerSinglenton.Instance.UpdateScore(CurretnScoreTxt[0]);
        Score_ManagerSinglenton.Instance.UpdateMaxScore(HighScoreTxt[0]);
        Score_ManagerSinglenton.Instance.UpdateScore(CurretnScoreTxt[1]);
        Score_ManagerSinglenton.Instance.UpdateMaxScore(HighScoreTxt[1]);
    }
    public void Reload()
    {
        Score_ManagerSinglenton.Instance.score1 = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
