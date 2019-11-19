using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName  = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    // 카드에 들어가는 능력들
    [SerializeField]
    public List<AbstractCardAbility> cardAbilityList;

    public string cardName;
    public string cardDescription;
    public int cardCost;
    public Sprite cardPortrait;
    public Sprite cardTemplate;

    public void UseCard(Character target = null)
    {
        foreach (AbstractCardAbility ability in cardAbilityList)
        {
            ability.UseAbility(target);
        }
    }

    public void Print()
    {
        Debug.Log(name + ":" + cardDescription + " The card Costs:"  + cardCost);
    }
}
