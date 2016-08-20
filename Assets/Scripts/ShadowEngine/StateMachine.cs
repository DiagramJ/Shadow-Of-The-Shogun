using System.Collections;

class StateMachine
{
    private StateTable table;
    private State currentState;
    public StateMachine()
    {
        table = new StateTable();
        currentState = table.getState(0);
    }
    public void run(ArrayList input)
    {
        int transition = currentState.run(input);
        currentState = table.getState(transition);
    }
    public bool done()
    {
        return currentState == null;
    }

}
