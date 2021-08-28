using System.Collections.Generic;

public class EventData
{
    public int eventNumber;
    public string eventContent;
    public Dictionary<CardInfo, int> matchingCard;

    public EventData(int eventNumber, string eventContent, Dictionary<CardInfo, int> matchingCard)
    {
        this.eventNumber = eventNumber;
        this.eventContent = eventContent;
        this.matchingCard = matchingCard;
    }
}