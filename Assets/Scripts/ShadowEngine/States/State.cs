using System.Collections;

abstract class State
{
    protected int id;
    protected bool once;
    public abstract int run(ArrayList input);
    public int getID()
    {
        return id;
    }
    public void reset()
    {
        once = false;
    }
}
