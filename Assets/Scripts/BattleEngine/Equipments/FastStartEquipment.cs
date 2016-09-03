using UnityEngine;
using System.Collections;

public class FastStartEquipment: Equipment
{
    public FastStartEquipment()
    {
        name = "fastStart";
        description = "Doubles speed for one turn at the start of battle";
        effects = new BattleEffect[1];
        ApplyStatusEffectBattleEffect temp = new ApplyStatusEffectBattleEffect(BattleEffect.BattleStart);
        temp.statusEffectID = StatusEffectList.Sprint;
        effects[0] = temp;
    }
}
