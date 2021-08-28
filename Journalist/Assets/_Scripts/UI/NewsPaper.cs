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
    public Transform trashTransform;
    public Deck deck;

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
        foreach (var tempCard in deck.deck)
        {
            StartCoroutine(CoDirectCard(tempCard.transform));
        }
        StartCoroutine(CoDirectCard(eventData.pointerDrag.transform));
        var card = eventData.pointerDrag.GetComponent<Card>();
        NowHeadline += card.Data.cardContent;
        endEnter = true;
    }

    private IEnumerator CoDirectCard(Transform cardTransform)
    {
        cardTransform.SetParent(transform);
        var card = cardTransform.GetComponent<Card>();
        card.isDragable = false;
        
        cardTransform.DOScale(cardTransform.localScale * .5f, .5f);
        yield return new WaitForSeconds(.5f);
        cardTransform.DOMove(trashTransform.position, .5f);
        cardTransform.GetComponent<RectTransform>().pivot = new Vector2(1, 0);
        yield return new WaitForSeconds(.5f);
        cardTransform.DOScale(Vector3.zero, .5f);
        yield return new WaitForSeconds(.5f);

        deck.deck.Remove(card);
        Destroy(cardTransform.gameObject);
    }
}