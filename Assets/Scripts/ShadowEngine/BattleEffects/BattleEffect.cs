using System.Collections;

public abstract class BattleEffect
{
    public const int NoType = -1;
    public const int BattleStart = 0;
    public const int TurnStart = 1;
    public const int TurnEnd = 2;
    public const int AfterAttack = 3;
    public const int AfterGuard = 4;
    public const int AfterHit = 5;
    public const int AfterTurn = 6;
    public const int AfterBattle = 7;

    private int type;
    public abstract void run(Character character);
    public abstract void run(AttackData AttackData);
          
}

