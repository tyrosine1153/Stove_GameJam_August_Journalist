using UnityEngine;
using UnityEngine.EventSystems;

public class NewsPaper : Widget, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.transform.position = transform.position;
    }
}