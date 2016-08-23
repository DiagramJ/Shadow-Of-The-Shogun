using System.Collections;

class TurnOrderState : State
{
    public TurnOrderState(int ID)
    {
        id = ID;
        once = false;
    }

    public override int run(ArrayList input)
    {
        if (!once)
        {
            BattleManager.instance.Order();
            once = true;
        }
        return StateTable.StartTurn;
    }
}
