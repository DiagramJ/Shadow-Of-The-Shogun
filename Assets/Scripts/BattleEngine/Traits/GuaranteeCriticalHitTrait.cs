using UnityEngine;
using System.Collections;

public class GuaranteeCriticalHitTrait : Trait
{
    public GuaranteeCriticalHitTrait(int ID)
    {
        id = ID;
        name = "Guarantee Critical Hit";
        info = new Message("Guarantee critical hit");
        cooldown = 5;
        action = new ApplyStatusEffectAction(StatusEffectList.GuaranteeCriticalHit);
        type = TargetSelf;
        shareCooldown = new int[1];
        shareCooldown[0] = TraitList.SelfHeal;
    }
}