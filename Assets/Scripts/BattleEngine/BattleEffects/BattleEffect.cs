using UnityEngine;
using System.Collections;

public abstract class BattleEffect
{
    public const int NoType = -1;
    public const int BattleStart = 0;
    public const int TurnStart = 1;
    public const int AfterAttack = 2;
    public const int AfterGuard = 2;
    public const int AfterHit = 4;
    public const int AfterBattle = 5;
    public const int Persistent = 6;

    protected int type;
    public abstract void run(Character character);
    public abstract void run(AttackData attackData);
    public abstract void apply(Character character);
    public abstract void falloff(Character character);
    public bool check(int Type)
    {
        return type == Type;
    }
}
