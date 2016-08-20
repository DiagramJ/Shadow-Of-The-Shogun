using System;
using System.Collections;

class StateTable
{
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
    }
    public State getState(int index)
    {
        if (index >= states.Count || index < 0)
            return null;
        return (State)states[index];
    }
}
