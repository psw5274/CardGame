using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCardAbility : ScriptableObject
{
    public int amount;
    public virtual void UseAbility(Character target = null)
    {
        Debug.Log("Ability : " + this.ToString() + 
                  "Target : " + target.ToString() + " : " + amount);
    }
}
