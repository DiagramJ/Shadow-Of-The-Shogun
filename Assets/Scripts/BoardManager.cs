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
        turnOrder = BattleManager.instance.turnOrder;
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
        bool enemyTurn = true;
        Character character = turnOrder.currentCharacter;
        if (character != null)
            enemyTurn = character.Enemy;
        for (int i = 0; i < buttons.Length; i++)
            buttons[i].enable(!enemyTurn);
    }
    public void hideSkills()
    {
        for (int i = 0; i < buttons.Length; i++)
            buttons[i].enable(false);
    }
    public void showSkills()
    {
        for (int i = 0; i < buttons.Length; i++)
            buttons[i].enable(true);
    }
    public void hidePopUp()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].DisablePopup();
        }
    }
    public void showPopUp()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].EnablePopup();
        }
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
