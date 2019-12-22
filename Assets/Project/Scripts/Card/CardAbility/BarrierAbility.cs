using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Barrier Ability", menuName = "Barrier Ability")]
public class BarrierAbility : AbstractCardAbility
{
    override public void UseAbility(Character target)
    {
        base.UseAbility(target);

        target.OnBarrier(amount);
    }
}
