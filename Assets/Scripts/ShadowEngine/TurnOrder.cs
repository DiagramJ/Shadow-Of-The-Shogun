using System;
using System.Collections;

public class TurnOrder
{
    private ArrayList order;
    int turn;
    public TurnOrder()
    {
        order = new ArrayList();
        turn = -1;
    }
    public Character currentCharacter
    {
        get
        {
            if (turn == -1)
                return null;
            return (Character)order[turn];
        }
    }
    public void Order( ArrayList characters)
    {
        order.Clear(); 
        int length = characters.Count;
        int[] indexOrder = new int[length];
        for (int i = 0; i < length; i++)
            indexOrder[i] = i;
        for (int i = 0; i < length; i++)
        {
            int topSpeed = -1;
            int index = 0;
            for (int j = i; j < length; j++)
            {
                int speed = ((Character)characters[j]).BattleStats.Speed;
                if (speed > topSpeed)
                {
                    topSpeed = speed;
                    index = j;
                }
                if (speed == topSpeed)
                {
                    int num = GameManager.instance.random.Next(0, 2);
                    if (num == 1)
                        index = j;
                }
            }
            int hold = indexOrder[index];
            indexOrder[index] = i;
            indexOrder[i] = hold;

        }
        for (int i = 0; i < length; i++)
            order.Add(characters[indexOrder[i]]);
        turn = 0;
    }
    public void nextTurn()
    {
        turn++;
        if (turn >= order.Count)
        {
            turn = -1;
        }
    }
}
