using UnityEngine;

public struct CardData
{
    public int cardNumber;
    public string cardContent;
    public CardInfo cardInfo;
    public string cardDescription;

    public CardData(int cardNumber, string cardContent, CardInfo cardInfo, string cardDescription = null)
    {
        this.cardNumber = cardNumber;
        this.cardContent = cardContent;
        this.cardInfo = cardInfo;
        this.cardDescription = cardDescription;
    }
}
