using System.Collections;

class StartTurnState : State
{
    public StartTurnState(int ID)
    {
        id = ID;
        once = false;
    }
    public override int run(ArrayList input)
    {
        if(!once)
        {
            BattleManager.instance.boardManager.showPopUp();
            once = true;
        }
        if (BattleManager.instance.turnOrder.currentCharacter.Enemy)
            return StateTable.ComputerTurn;
        return StateTable.PlayerTurn;
    }
}

