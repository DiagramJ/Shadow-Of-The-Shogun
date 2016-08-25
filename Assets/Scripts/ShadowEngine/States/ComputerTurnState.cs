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
            int number = GameManager.instance.random.Next(-25, 26);
            BattleManager.instance.turnOrder.currentCharacter.addLoyalty(number);
            BattleManager.instance.boardManager.updateHealthBars();
            once = true;
        }
        if (BattleManager.instance.infoStrip.isActive())
            return id;
        return StateList.EndTurn;
    }
}
