using UnityEngine;
using System.Collections;

public class HighlightManager
{
    public Box[] buttons;
    public Box[] targets;

    bool[] targetable;
    int[][] targetShape;
    int skillSelected;
    int target;
    bool confirmTarget;
    bool overexert;

    public HighlightManager(Box[] Buttons, Box[] Targets)
    {
        buttons = Buttons;
        targets = Targets;
        skillSelected = -1;
        overexert = false;
        targetable = new bool[targets.Length];
        target = -1;
        targetShape = null;
    }
    public void runSkillSelect()
    {
        for (int i = 0; i < 6; i++)
        {
            if (buttons[i].Input != 0)
            {
                clearSkillSelectHighligh();
                if (skillSelected == i)
                {
                    skillSelected = -1;
                }
                else
                {
                    buttons[i].highlightOn(new Color(1, 1, 0));
                    skillSelected = i;
                }
                buttons[i].inputOff();
                break;
            }
        }
    }
    public void clearSkillSelectHighligh()
    {
        for (int i = 0; i < 6; i++)
        {
            buttons[i].highlightOff();
        }
    }
    public void runOverexertSelect()
    {

        if (buttons[6].Input != 0)
        {
            buttons[6].inputOff();
            if (overexert)
            {
                overexert = false;
                buttons[6].highlightOff();
            }
            else
            {
                overexert = true;
                buttons[6].highlightOn(new Color(1, 0, 0));
            }
        }
    }
    public void runHighlightTarget()
    {
        bool found = false;
        confirmTarget = false;
        for (int i = 0; i < targets.Length; i++)
        {
            if (targetable[i] && targets[i].MouseOver)
            {
                found = true;
                if (target != i)
                {
                    clearTargetsHighlight();
                    if (targetShape == null)
                    {
                        targets[i].highlightOn(new Color(1, 0, 0));
                    }
                    else
                    {
                        for (int j = 0; j < targetShape[i].Length; j++)
                        {
                            targets[targetShape[i][j]].highlightOn(new Color(1, 0, 0));
                        }
                    }
                    target = i;
                }
                if (targets[i].Input != 0)
                {
                    confirmTarget = true;
                    targets[i].inputOff();
                }
                break;
            }
        }
        if (!found && target != -1)
        {
            clearTargetsHighlight();
            target = -1;
        }
    }

    public void clearTargetsHighlight()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].highlightOff();
        }
        highlightTurnCharacter();
    }
    public void highlightTurnCharacter()
    {
        Character currentCharacter = BattleManager.instance.turnOrder.currentCharacter;
        if (currentCharacter == null)
            return;
        int position = currentCharacter.position;
        if(!targets[position].isHighlighted())
            targets[position].highlightOn(new Color(0, 1, 0));
    }
    public void setTargetSelector(int[] indexes, int[][] shape)
    {
        for (int i = 0; i < targetable.Length; i++)
        {
            targetable[i] = false;
        }
        if (indexes != null)
        {
            for (int i = 0; i < indexes.Length; i++)
            {
                targetable[indexes[i]] = true;
            }
        }
        setTargetShape(shape, indexes);
    }

    private void setTargetShape(int[][] shape, int[] indexes)
    {
        if (shape == null)
        {
            targetShape = null;
            return;
        }
        targetShape = new int[targets.Length][];
        for (int i = 0; i < indexes.Length; i++)
        {
            targetShape[indexes[i]] = shape[i];
        }
    }
    public void clearSkillSelected()
    {
        overexert = false;
        skillSelected = -1;
        clearSkillSelectHighligh();
        buttons[6].highlightOff();
    }
    public ArrayList getInputs()
    {
        ArrayList returnArray = new ArrayList();

        returnArray.Add(confirmTarget); // 0
        returnArray.Add(target);        // 1
        returnArray.Add(getTargets());// 2
        returnArray.Add(skillSelected); // 3
        returnArray.Add(overexert);     // 4
        return returnArray;
    }

    private int [] getTargets()
    {
        if (target != -1)               
        {
            if (targetShape == null)
                return new int[] { target };
            else
                return targetShape[target];
        }
        else
            return null;

    }
}
