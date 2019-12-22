using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField]
    private int statATK;
    [SerializeField]
    private GameObject enemyAttackEffect;

    public override void BindCharacter(CharacterData data)
    {
        base.BindCharacter(data);

        statATK = data.statATK;
        enemyAttackEffect = data.enemyAttackEffect;
    }

    public override void OnTurnBegin()
    {
        base.OnTurnBegin();

        StartCoroutine(this.OnAttack());
    }


    public IEnumerator OnAttack()
    {
        characterAnimator.Play("Attack", -1, 0f);

        yield return new WaitForSeconds(1);

        var effect = Instantiate(enemyAttackEffect,
                                EffectManager.Instance.playerEffectPosition + new Vector3(0,0, -10),
                                Quaternion.identity);
        effect.transform.localScale = new Vector3(3, 3, 3);

        BattleManager.Instance.playerCharacter.OnDamage(this.statATK);
        yield return new WaitForSeconds(1);
        characterAnimator.Play("Idle", -1, 0f);
    }

}
