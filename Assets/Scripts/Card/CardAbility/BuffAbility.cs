using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuffType
{
    SKILL_DAMAGE,
    PLAYER_HP
}

[CreateAssetMenu(fileName = "New Buff Ability", menuName = "Buff Ability")]
public class BuffAbility : AbstractCardAbility
{
    public BuffType buffType;

    // if 0 : do immediately
    public int buffTurn = 0;
    public int remainTurn = 0;

    public override void UseAbility(Character target = null)
    {
        target = target == null ? BattleManager.Instance.playerCharacter : target;
        base.UseAbility(target);

        if(buffTurn == 0)
        {
            BattleManager.Instance.playerCharacter.SetBuff(this);
        }
        else
        {
            BattleManager.Instance.playerCharacter.SetBuff(this);
        }
    }

    public override void CardEffect()
    {
        base.CardEffect();

        Debug.Log("BUFF_EFFECT");
    }
}
