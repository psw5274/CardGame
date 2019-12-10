using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : Manager<DeckManager>
{
    [SerializeField]
    private List<Card> playerDeck;
    [SerializeField]
    private List<Card> playerHand;

    private Card GetCardFromDeck()
    {
        Card card = playerDeck[0];
        playerDeck.RemoveAt(0);
        return card;
    }

    public void DrawCard()
    {
        Card tmpCard = GetCardFromDeck();
        playerHand.Add(tmpCard);
    }

    public bool RemoveSpecificCardFromHand(Card card)
    {
        return playerHand.Remove(card);
    }

    private void ShuffleCard(List<Card> cardList)
    {
        int random1;
        int random2;
        Card tmp;

        for (int index = 0; index < cardList.Count; ++index)
        {
            random1 = Random.Range(0, cardList.Count);
            random2 = Random.Range(0, cardList.Count);

            tmp = cardList[random1];
            cardList[random1] = cardList[random2];
            cardList[random2] = tmp;
        }
    }
}
