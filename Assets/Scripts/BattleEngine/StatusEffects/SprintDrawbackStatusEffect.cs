using UnityEngine;
using System.Collections;

public class SprintDrawbackStatusEffect : StatusEffect
{

    public SprintDrawbackStatusEffect(Character attacker)
    {
        name = "SprintDrawback";
        id = StatusEffectList.SprintDrawback;
        effects = new BattleEffect[1];
        turnCount = 4;
        ChangeStatBattleEffect temp = new ChangeStatBattleEffect();
        temp.setSpeed(-0.50f, 0);
        effects[0] = temp;
    }
}
