using System;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : Widget, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Text nameText, descriptionText;
    [SerializeField] private Image profileImage;
    
    public bool isDragable = true;

    private CardData _data;
    
    public CardData Data
    {
        get => _data;
        set
        {
            _data = value;
            Show();
        }
    }

    public override void Show()
    {
        if (Data.cardInfo == CardInfo.Who)
        {
            nameText.text = Data.cardContent;
            descriptionText.text = Data.cardDescription;
        }
        else
        {
            descriptionText.text = Data.cardContent;
        }

        profileImage.sprite = GetSpriteByInfo(NewsPaper.Instance.nowEnterState);
    }

    public static Sprite GetSpriteByInfo(CardInfo info)
    {
        return info switch
        {
            CardInfo.Who => Resources.Load<Sprite>("CardImage/Who"),
            CardInfo.When => Resources.Load<Sprite>("CardImage/When"),
            CardInfo.Where => Resources.Load<Sprite>("CardImage/Where"),
            CardInfo.How => Resources.Load<Sprite>("CardImage/How"),
            CardInfo.What => Resources.Load<Sprite>("CardImage/What"),
            CardInfo.Why => Resources.Load<Sprite>("CardImage/Why"),
            _ => throw new Exception("?")
        };
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        if (isDragable)
        {
            transform.position = eventData.position;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isDragable)
        {
            GetComponent<Graphic>().raycastTarget = false;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isDragable)
        {
            GetComponent<Graphic>().raycastTarget = true;
        }
    }
}