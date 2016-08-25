using UnityEngine;
using System.Collections;

public class BasicHealAction : Action
{
    public int baseDamage;
    public int accuracy;
    public bool phisical;
    public override void run(Character attacker, int[] targets)
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i] != -1)
            {
                Character target = (Character)BattleManager.instance.list.get(targets[i]);
                if(target != null)
                {
                    AttackData temp = new AttackData(baseDamage, attacker, target, phisical, accuracy);
                    temp.heal = true;
                    BattleManager.instance.AddAttack(temp);
                }

            }
        }
    }
}
