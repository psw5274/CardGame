using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class CardDisplay : MonoBehaviour
{
    public Card cardData;

    // Displayed Component
    public Image cardTemplate;
    public Image cardPortrait;
    public Text cardName;
    public Text cardDescription;
    public Text cardCost;


    void Start()
    {
        cardTemplate = transform.Find("CardTemplate").GetComponent<Image>();
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

    public void UseCard(Character target = null)
    {
        cardData.UseCard(target);
        this.RemoveCard();
    }

    public void SetTarget()
    {
        
    }

    // 묘지로 보내거나 풀링 할 수도 있어야함
    public void RemoveCard()
    {
        Destroy(this.gameObject);
    }
}
