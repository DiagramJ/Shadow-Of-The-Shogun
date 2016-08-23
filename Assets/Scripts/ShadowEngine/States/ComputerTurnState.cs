using System.Collections;
class ComputerTurnState : State
{
    public ComputerTurnState(int ID)
    {
        id = ID;
        once = false;
    }
    public override int run(ArrayList input)
    {
        if (!once)
        {
            BattleManager.instance.infoStrip.add("Computer Turn", 60);
            once = true;
        }
        if (BattleManager.instance.infoStrip.isActive())
            return id;
        return StateTable.EndTurn;
    }
}
