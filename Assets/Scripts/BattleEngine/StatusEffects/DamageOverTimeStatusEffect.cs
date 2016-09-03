using UnityEngine;
using System.Collections;
using System;

public class DamageOverTimeStatusEffect : StatusEffect
{
    private int characterID;
    public DamageOverTimeStatusEffect(Character attacker)
    {
        name = "DamageOverTime";
        id = StatusEffectList.DamageOverTime;
        effects = new BattleEffect[1];
        turnCount = 5;
        characterID = attacker.ID;
        DamageOverTimeBattleEffect temp = new DamageOverTimeBattleEffect();
        temp.accuracy = 100;
        temp.baseDamage = 10;
        temp.phisical = true;
        temp.snapshotLevel = attacker.Level;
        temp.snapshotAttack = attacker.BattleStats.Attack;
        effects[0] = temp;
    }
    public override bool reapply(StatusEffect effect)
    {
        DamageOverTimeStatusEffect temp = (DamageOverTimeStatusEffect)effect;
        if (temp.characterID == characterID)
        {
            turnCount = effect.TurnCount;
            return true;
        }
        return false;
    }
    public int CharacterID
    {
        get { return CharacterID; }
    }
}
