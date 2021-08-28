using System;
using System.Collections.Generic;
using UnityEngine;
public struct EventData
{
    public int eventNumber;
    public string eventContent;
    public Dictionary<CardInfo, int> matchingCard;
    public bool isHappened;
    
    public EventData(int eventNumber, string eventContent, Dictionary<CardInfo, int> matchingCard, bool isHappened = false)
    {
        this.eventNumber = eventNumber;
        this.eventContent = eventContent;
        this.matchingCard = matchingCard;
        this.isHappened = isHappened;
    }
}
