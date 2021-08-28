using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Deck : MonoBehaviour, IDropHandler
{
    private HorizontalLayoutGroup _layoutGroup;
    private void Start()
    {
        _layoutGroup = GetComponent<HorizontalLayoutGroup>();
        
        var cards = GameManager.Instance.GetCards(CardInfo.How);
        foreach (var card in cards)
        {
            Widget.Create<Card>().Data = card;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        _layoutGroup.spacing = 1;
        _layoutGroup.spacing = 0;
    }
}