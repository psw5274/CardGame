using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuffType
{
    SKILL_DAMAGE,
    PLAYER_HP
}

[CreateAssetMenu(fileName = "New Buff Ability", menuName = "Buff Ability")]

public class BuffAbility : CardAbility
{
    public BuffType buffType;

    public override void UseAbility(Character target = null)
    {
        base.UseAbility(target);
    }

    public override void CardEffect()
    {
        base.CardEffect();
    }
}
