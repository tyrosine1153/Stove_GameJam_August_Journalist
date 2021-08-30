using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameExit : MonoBehaviour
{
    public GameObject ExitWindow;

    public void Start()
    {
        ExitWindow.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
           ExitWindow.SetActive(true);
        }
    }

    public void OnClickYes()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else 
        Application.Quit();
#endif
    }

    public void OnClickNo()
    {
        ExitWindow.SetActive(false);
    }
}
