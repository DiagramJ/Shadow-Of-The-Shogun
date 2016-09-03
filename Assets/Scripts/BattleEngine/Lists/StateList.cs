using System;
using System.Collections;

public class StateList
{
    public const int StartBattle = 0;
    public const int EndBattle = 1;
    public const int StartTurn = 2;
    public const int EndTurn = 3;
    public const int ComputerTurn = 4;
    public const int PlayerTurn = 5;
    public const int TurnOrder = 6;
    public const int Attack = 7;
    public const int PostAttack = 8;
    public const int DeathCheck = 9;
    public const int RunBattleEffects = 10;
    public const int Guard = 11;
    public const int PlayerTrait = 12;
    public const int PostPlayerTrait = 13;
    public const int NotEnoughMP = 14;
    public const int NotOffCooldown = 15;
    ArrayList states;
    public StateList()
    {
        states = new ArrayList();
        states.Add(new StartBattleState(0));
        states.Add(new EndBattleState(1));
        states.Add(new StartTurnState(2));
        states.Add(new EndTurnState(3));
        states.Add(new ComputerTurnState(4));
        states.Add(new PlayerTurnState(5));
        states.Add(new TurnOrderState(6));
        states.Add(new AttackState(7));
        states.Add(new PostAttackState(8));
        states.Add(new DeathCheckState(9));
        states.Add(new RunBattleEffectsState(10));
        states.Add(new GuardState(11));
        states.Add(new PlayerTraitState(12));
        states.Add(new PostPlayerTraitState(13));
        states.Add(new NotEnoughMPState(14));
        states.Add(new NotOffCooldownState(15));
    }
    public State getState(int index)
    {
        if (index >= states.Count || index < 0)
            return null;
        return (State)states[index];
    }
    public int changeRunBattleEffectsType(int type, bool attackData, int returnState)
    {
        ((RunBattleEffectsState)states[RunBattleEffects]).type = type;
        ((RunBattleEffectsState)states[RunBattleEffects]).attackData = attackData;
        ((RunBattleEffectsState)states[RunBattleEffects]).returnState = returnState;
        return RunBattleEffects;
    }
}
