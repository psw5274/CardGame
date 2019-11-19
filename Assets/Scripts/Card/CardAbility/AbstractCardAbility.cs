using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCardAbility : ScriptableObject
{
    public int amount;
    public virtual void UseAbility(Character target = null)
    {
        CardEffect();

        Debug.Log("Ability : " + this.ToString() + 
                  "Target : " + target.ToString() + " : " + amount);

    }

    public virtual void CardEffect()
    {
        Debug.Log("ON_EFFECT");
    }
}
