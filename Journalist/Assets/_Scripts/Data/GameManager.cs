using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : PersistentSingleton<GameManager>
{
    public int curDay;  // 0 : 첫째날
    public List<string> newsRecords = new List<string>();  // 지금까지 만든 뉴스 기사들

    public Dictionary<int, EventData> eventDatas;  // 총 이벤트 목록
    public Dictionary<int, CardData> cardDatas;  // 총 카드 목록

    private EventData todayEvent;

    #region Data
    public void InitData()
    {
        // 이벤트 csv 긁어오기
        int eventNumber = 0;
        eventDatas[eventNumber] = new EventData(eventNumber, "", new Dictionary<CardInfo, int>());
        
        // 카드 csv 긁어오기
        int cardNumber = 0;
        string[] asdf = new string[3];
        cardDatas[cardNumber] = new CardData(cardNumber, "", CardInfo.Who, asdf.Length > 2 ? asdf[0] : null);
    }
    
    // 완성된 타이틀 목록
    public void AddNewsRecord(string news)
    {
        newsRecords.Add(news);
    }

    #endregion
    
    #region Event / Card
    
    // 이벤트 갱신 : 하루가 초기화 되었을 때 호출
    public EventData UpdateEvent()
    {
        var randomEvent = eventDatas.Values
            .Where(value => !value.isHappened)
            .OrderBy(value => Guid.NewGuid()).First();
        todayEvent = randomEvent;
        
        return todayEvent;
    }
    
    // 이벤트 얻기
    public EventData GetEvent()
    {
        return todayEvent;
    }

    // 카드 종류별 덱3장 얻기
    public CardData[] GetCards(CardInfo cardInfo)
    {
        var cards = new CardData[3];

        var matchingCardIndex = todayEvent.matchingCard[cardInfo];
        cards[0] = cardDatas[matchingCardIndex];

        var randomCards = cardDatas.Values
            .Where(value => value.cardInfo == cardInfo)
            .OrderBy(value => Guid.NewGuid()).Take(2);
        int i = 0;
        foreach (var card in randomCards)
        {
            cards[++i] = card;
        }

        return cards;
    }

    #endregion
}
