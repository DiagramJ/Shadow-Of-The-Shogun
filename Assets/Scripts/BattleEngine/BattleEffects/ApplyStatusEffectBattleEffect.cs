using UnityEngine;
using System.Collections;

public class ApplyStatusEffectBattleEffect : BattleEffect
{
    public int statusEffectID;
    public ApplyStatusEffectBattleEffect(int Type)
    {
        type = Type;
    }
    public override void run(Character character)
    {
        StatusEffect effect = BattleManager.instance.statusEffectList.get(statusEffectID, character);
        bool found = character.BattleStats.addStatusEffect(effect);
        if (!found)
            effect.applyEffects(character);
    }
    public override void run(AttackData attackData)
    {
    }
    public override void falloff(Character character)
    {
    }
    public override void apply(Character character)
    {
    }
}