using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : Manager<DeckManager>
{
    private const int PLAYER_MAX_HANDS = 10;

    public GameObject handZone;
    public GameObject cardDisplayPrefab;

    [SerializeField]
    private Card[] allCardList;
    [SerializeField]
    private List<Card> playerCardList = new List<Card>();
    [SerializeField]
    private List<Card> playerDeck = new List<Card>();
    [SerializeField]
    private List<Card> playerHand = new List<Card>();
    [SerializeField]
    private List<Card> playerUsed = new List<Card>();

    private List<CardDisplay> handObject = new List<CardDisplay>();

    [SerializeField]
    private int numPlayerDraw = 5;

    private void Awake()
    {
        allCardList = Resources.FindObjectsOfTypeAll<Card>();
        handZone = UIManager.Instance.handZone;

        cardDisplayPrefab = (GameObject)Resources.Load("Prefabs/UI/Card");
    }


    public void CheckCardHighlight()
    {
        foreach (var obj in handObject)
        {
            if (obj != null)
                obj.SetHighlight();
        }
    }

    public void SetNewBattleDeck()
    {
        handZone = UIManager.Instance.handZone;
        playerDeck.AddRange(playerCardList);
        ShuffleCard(playerDeck);
    }

    public void SetPlayerCardList(List<Card> deck)
    {
        playerCardList.AddRange(deck);
    }

    private Card GetCardFromDeck()
    {
        Card card = playerDeck[0];
        playerDeck.RemoveAt(0);
        return card;
    }

    public void DrawCard()
    {
        if(playerDeck.Count < numPlayerDraw)
        {
            ShuffleCard(playerUsed);
            playerDeck.AddRange(playerUsed);
            playerUsed.Clear();
        }
        
        while(playerHand.Count < numPlayerDraw)
        {
            Card tmpCard = GetCardFromDeck();
            playerHand.Add(tmpCard);
        }
    }

    public void RemoveAllHands()
    {
        playerUsed.AddRange(playerHand);
        playerHand.Clear();
    }

    public void RemoveAllHandObjects()
    {
        foreach(Transform child in handZone.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        handObject.Clear();
    }

    public void SetHand()
    {
        RemoveAllHandObjects();

        Debug.Log(playerHand.Count);

        for(int i = 0; i < playerHand.Count; i++)
        {
            Debug.Log(i);
            CardDisplay cardDisplay = Instantiate(cardDisplayPrefab, 
                                                 handZone.transform).GetComponent<CardDisplay>();
            cardDisplay.BindCard(playerHand[i]);

            handObject.Add(cardDisplay);
        }

        CheckCardHighlight();
    }

    public bool RemoveSpecificCardFromHand(Card card)
    {
        playerHand.Remove(card);
        playerUsed.Add(card);

        return true;
    }

    private void ShuffleCard(List<Card> cardList)
    {
        if (cardList == null || cardList.Count <= 0)
        {
            return;
        }

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

    public void InsertCardToPlayerCardList(Card card)
    {
        if(playerCardList == null)
        {
            Debug.Log("TRY_INSERT_NULL_TO_PLAYER_CARD_LIST");
            return;
        }
        playerCardList.Add(card);
    }

    public Card GetRandomCardFromAllCardList()
    {
        if (allCardList == null || allCardList.Length <= 0)
            return null;

        return allCardList[Random.Range(0, allCardList.Length)];
    }
}
