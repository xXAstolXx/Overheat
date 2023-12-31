using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    private static Game instance;

    public List<bool> overheatedBuildings = new List<bool>();
    private Game()
    {
    }

    public static Game Instance
    {

        get
        {
            if (instance == null)
            {
                instance = new Game();
            }
            return instance;
        }
    }

    public void GameOver()
    {
        if(overheatedBuildings.Count <= 0)
        {
            Debug.LogWarning("GameOver all Buildings Overheated");
        }
    }
}
