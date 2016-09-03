using UnityEngine;
using System.Collections;

public abstract class Action
{
    public abstract void run(Character attacker,int[] targets);
}
