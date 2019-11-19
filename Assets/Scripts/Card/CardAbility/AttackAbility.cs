using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Attack Ability", menuName = "Attack Ability")]
public class AttackAbility : AbstractCardAbility
{
    override public void UseAbility(Character target = null)
    {
        target = target == null ? BattleManager.Instance.enemyCharacter : target;
        base.UseAbility(target);

        target.GetDamage(amount);
    }

    public override void CardEffect()
    {
        base.CardEffect();
        Debug.Log("ATTACK_EFFECT");

    }
}
