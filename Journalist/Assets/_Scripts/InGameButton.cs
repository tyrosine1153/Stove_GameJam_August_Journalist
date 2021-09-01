using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InGameButton : MonoBehaviour // 사실과 메모장 상태 변경
{
    public GameObject Note; // Note 캔버스 불러오기
    public bool State;
    private float timer;
    void Start() // 처음엔 상태를 비활성화로
    {
        State = false;
        Note.SetActive(false);
        timer = 0;
    }
    
    public void OnClickNotePad()
    {
        AudioManager.Instance.PlaySound("Memo");
        if (State == false) // 비활성화 -> 활성화
        {
            Note.SetActive(true);
            Note.GetComponentInChildren<Text>().text = GameManager.Instance.GetEvent().eventContent;
            State = true;
        }

        else if (State) // 활성화 -> 비활성화
        {
            Note.SetActive(false);
            State = false;
        }
    }

    public void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.5)
        {
            Note.GetComponentInChildren<Text>().text = GameManager.Instance.GetEvent().eventContent;
            timer = 0;
        }
    }
}