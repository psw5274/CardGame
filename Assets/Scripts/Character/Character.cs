using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public Sprite characterImage;
    public int statHP;
    public int statAttk;

    private List<Card> playerDeck;
    private List<Card> playerHand;

    // buff list for every turn
    private List<BuffAbility> buffList;

    public virtual void GetDamage(int damage)
    {
        statHP -= damage;
        Debug.Log(this.ToString() + " GetDamage : " + damage);

        if (statHP <= 0)
        {
            OnCharacterDie();
        }
    }

    // 회복 등의 즉시 발동 버프
    public void SetImmediateBuff(BuffAbility buff)
    {

    }
    public void SetBuff(BuffAbility buff)
    {

    }

    public void OnBuff()
    {

    }

    public void EndBuff()
    {

    }

    // call when character's new turn begin
    public void OnTurnBegin()
    {
        
    }

    public void OnTurnEnd()
    {

    }

    public void OnCharacterDie()
    {

    }
}