using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour
{
    public void OnClickQuitButton() //게임 종료 버튼
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else 
        Application.Quit();
#endif
        
    }

    public void OnClickStartButton() //게임 시작 버튼 
    {
        AudioManager.Instance.PlaySound(BgmState.Game);
        SceneManager.LoadScene("Demo_Kim");//메인 게임과 연결 완료 
    }
}
