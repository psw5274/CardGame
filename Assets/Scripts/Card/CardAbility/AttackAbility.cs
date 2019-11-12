using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Attack Ability", menuName = "Attack Ability")]
public class AttackAbility : CardAbility
{
    override public void UseAbility(Character target = null)
    {
        if(target == null)
        {
            target = BattleManager.Instance.enemyCharacter;
            Debug.Log(target);

        }
        base.UseAbility(target);

        Debug.Log(target.ToString());
        target.statHP -= amount;
    }

    public override void CardEffect()
    {
        base.CardEffect();
        Debug.Log("ATTACK EFFECT");

    }
}
