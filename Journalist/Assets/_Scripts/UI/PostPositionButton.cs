﻿using System;
using System.Collections;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class PostPositionButton : MonoBehaviour
{
    public string postPosition;

    private Button _button;

    private IEnumerator Start()
    {
        _button = GetComponent<Button>();
        yield return null;
        
        _button.OnClickAsObservable().Where(_ => NewsPaper.Instance.endEnter)
            .Subscribe(_ =>
            {
                NewsPaper.Instance.NowHeadline += postPosition;
                NewsPaper.Instance.endEnter = false;
                GameManager.Instance.PassOneDay(NewsPaper.Instance.NowHeadline);
            }).AddTo(gameObject);
    }
}