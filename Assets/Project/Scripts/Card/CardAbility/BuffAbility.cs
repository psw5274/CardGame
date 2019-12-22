using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuffType
{
    SKILL_DAMAGE,
    PLAYER_HP,
    PLAYER_BARRIER
}

[CreateAssetMenu(fileName = "New Buff Ability", menuName = "Buff Ability")]
public class BuffAbility : AbstractCardAbility
{
    public BuffType buffType;

    // if 0 : do immediately
    public int buffTurn = 0;
    public int remainTurn = 0;

    public Character target;

    public override void UseAbility(Character target = null)
    {
        target = target == null ? BattleManager.Instance.playerCharacter : target;
        base.UseAbility(target);

        // 즉발 버프
        if(buffTurn == 0)
        {
            BattleManager.Instance.playerCharacter.SetBuffImmediately(this);
        }
        else
        {
            BattleManager.Instance.playerCharacter.SetBuff(this);
        }
    }

    public int GetRemainTurn()
    {
        return remainTurn;
    }
    public void ReduceRemainTurn()
    {
        remainTurn--;
    }

    public void SetTarget(Character target)
    {
        this.target = target;
    }
}
