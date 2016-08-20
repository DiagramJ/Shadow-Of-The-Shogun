using UnityEngine;
using System.Collections;

public class BoardManager
{
    Box [] buttons;
    Box [] characters;
    HealthBar[] healthBars;
    CharacterList bord;
    TurnOrder turnOrder;
    public BoardManager(Box[] Buttons, Box[] Characters, HealthBar[] HealthBars)
    {
        buttons = Buttons;
        characters = Characters;
        healthBars = HealthBars;
        bord = BattleManager.instance.list;
        turnOrder = BattleManager.instance.order;
    }
    
    public void displayBord()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            Character character = bord.get(i);
            characters[i].enable(character != null);
            healthBars[i].enable(character != null);
        }
    }
    public void displaySkills()
    {
        Character character = turnOrder.currentCharacter;
        for (int i = 0; i < buttons.Length; i++)
            buttons[i].enable(!character.Enemy);
    }
    public void updateHealthBars()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            Character character = bord.get(i);
            if (character != null)
            {
                healthBars[i].setStopNumber(character.BattleStats.HP, character.CoreStats.getHP);
            }
        }
    }
    public void setHealthBars()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            Character character = bord.get(i);
            if (character != null)
            {
                healthBars[i].setNumber(character.BattleStats.HP, character.CoreStats.getHP);
            }
        }
    }
    public void placeSprites()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            Character character = bord.get(i);
            if (character != null)
            {
                int index = BattleManager.instance.characterSprite.getIndex(character.Job.Sprite);
                Sprite image = BattleManager.instance.characterSprite.get(index);
                Sprite highlight = BattleManager.instance.highlightSprite.get(index);
                characters[i].setSprite(image, highlight);
            }
        }
    }
}
