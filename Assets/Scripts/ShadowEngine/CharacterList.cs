using System.Collections;

public class CharacterList
{
    ArrayList characters;
    int[] playerParty;
    int[] enemyParty;

    public CharacterList()
    {
        characters = new ArrayList();
        playerParty = new int[9];
        enemyParty = new int[9];
        for (int i = 0; i < 9; i++)
        {
            playerParty[i] = -1;
            enemyParty[i] = -1;
        }
    }

    public void addPlayerParty(int position, Character character)
    {
        int index = characters.Count;
        characters.Add(character);
        playerParty[position] = index;
        character.position = position;
    }

    public void addEnemyParty(int position, Character character)
    {
        int index = characters.Count;
        characters.Add(character);
        enemyParty[position] = index;
        character.isAnEnemy();
        character.position = position + 9;
    }

    public void remove(int index)
    {
        characters.RemoveAt(index);
        for (int i = 0; i < 9; i++)
        {
            if (playerParty[i] == index)
                playerParty[i] = -1;
            else if (playerParty[i] > index)
                playerParty[i]--;
            if (enemyParty[i] == index)
                enemyParty[i] = -1;
            else if (enemyParty[i] > index)
                enemyParty[i]--;
        }
    }

    public Character getPlayerParty(int index)
    {
        if (index >= playerParty.Length)
            return null;
        if (playerParty[index] == -1)
            return null;
        return (Character)characters[playerParty[index]];
    }
    public Character getEnemyParty(int index)
    {
        if (index >= enemyParty.Length)
            return null;
        if (enemyParty[index] == -1)
            return null;
        return (Character)characters[enemyParty[index]];
    }
    public Character get(int index)
    {
        if (index < playerParty.Length)
            return getPlayerParty(index);
        index -= 9;
        if (index < enemyParty.Length)
            return getEnemyParty(index);
        return null;
    }
    public ArrayList List
    {
        get { return characters; }
    }
}
