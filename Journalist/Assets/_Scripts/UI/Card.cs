using UnityEngine;
using UnityEngine.EventSystems;

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
            
        }
        
        throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_isDragable)
        {
            
        }
        
        throw new System.NotImplementedException();
    }
}