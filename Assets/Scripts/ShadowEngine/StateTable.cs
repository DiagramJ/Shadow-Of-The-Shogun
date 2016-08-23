using System;
using System.Collections;

class StateTable
{
    public const int StartBattle = 0;
    public const int EndBattle = 1;
    public const int StartTurn = 2;
    public const int EndTurn = 3;
    public const int ComputerTurn = 4;
    public const int PlayerTurn = 5;
    public const int TurnOrder = 6;
    public const int RunBattleEffects = 7;
    public const int Attack = 8;
    public const int PostAttack = 9;
    ArrayList states;
    public StateTable()
    {
        states = new ArrayList();
        states.Add(new StartBattleState(0));
        states.Add(new EndBattleState(1));
        states.Add(new StartTurnState(2));
        states.Add(new EndTurnState(3));
        states.Add(new ComputerTurnState(4));
        states.Add(new PlayerTurnState(5));
        states.Add(new TurnOrderState(6));
        states.Add(new RunBattleEffectsState(7));
        states.Add(new AttackState(8));
        states.Add(new PostAttackState(9));
    }
    public State getState(int index)
    {
        if (index >= states.Count || index < 0)
            return null;
        return (State)states[index];
    }
}
