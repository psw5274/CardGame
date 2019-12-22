using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SkillDamageBuff Ability", menuName = "SkillDamageBuff Ability")]
public class SkillDamageBuff : AbstractCardAbility
{
    override public void UseAbility(Character target)
    {
        base.UseAbility(target);

        target.IncreaseSkillDamage(amount);
    }
}
