using UnityEngine;
using System.Collections;
using System;

public class DamageOverTimeBattleEffect : BattleEffect
{
    public int baseDamage;
    public int accuracy;
    public bool phisical;
    public int snapshotLevel;
    public int snapshotAttack;
    public DamageOverTimeBattleEffect()
    {
        type = TurnStart;
    }
    public override void run(Character character)
    {
        BattleManager.instance.AddAttack(new AttackData(baseDamage, snapshotAttack, snapshotLevel, character, phisical, BattleManager.instance.hit(accuracy)));
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
