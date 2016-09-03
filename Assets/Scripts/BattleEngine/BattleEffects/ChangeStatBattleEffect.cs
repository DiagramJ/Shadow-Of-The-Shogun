using UnityEngine;
using System.Collections;
using System;

public class ChangeStatBattleEffect : BattleEffect
{
    public float [] percentChange;
    public int [] flatChange;
    private int [] amount;
    public ChangeStatBattleEffect()
    {
        type = Persistent;
        percentChange = new float[6];
        flatChange = new int[6];
        amount = new int[6];
    }
    public override void run(Character character)
    {
    }
    public override void run(AttackData attackData)
    {
    }
    public override void apply(Character character)
    {
        amount[0] = (int)(character.CoreStats.HP * percentChange[0]) + flatChange[0];
        amount[1] = (int)(character.CoreStats.Attack * percentChange[1]) + flatChange[1];
        amount[2] = (int)(character.CoreStats.Defence * percentChange[2]) + flatChange[2];
        amount[3] = (int)(character.CoreStats.MagicAttack * percentChange[3]) + flatChange[3];
        amount[4] = (int)(character.CoreStats.MagicDefence * percentChange[4]) + flatChange[4];
        amount[5] = (int)(character.CoreStats.Speed * percentChange[5]) + flatChange[5];

        character.BattleStats.addHp(amount[0]);
        character.BattleStats.addAttack(amount[1]);
        character.BattleStats.addDefence(amount[2]);
        character.BattleStats.addMagicAttack(amount[3]);
        character.BattleStats.addMagicDefence(amount[4]);
        character.BattleStats.addSpeed(amount[5]);
    }
    public override void falloff(Character character)
    {
        character.BattleStats.addHp(-amount[0]);
        character.BattleStats.addAttack(-amount[1]);
        character.BattleStats.addDefence(-amount[2]);
        character.BattleStats.addMagicAttack(-amount[3]);
        character.BattleStats.addMagicDefence(-amount[4]);
        character.BattleStats.addSpeed(-amount[5]);
    }
    public void setHP(float percent, int flat)
    {
        percentChange[0] = percent;
        flatChange[0] = flat;
    }
    public void setAttack(float percent, int flat)
    {
        percentChange[1] = percent;
        flatChange[1] = flat;
    }
    public void setDefence(float percent, int flat)
    {
        percentChange[2] = percent;
        flatChange[2] = flat;
    }
    public void setMagicAttack(float percent, int flat)
    {
        percentChange[3] = percent;
        flatChange[3] = flat;
    }
    public void setMagicDefence(float percent, int flat)
    {
        percentChange[4] = percent;
        flatChange[4] = flat;
    }
    public void setSpeed(float percent, int flat)
    {
        percentChange[5] = percent;
        flatChange[5] = flat;
    }
}
