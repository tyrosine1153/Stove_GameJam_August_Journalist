using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    
}
