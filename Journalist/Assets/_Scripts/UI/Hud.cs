using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hud : Widget
{
    private Text PrintDay;
    private int ToDay = 1;

    private void Start() //Day 연결
    {
        PrintDay = GameObject.Find("Day").GetComponent<Text>();
    }

    private void Update() //날짜 출력
    {
        PrintDay.text = ToDay + "/15 일차";
    }

    private void GameClear()
    {
        if (ToDay > 15)
        {
            SceneManager.LoadScene("Demo_ending");
        }
    }
    
    
}