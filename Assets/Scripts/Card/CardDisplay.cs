using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class CardDisplay : MonoBehaviour, IPointerDownHandler
{
    public Card cardData;

    // Displayed Component
    private Image cardTemplate;
    private Image cardPortrait;
    private Text cardName;
    private Text cardDescription;
    private Text cardCost;


    void Start()
    {
        cardTemplate = GetComponent<Image>();
        cardPortrait = transform.Find("CardPortrait").GetComponent<Image>();

        cardName = transform.Find("CardName").GetComponent<Text>();
        cardDescription = transform.Find("CardDescription").GetComponent<Text>();
        cardCost = transform.Find("CardCost").GetComponent<Text>();


        if (cardData != null)
        {
            BindCard(cardData);
        }
    }

    private void BindCard(Card cardData)
    {
        cardData.Print();

        this.cardName.text = cardData.cardName;
        this.cardDescription.text = cardData.cardDescription;
        this.cardCost.text = cardData.cardCost.ToString();
        this.cardPortrait.sprite = cardData.cardPortrait;
        this.cardTemplate.sprite = cardData.cardTemplate;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        cardData.UseCard();
    }
}
