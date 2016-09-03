using UnityEngine;
using System.Collections;

public class SprintStatusEffect : StatusEffect
{
    BattleEffect drawback;
    public SprintStatusEffect(Character attacker)
    {
        name = "Sprint";
        id = StatusEffectList.Sprint;
        effects = new BattleEffect[1];
        turnCount = 1;
        ChangeStatBattleEffect temp = new ChangeStatBattleEffect();
        temp.setSpeed(1.0f, 0);
        effects[0] = temp;

        ApplyStatusEffectBattleEffect temp2 = new ApplyStatusEffectBattleEffect(BattleEffect.NoType);
        temp2.statusEffectID = StatusEffectList.SprintDrawback;
        drawback = temp2;
    }
    public override bool endTurn(Character character)
    {
        bool returnValue = base.endTurn(character);
        drawback.run(character);
        return returnValue;
    }
}
