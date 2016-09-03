using UnityEngine;
using System.Collections;

public class GuaranteeCriticalHitStatusEffect : StatusEffect
{
    public GuaranteeCriticalHitStatusEffect(Character attacker)
    {
        name = "GuaranteeCriticalHit";
        id = StatusEffectList.GuaranteeCriticalHit;
        effects = new BattleEffect[0];
        turnCount = 1;
    }
    public override void run(AttackData attackData, int type)
    {
        if(type == BattleEffect.AfterAttack)
        {
            attackData.critical = true;
        }
    }
}
