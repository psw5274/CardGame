using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SelfDamage Ability", menuName = "Self Damage Ability")]
public class SelfDamage : AbstractCardAbility
{
    override public void UseAbility(Character target)
    {
        target = BattleManager.Instance.playerCharacter;
        base.UseAbility(target);

        amount += BattleManager.Instance.playerCharacter.GetSkillDamage();

        target.OnDamage(amount);
    }
}
