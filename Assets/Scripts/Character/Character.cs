using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class Character : MonoBehaviour
{

    public Sprite characterImage;
    public Sprite hpBar;

    [SerializeField]
    private int statMaxHP;

    [SerializeField]
    private int statATK;
    [SerializeField]
    private int statHP;
    [SerializeField]
    private int statBarrier;

    private List<Card> playerDeck;
    private List<Card> playerHand;

    // buff list for every turn
    private List<BuffAbility> buffList;
    private List<BuffAbility> barrierList;

    public virtual void OnDamage(int damage)
    {
        statHP -= damage;
        Debug.Log(this.ToString() + " GetDamage : " + damage);

        if (statHP <= 0)
        {
            OnCharacterDie();
        }
    }

    public virtual void OnHeal(int amount)
    {
        statHP += amount;

        if(statHP > statMaxHP)
        {
            statHP = statMaxHP;
        }
    }

    public virtual void AddATK(int amount)
    {
        statATK += amount;
    }

    // 회복 등의 즉시 발동 버프
    public void SetBuffImmediately(BuffAbility buff)
    {
        buff.SetTarget(this);
        buff.OnBuffBegin();
        buff.OnBuffEnd();
    }
    public void SetBuff(BuffAbility buff)
    {
        buff.SetTarget(this);
        buff.OnBuffBegin();

        buffList.Add(buff);
    }

    // 매턴 시작 시 버프 체크 및 활성화
    public void OnBuff()
    {
        foreach (var buff in buffList)
        {
            buff.OnNewTurn();
        }
    }

    // 매턴 시작 시 기존 버프 턴 줄이고 유효하지 않은 버프 제거
    public void EndBuff()
    {
        foreach(var buff in buffList)
        {
            buff.ReduceRemainTurn();

            if(buff.GetRemainTurn() <= 0)
            {
                buff.OnBuffEnd();
            }
        }
    }

    // call when character's new turn begin
    public void OnTurnBegin()
    {
        EndBuff();
        OnBuff();

        Debug.Log("[GAME]" + this + "TURN_BEGIN");
    }

    public void OnTurnEnd()
    {
        Debug.Log("[GAME]" + this + "TURN_END");
    }

    public void OnCharacterDie()
    {


        Debug.Log("[GAME]" + this + "DIE");
    }

    public void SetCharacterBarrier()
    {


    }

    public void Start()
    {
        this.statHP = statMaxHP;

        this.gameObject.GetComponent<Image>().sprite = this.characterImage;
    }
}