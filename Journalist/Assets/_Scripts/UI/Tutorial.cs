using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UniRx;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Text cutsceneText;
    [SerializeField] private Image blackBoard;

    [SerializeField] private int tutorialStep;

    [SerializeField] private GameObject[] tutorial;

    private void Awake()
    {
        Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0))
            .Subscribe(_ => OnClickBoardClick()).AddTo(gameObject);
    }

    public void OnClickBoardClick()
    {
        switch (tutorialStep)
        {
            case 0:
                blackBoard.color = new Color(1f, 1f, 1f, 0.5f);
                cutsceneText.color = new Color(1, 1, 1, 0);
                
                tutorial[0].SetActive(true);
                break;
            
            case 1:
                tutorial[0].SetActive(false);
                tutorial[1].SetActive(true);
                
                break;
            
            case 2:
                tutorial[1].SetActive(false);
                tutorial[2].SetActive(true);
                
                break;
                
            case 3:
                tutorial[2].SetActive(false);
                tutorial[3].SetActive(true);
                
                break;
            
            
            case 4:
                tutorial[3].SetActive(false);
                tutorial[4].SetActive(true);
                
                break;
            
            case 5:
                tutorial[4].SetActive(false);
                tutorial[5].SetActive(true);
                
                break;
            
            
            case 6:
                gameObject.SetActive(false);
                tutorial[5].SetActive(false);
                blackBoard.color = new Color(1, 1, 1, 0);
                break;
            
            default:
                break;
        }
        tutorialStep++;
    }
}
