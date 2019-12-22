using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    public CharacterData characterData;

    public GameObject hpBarObject;
    public GameObject barrierBarObject;
    public Image hpBar;
    public Image barrierBar;

    [SerializeField]
    private int statMaxHP;

    [SerializeField]
    private int statHP;
    [SerializeField]
    private int statBarrier = 0;
    [SerializeField]
    private int statSkillDamage = 0;

    // buff list for every turn
    private List<BuffAbility> buffList = new List<BuffAbility>();

    public Animator characterAnimator;

    private void Awake()
    {
        characterAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        hpBarObject = Instantiate(UIManager.Instance.hpBarPrefab,
                                  transform.parent);
        barrierBarObject = Instantiate(UIManager.Instance.barrierBarPrefab,
                                       transform.parent);
        barrierBarObject.SetActive(false);
        hpBar = hpBarObject.GetComponentInChildren<Image>();
        barrierBar = barrierBarObject.GetComponentInChildren<Image>();
        SetStatusBar();
    }

    
    public virtual void BindCharacter(CharacterData data)
    {
        characterData = data;

        this.statMaxHP = characterData.statMaxHP;

        this.statHP = statMaxHP;
    }

    public void IncreaseSkillDamage(int amount)
    {
        statSkillDamage += amount;
    }

    public int GetSkillDamage()
    {
        return statSkillDamage;
    }

    public virtual void OnDamage(int damage)
    {
        Debug.Log(this.ToString() + " GetDamage : " + damage);

        if (statBarrier > 0)
        {
            statBarrier -= damage;

            if (statBarrier < 0)
            {
                damage = -statBarrier;
                statBarrier = 0;
            }
            else
            {
                damage = 0;
            }
        }

        if (damage > 0)
        {
            statHP -= damage;

            if (statHP <= 0)
            {
                statHP = 0;
            }

            if (statHP <= 0)
            {
                this.OnCharacterDie();
            }
        }

        SetStatusBar();
    }

    public void SetStatusBar()
    {
        if (statBarrier <= 0)
        {
            barrierBarObject.SetActive(false);
        }
        else
        {
            barrierBarObject.SetActive(true);
            barrierBar.GetComponentInChildren<Text>().text = statBarrier.ToString();
        }
        
        // hp ui hard coding
        hpBar.fillAmount = (float)statHP / statMaxHP;
        hpBar.GetComponentInChildren<Text>().text = statHP + " / " + statMaxHP;
    }

    public virtual void OnHeal(int amount)
    {
        statHP += amount;

        if(statHP > statMaxHP)
        {
            statHP = statMaxHP;
        }
        SetStatusBar();
    }

    public virtual void OnBarrier(int amount)
    {
        statBarrier += amount;
        SetStatusBar();

    }

    public virtual void AddSkillDamage(int amount)
    {
        statSkillDamage += amount;
    }

    // 회복 등의 즉시 발동 버프
    public void SetBuffImmediately(BuffAbility buff)
    {

    }
    public void SetBuff(BuffAbility buff)
    {

    }

    // call when character's new turn begin
    public virtual void OnTurnBegin()
    {
        
        Debug.Log("[GAME]" + this + "TURN_BEGIN");
    }

    public void OnTurnEnd()
    {
        Debug.Log("[GAME]" + this + "TURN_END");
    }

    public void OnCharacterDie()
    {
        this.characterAnimator.Play("Dead", -1, 0f);
        
        Debug.Log("[GAME]" + this + "DIE");
    }

    public void SetCharacterBarrier()
    {


    }

    public bool IsDead()
    {
        if(this.statHP <= 0)
            return true;
        return false;
    }
}