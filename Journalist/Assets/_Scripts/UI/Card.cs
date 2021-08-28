using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : Widget, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Text nameText, descriptionText;
    [SerializeField] private Image profileImage;
    
    private bool _isDragable = true;

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
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        if (_isDragable)
        {
            transform.position = eventData.position;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_isDragable)
        {
            GetComponent<Graphic>().raycastTarget = false;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_isDragable)
        {
            GetComponent<Graphic>().raycastTarget = true;
        }
    }
}