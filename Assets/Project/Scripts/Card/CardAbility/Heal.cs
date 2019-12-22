using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Heal Ability", menuName = "Heal Ability")]
public class Heal : AbstractCardAbility
{
    override public void UseAbility(Character target = null)
    {
        base.UseAbility(target);

        target.OnHeal(amount);
    }
}
