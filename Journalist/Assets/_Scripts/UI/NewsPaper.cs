using System.Collections;
using System.Collections.Generic;
using System.IO;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NewsPaper : MonoSingleton<NewsPaper>, IDropHandler
{
    public Text text;
    public CardInfo nowEnterState;
    public bool endEnter;

    [SerializeField] private string nowHeadline;
    
    public string NowHeadline
    {
        get => nowHeadline;
        set
        {
            nowHeadline = value;
            text.text = nowHeadline;
        }
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        StartCoroutine(CoDirectCard(eventData.pointerDrag.transform));
        NowHeadline += eventData.pointerDrag.GetComponent<Card>().Data.cardContent;

        endEnter = true;
    }

    private IEnumerator CoDirectCard(Transform cardTransform)
    {
        cardTransform.DOScale(cardTransform.localScale * .5f, .5f);
        yield return new WaitForSeconds(.5f);
    }
}