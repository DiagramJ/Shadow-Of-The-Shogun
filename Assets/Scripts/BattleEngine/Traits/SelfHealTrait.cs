using UnityEngine;
using System.Collections;

public class SelfHealTrait : Trait
{
    public SelfHealTrait(int ID)
    {
        id = ID;
        name = "Self Heal";
        info = new Message("Heal 100 HP");
        cooldown = 3;
        BasicHealAction temp = new BasicHealAction();
        temp.baseDamage = 100;
        temp.accuracy = 100;
        temp.flatHeal = true;
        action = temp;
        type = TargetSelf;
        shareCooldown = new int[1];
        shareCooldown[0] = TraitList.GuaranteeCriticalHit;
    }
}
