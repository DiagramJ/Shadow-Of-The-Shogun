using UnityEngine;
using System.Collections;
using System;

public class BasicAttackAction : Action
{
    public int baseDamage;
    public int accuracy;
    public bool phisical;
    public bool flatDamage;
    public override void run(Character attacker, int[] targets)
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i] != -1)
            {
                Character target = (Character)BattleManager.instance.list.get(targets[i]);
                if (target != null)
                {
                    if (flatDamage)
                        BattleManager.instance.AddAttack(new AttackData(baseDamage, target, BattleManager.instance.hit(accuracy)));
                    else
                        BattleManager.instance.AddAttack(new AttackData(baseDamage, attacker, target, phisical, BattleManager.instance.hit(accuracy)));
                }
            }
        }
    }
    public bool hit()
    {
        return GameManager.instance.random.NextDouble() <= accuracy / 100.0;
    }
}
