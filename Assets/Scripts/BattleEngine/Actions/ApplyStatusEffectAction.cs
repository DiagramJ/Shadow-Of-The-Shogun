using UnityEngine;
using System.Collections;

public class ApplyStatusEffectAction : Action
{
    public int type;
    public ApplyStatusEffectAction( int Type)
    {
        type = Type;
    }
    public override void run(Character attacker, int[] targets)
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i] != -1)
            {
                Character target = (Character)BattleManager.instance.list.get(targets[i]);
                if (target != null)
                {
                    StatusEffect effect = BattleManager.instance.statusEffectList.get(type, attacker);
                    bool found = target.BattleStats.addStatusEffect(effect);
                    if (!found)
                        effect.applyEffects(target);

                }
            }
        }
    }
}