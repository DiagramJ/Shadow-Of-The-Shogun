using UnityEngine;
using System.Collections;

public class SelfBuffAttackTrait : Trait
{
    public SelfBuffAttackTrait(int ID)
    {
        id = ID;
        name = "Attack Buff";
        info = new Message("Buff Attack by 25%");
        cooldown = 5;
        action = new ApplyStatusEffectAction(StatusEffectList.AttackBuff);
        type = TargetSelf;
    }
}
