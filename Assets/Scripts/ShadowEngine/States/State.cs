using System.Collections;

abstract class State
{
    protected int id;
    public abstract int run(ArrayList input);
    public int getID()
    {
        return id;
    }
}
