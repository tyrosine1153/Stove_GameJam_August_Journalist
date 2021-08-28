using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour
{
    public void OnClickQuitButton() //게임 종료 버튼
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void OnClickStartButton() //게임 시작 버튼
    {
        SceneManager.LoadScene("Demo_main_game");//메인 게임과 연결 완료 
    }
    
    
}
