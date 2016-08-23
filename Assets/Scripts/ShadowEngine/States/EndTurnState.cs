using System.Collections;

class EndTurnState : State
{
    public EndTurnState(int ID)
    {
        id = ID;
        once = false;
    }
    public override int run(ArrayList input)
    {
        if (!once)
        {
            BattleManager.instance.turnOrder.nextTurn();
            BattleManager.instance.highlightManager.clearTargetsHighlight();
            once = true;
        }
        if (BattleManager.instance.infoStrip.isActive())
            return id;
        if (BattleManager.instance.turnOrder.currentCharacter == null)
            return StateTable.TurnOrder;
        return StateTable.StartTurn;
    }
}