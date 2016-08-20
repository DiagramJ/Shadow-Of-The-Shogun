using System.Collections;

class StartBattleState : State
{
    bool once;
    public StartBattleState(int ID)
    {
        once = false;
        id = ID;
    }
    public override int run(ArrayList input)
    {
        if(!once)
        {
            GameManager.instance.printString("Battle Started");
            once = true;
        }
        if ((bool)input[0])
            return 1;
        return 0;
    }
}
