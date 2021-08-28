using System;
using UnityEngine;
using UnityEngine.UI;

public class Hud : Widget
{
    private Text PrintDay;
    private int ToDay = 1;

    private void Start() //Day 
    {
        PrintDay = GameObject.Find("Day").GetComponent<Text>();
    }

    private void Update() //날짜 출력
    {
        PrintDay.text = ToDay + "/15 일차";
    }
    
    
}