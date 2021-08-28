using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingDay : MonoBehaviour
{
    public Text Day;
    public Text RecordsNews;
    public Text Fect;
    
    public int EndDay = 0;
    void Start()
    {
        Day = GameObject.Find("Day").GetComponent<Text>();
        RecordsNews= GameObject.Find("RecordNews").GetComponent<Text>();
        Fect= GameObject.Find("Fect").GetComponent<Text>();
        EndDay += 1;
        
    }

    
    void Update()
    {
        Day.text = "8월 " + EndDay + "일자";
        RecordsNews.text = GameManager.Instance.newsRecords[EndDay - 1];     
        Fect.text = GameManager.Instance.GetEvent().eventContent;
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
            SceneManager.LoadScene("Demo_Choi");
        }
    }

}
