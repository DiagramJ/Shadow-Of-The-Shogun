using UnityEngine;
using System.Collections;

public class AttackBuffStatusEffect : StatusEffect
{
    public AttackBuffStatusEffect(Character attacker)
    {
        name = "AttackBuff";
        id = StatusEffectList.AttackBuff;
        effects = new BattleEffect[1];
        turnCount = 3;
        ChangeStatBattleEffect temp = new ChangeStatBattleEffect();
        temp.setAttack(0.25f, 0);
        effects[0] = temp;
    }
}
