using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : PersistentSingleton<GameManager>
{
    public List<string> newsRecords = new List<string>();  // 지금까지 만든 뉴스 기사들
    public List<int> doneEvents = new List<int>();  // 일어난 사건들(index)
    public int curDay; // 날짜 - 0 : 첫째날

    public Dictionary<int, EventData> eventDatas = new Dictionary<int, EventData>(); // 총 이벤트 목록
    public Dictionary<int, CardData> cardDatas = new Dictionary<int, CardData>(); // 총 카드 목록

    private EventData todayEvent;

    private readonly CardInfo[] CardInfos = (CardInfo[]) Enum.GetValues(typeof(CardInfo));

    private readonly string[] ResourcePaths =
    {
        @"CSV/EventData",
        @"CSV/WhoData", @"CSV/WhenData", @"CSV/WhereData",
        @"CSV/WhatData", @"CSV/HowData", @"CSV/WhyData"
    };

    private void Start()
    {
        InitCsvData();
        //LoadData();
        UpdateEvent();
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

    private class SavingData
    {
        public string[] newsRecords;
        public int curDay;
        public int today;
        public int[] doneEvents;

        public SavingData(string[] newsRecords, int curDay, int today, int[] doneEvents)
        {
            this.newsRecords = newsRecords;
            this.curDay = curDay;
            this.today = today;
            this.doneEvents = doneEvents;
        }
    }

    // Data Save / Load
    public void SaveData()
    {
        var data = new SavingData(newsRecords.ToArray(), curDay, todayEvent.eventNumber, doneEvents.ToArray());

        CreateJsonFile(Application.dataPath, "GameManagerData", data);
    }

    public void LoadData()
    {
        var data = LoadJsonFile<SavingData>(Application.dataPath, "GameManagerData");

        newsRecords = data.newsRecords.ToList();
        curDay = data.curDay;
        todayEvent = eventDatas[data.today];
        doneEvents = data.doneEvents.ToList();
    }

    public void InitData()
    {
        newsRecords = new List<string>();
        doneEvents = new List<int>();
        curDay = 0;
        todayEvent = null;
    }

    // 하루 넘기기
    public void PassOneDay(string news)
    {
        AddNewsRecord(news);
        curDay++;
        UpdateEvent();
        SaveData();
    }

    // 완성된 타이틀 목록 추가
    private void AddNewsRecord(string news)
    {
        newsRecords.Add(news);
    }

    // Json Save/Load
    private void CreateJsonFile<T>(string createPath, string fileName, T obj)
    {
        var jsonData = JsonUtility.ToJson(obj);

        var fileStream =
            new FileStream($"{createPath}/{fileName}", FileMode.Create); // 생성자 FileStream(String, FileMode)
        var data = Encoding.UTF8.GetBytes(jsonData);

        fileStream.Write(data, 0, data.Length); // byte로 인코딩 한 것을 파일스트림에 작성
        fileStream.Close();
    }

    private T LoadJsonFile<T>(string loadPath, string fileName)
    {
        var fileStream = new FileStream($"{loadPath}/{fileName}.Json", FileMode.Open);
        var data = new byte[fileStream.Length];

        fileStream.Read(data, 0, data.Length);
        fileStream.Close();

        var jsonData = Encoding.UTF8.GetString(data);
        return JsonUtility.FromJson<T>(jsonData);
    }

    #endregion

    #region Event / Card

    // 이벤트 갱신 : 하루가 초기화 되었을 때 호출
    private EventData UpdateEvent()
    {
        var randomEvent = eventDatas.Keys
            .Where(key => !doneEvents.Contains(key))
            .OrderBy(key => Guid.NewGuid()).First();
        todayEvent = eventDatas[randomEvent];
        doneEvents.Add(randomEvent);

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
            .Where(value => value.cardInfo == cards[0].cardInfo && value.cardNumber != cards[0].cardNumber)
            .OrderBy(value => Guid.NewGuid()).Take(2);
        int i = 0;
        foreach (var card in randomCards)
        {
            cards[++i] = card;
        }

        return cards.OrderBy(_ => new Guid()).ToArray();
    }

    #endregion

    // 데이터 표시
    [ContextMenu("EventDatas")]
    public void ShowEventDatas()
    {
        StringBuilder text = new StringBuilder();
        foreach (var data in eventDatas)
        {
            text.Append($"{data.Key} : {data.Value.eventContent}\n");
        }

        Debug.Log(text.ToString());
    }

    [ContextMenu("CardDatas")]
    public void ShowCardDatas()
    {
        StringBuilder text = new StringBuilder();
        foreach (var data in cardDatas)
        {
            text.Append($"{data.Key} : {data.Value.cardInfo} {data.Value.cardContent} {data.Value.cardDescription}\n");
        }

        Debug.Log(text.ToString());
    }
}
