using System.Collections;

class StateMachine
{
    private StateTable table;
    private State currentState;
    private int currentStateID;
    public StateMachine()
    {
        table = new StateTable();
        currentState = table.getState(0);
        currentStateID = currentState.getID();
    }
    public void run(ArrayList input)
    {
        int transition = currentState.run(input);
        if(transition != currentStateID)
        {
            currentState.reset();
            currentState = table.getState(transition);
            currentStateID = currentState.getID();
        }
    }
    public bool done()
    {
        return currentState == null;
    }

}
