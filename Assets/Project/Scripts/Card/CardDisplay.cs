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
    public Outline cardOutline;
    public Text cardName;
    public Text cardDescription;
    public Text cardCost;

    public GameObject cardEffect;

    // refactoring to (bool isUsable)
    public bool isHighlighting = false;


    public void BindCard(Card cardData)
    {
        cardTemplate = transform.Find("CardTemplate").GetComponent<Image>();
        cardPortrait = transform.Find("CardPortrait").GetComponent<Image>();

        cardOutline = transform.Find("CardBackground").GetComponent<Outline>();

        cardName = transform.Find("CardName").GetComponent<Text>();
        cardDescription = transform.Find("CardDescription").GetComponent<Text>();
        cardCost = transform.Find("CostImage/CardCost").GetComponent<Text>();

        cardData.Print();

        this.cardData = cardData;
        this.cardName.text = cardData.cardName;
        this.cardDescription.text = cardData.cardDescription;
        this.cardCost.text = cardData.cardCost.ToString();
        this.cardPortrait.sprite = cardData.cardPortrait;
        this.cardTemplate.sprite = cardData.cardTemplate;
    }

    public bool UseCard(Character target = null)
    {
        if(!BattleManager.Instance.UsePlayerCost(cardData.cardCost))
        {
            return false;
        }

        this.UseEffect();

        cardData.UseCard(target);
        cardData.UseEffect(target);


        this.RemoveCard();
        return true;
    }

    public void UseEffect()
    {
        GameObject effect = Instantiate(cardEffect,
                                        this.transform.position,
                                        Quaternion.identity);
        Debug.Log(effect);
    }

    // 묘지로 보내거나 풀링 할 수도 있어야함
    public void RemoveCard()
    {
        DeckManager.Instance.RemoveSpecificCardFromHand(this.cardData);
        Destroy(this.gameObject);
    }

    public void SetHighlight()
    {
        if (!isHighlighting &&
           BattleManager.Instance.playerRemainCost >= this.cardData.cardCost)
        {
            SetHighlight(true);
        }
        else if (isHighlighting &&
                BattleManager.Instance.playerRemainCost < this.cardData.cardCost)
        {
            SetHighlight(false);
        }
    }

    public void SetHighlight(bool value)
    {
        if(value)
        {
            isHighlighting = true;
            cardOutline.enabled = true;
        }
        else
        {
            isHighlighting = false;
            cardOutline.enabled = false;
        }
    }
}
