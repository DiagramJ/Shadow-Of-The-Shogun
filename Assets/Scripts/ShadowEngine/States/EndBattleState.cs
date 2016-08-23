using System.Collections;

class EndBattleState : State
{
    public EndBattleState(int ID)
    {
        once = false;
        id = ID;
    }
    public override int run(ArrayList input)
    {
        if(!once)
        {
            GameManager.instance.printString("Battle Ended");
            BattleManager.instance.highlightManager.setTargetSelector(null,null);
            once = true;
        }
        return 1;
    }
}
