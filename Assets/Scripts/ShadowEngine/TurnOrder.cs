using System;
using System.Collections;

public class TurnOrder
{
    private ArrayList order;
    int turn;
    public TurnOrder()
    {
        order = new ArrayList();
    }
    public Character currentCharacter
    {
        get { return (Character)order[turn]; }
    }
    public void Order( ArrayList characters)
    {
        order.Clear();
        int length = characters.Count;
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
            order.Add(characters[index]);
        }
    }
    public void nextTurn()
    {
        turn++;
        if (turn >= order.Count)
        {
            turn = 0;
        }
    }
}
