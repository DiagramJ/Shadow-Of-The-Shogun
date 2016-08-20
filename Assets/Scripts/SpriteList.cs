using UnityEngine;
using System.Collections;

public class SpriteList : MonoBehaviour
{
    public Sprite[] sprites;

	void Start () {}
    void Update () {}
    public int getIndex(string name)
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            if (sprites[i].name.Equals(name))
            {
                return i;
            }
        }
        return -1;
    }
    public Sprite get(string name)
    {
        int index = getIndex(name);
        if (index == -1)
            return null;
        return sprites[index];
    }
    public Sprite get(int index)
    {
        if (index >= sprites.Length)
            return null;
        if (index < 0)
            return null;
        return sprites[index];
    }
}
