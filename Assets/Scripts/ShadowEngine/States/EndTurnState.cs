using System.Collections;

class EndTurnState : State
{
    public EndTurnState(int ID)
    {
        id = ID;
    }
    public override int run(ArrayList input)
    {
        return 0;
    }
}