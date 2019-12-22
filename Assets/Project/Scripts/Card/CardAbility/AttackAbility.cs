using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attack Ability", menuName = "Attack Ability")]
public class AttackAbility : AbstractCardAbility
{
    override public void UseAbility(Character target)
    {
        base.UseAbility(target);

        amount += BattleManager.Instance.playerCharacter.GetSkillDamage();

        target.OnDamage(amount);
    }
}
