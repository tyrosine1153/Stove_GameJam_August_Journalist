using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameButton : MonoBehaviour // 사실과 메모장 상태 변경
{
    public GameObject Note; // Note 캔버스 불러오기
    public bool State;

    void Start() // 처음엔 상태를 비활성화로
    {
        State = false;
        Note.SetActive(false);
    }

    public void OnClickNotePad()
    {
        if (State == false) // 비활성화 -> 활성화
        {
            Note.SetActive(true);
            State = true;
        }
        
        else if (State == true) // 활성화 -> 비활성화
        {
            Note.SetActive(false); 
            State = false; 
        }
    }
    
}
