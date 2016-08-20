using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public System.Random random = new System.Random();

    public static GameManager instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            random = new System.Random();
        }
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }

    public void printString(string text)
    {
        print(text);
    }
}
