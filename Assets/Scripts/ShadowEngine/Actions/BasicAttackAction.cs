using UnityEngine;
using System.Collections;
using System;

public class BasicAttackAction : Action
{
    public int baseDamage;
    public int accuracy;
    public bool phisical;
    public override void run(Character attacker, int[] targets)
    {
        for (int i = 0; i < targets.Length; i++)
        {
            BattleManager.instance.AddAttack(new AttackData(baseDamage, 
                                                            attacker, 
                                                            (Character)BattleManager.instance.list.List[targets[0]], 
                                                            phisical, 
                                                            accuracy));
        }
    }
}
