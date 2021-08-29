using System;
using System.Collections;
using DG.Tweening;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
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
                NewsPaper.Instance.NowHeadline += postPosition + ' ';
                NewsPaper.Instance.endEnter = false;
                if (NewsPaper.Instance.nowEnterState != CardInfo.Why)
                {
                    NewsPaper.Instance.nowEnterState += 1;
                }
                else
                {
                    if (GameManager.Instance.curDay >= 14)
                    {
                        AudioManager.Instance.bgmPlayer.audioSource.volume = .5f;
                        AudioManager.Instance.PlaySound(BgmState.Ending);
                        SceneManager.LoadScene("Demo_NewsEnding");
                    }
                    GameManager.Instance.PassOneDay(NewsPaper.Instance.NowHeadline);
                    NewsPaper.Instance.nowEnterState = CardInfo.Who;
                    StartCoroutine(CoDirectNewsPaper());
                    AudioManager.Instance.PlaySound("Newspaper");
                }
                NewsPaper.Instance.deck.SelectDeck();
            }).AddTo(gameObject);
    }

    private IEnumerator CoDirectNewsPaper()
    {
        var news = NewsPaper.Instance;
        var pos = news.transform.position;
        news.transform.DOMove(news.transform.position + new Vector3(0, 1000, 0), 1f);
        yield return new WaitForSeconds(1f);
        NewsPaper.Instance.NowHeadline = news.text.text = "";
        news.transform.DOMove(pos, 1f);
    }
}