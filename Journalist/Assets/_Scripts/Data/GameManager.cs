using System;
using System.Collections.Generic;
using System.Linq;

public class GameManager : PersistentSingleton<GameManager>
{
    public List<string> newsRecords = new List<string>(); // 지금까지 만든 뉴스 기사들
    public int curDay; // 날짜 - 0 : 첫째날

    public Dictionary<int, EventData> eventDatas; // 총 이벤트 목록
    public Dictionary<int, CardData> cardDatas; // 총 카드 목록

    private EventData todayEvent;

    private readonly CardInfo[] CardInfos = (CardInfo[]) Enum.GetValues(typeof(CardInfo));
        //= {CardInfo.How, CardInfo.When, CardInfo.Where, CardInfo.What, CardInfo.How, CardInfo.Why};

    private readonly string[] ResourcePaths =
    {
        @"CSV\EventData.csv", 
        @"CSV\WhoData.csv", @"CSV\WhenData.csv", @"CSV\WhereData.csv", 
        @"CSV\HowData.csv", @"CSV\WhatData.csv", @"CSV\WhyData.csv"
    };

    private void Start()
    {
        InitCsvData();
    }

    #region Data

    private void InitCsvData()
    {
        // 이벤트 csv 긁어오기
        var eventDatasCSV = CSVReader.Read(ResourcePaths[0]);
        foreach (var eventData in eventDatasCSV)
        {
            var matchingCard = new Dictionary<CardInfo, int>();
            foreach (var cardInfo in CardInfos)
            {
                matchingCard[cardInfo] = (int) eventData[cardInfo.ToString()];
            }

            eventDatas[(int) eventData["Number"]]
                = new EventData((int) eventData["Number"], (string) eventData["Text"], matchingCard);
        }

        // 카드 csv 긁어오기
        foreach (var cardInfo in CardInfos)
        {
            var cardDatasSCV = CSVReader.Read(ResourcePaths[(int) cardInfo]);
            foreach (var cardData in cardDatasSCV)
            {
                cardDatas[(int) cardData["Number"]]
                    = new CardData((int) cardData["Number"], (string) cardData["Text"], cardInfo,
                        (string) (cardData.ContainsKey("Desc") ? cardData["Desc"] : null));
            }
        }
    }

    // 하루 넘기기
    public void PassOneDay(string news)
    {
        AddNewsRecord(news);
        curDay++;

    }

    // 완성된 타이틀 목록 추가
    private void AddNewsRecord(string news)
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
