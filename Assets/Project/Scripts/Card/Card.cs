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

    public GameObject cardEffect;
    public Vector3 cardEffectScale = new Vector3(1, 1, 1);

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

    public void UseEffect(Vector3 start, Vector3 end)
    {
        GameObject effect = Instantiate(cardEffect, start, Quaternion.identity);
        effect.transform.localScale = cardEffectScale;
    }

    public void UseEffect(Character target)
    {
        GameObject effect = Instantiate(cardEffect, target.transform);
        effect.transform.localPosition += new Vector3(0, -2, 0);
        effect.transform.localScale = cardEffectScale;
    }
}
