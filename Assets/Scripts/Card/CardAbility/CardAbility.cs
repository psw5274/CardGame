using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardAbility : ScriptableObject
{
    public int amount;
    public virtual void UseAbility(Character target = null)
    {
        CardEffect();

        Debug.Log("Ability : " + this.ToString() + " : " + amount);

    }
    public virtual void CardEffect()
    {
        Debug.Log("ON_EFFECT");
    }
}
