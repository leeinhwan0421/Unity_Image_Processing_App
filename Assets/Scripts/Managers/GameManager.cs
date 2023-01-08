using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = new GameManager();

            return instance;
        }
    }

    public GameManager()
    {
        canvas = GameObject.FindWithTag("Canvas");
    }

    public GameObject canvas;
}
