using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingDay : MonoBehaviour
{
    public Text Day;
    public Text RecordsNews;
    public Text Fact;

    public GameObject Credit;
    
    public int EndDay = 0;
    void Start()
    {
        Day = GameObject.Find("Day").GetComponent<Text>();
        RecordsNews= GameObject.Find("RecordNews").GetComponent<Text>();
        Fact= GameObject.Find("Fact").GetComponent<Text>();
        EndDay += 1;
        
    }

    
    void Update()
    {
        Day.text = "8월 " + EndDay + "일자";
        RecordsNews.text = GameManager.Instance.newsRecords[EndDay - 1];
        Fact.text = GameManager.Instance.eventDatas[GameManager.Instance.doneEvents[EndDay - 1]].eventContent;
    }

    public void OnClickRightButton()
    {
        if (EndDay < 15)
        {
            EndDay++;
        }
        
    }

    public void OnClickLeftButton()
    {
        if (EndDay > 1)
        {
            EndDay--;
        }
    }

    public void OnclickQuitButton()
    {
        if (EndDay == 15)
        {
            SceneManager.LoadScene("Demo_Strat");
            AudioManager.Instance.bgmPlayer.audioSource.volume = 1f;
            AudioManager.Instance.PlaySound(BgmState.Home);
            
        }
    }

    public void OnClickCredit()
    {
        Credit.SetActive(true);
    }

    public void OnClickCreditPanel()
    {
        Credit.SetActive(false);
    }
}
