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
        skillSelected = 0;
        overexert = false;
        targetable = new bool[targets.Length];
        target = -1;
        targetShape = null;
    }
    public void runSkillSelect()
    {
        for (int i = 1; i < 7; i++)
        {
            if (buttons[i].Input != 0)
            {
                clearSkillSelectHighligh();
                if (skillSelected == i)
                {
                    skillSelected = 0;
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
        for (int i = 1; i < 7; i++)
        {
            buttons[i].highlightOff();
        }
    }
    public void runOverexertSelect()
    {

        if (buttons[0].Input != 0)
        {
            buttons[0].inputOff();
            if (overexert)
            {
                overexert = false;
                buttons[0].highlightOff();
            }
            else
            {
                overexert = true;
                buttons[0].highlightOn(new Color(1, 0, 0));
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
        int position = BattleManager.instance.order.currentCharacter.position;
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

    public void setTargetShape(int[][] shape, int[] indexes)
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
    public ArrayList getInputs()
    {
        ArrayList returnArray = new ArrayList();
        returnArray.Add(confirmTarget);
        returnArray.Add(target);
        returnArray.Add(targetShape);
        returnArray.Add(skillSelected);
        returnArray.Add(overexert);
        return returnArray;
    }
}
