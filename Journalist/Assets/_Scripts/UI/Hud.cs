using System;
using UnityEngine;
using UnityEngine.UI;

public class Hud : Widget
{
    private Text PrintDay;

    private void Start() //Day 
    {
        PrintDay = GetComponent<Text>();
    }

    private void Update() //날짜 출력
    {
        PrintDay.text = (GameManager.Instance.curDay + 1) + "/15 일차";
    }
    
    
}