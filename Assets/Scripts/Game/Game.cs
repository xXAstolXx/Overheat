using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Game : MonoBehaviour
{
    private static Game instance;

    public List<Building> buildings = new List<Building>();
    private Game()
    {
    }

    public static Game Instance
    {
        get
        {
            return instance;
        }
    }

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        foreach (Building building in buildings)
        {
            Debug.Log(building.isOverheated);
            if(building.isOverheated == false)
            {
                return;
            }
        }
        GameOver();
    }


    public void GameOver()
    {
        Debug.LogWarning("GameOver all Buildings Overheated");
    }
}
