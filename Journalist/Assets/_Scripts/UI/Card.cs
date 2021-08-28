using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : Widget, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private bool _isDragable = true;
    
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