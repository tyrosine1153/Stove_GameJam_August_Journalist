using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Deck : MonoBehaviour, IDropHandler
{
    private HorizontalLayoutGroup _layoutGroup;
    public List<Card> deck;
    
    private IEnumerator Start()
    {
        _layoutGroup = GetComponent<HorizontalLayoutGroup>();
        yield return null;
        SelectDeck();
    }

    public void SelectDeck()
    {
        var cards = GameManager.Instance.GetCards(NewsPaper.Instance.nowEnterState);
        foreach (var card in cards)
        {
            deck.Add(Widget.Create<Card>());
            deck[deck.Count - 1].Data = card;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        _layoutGroup.spacing = 1;
        _layoutGroup.spacing = 0;
    }
}