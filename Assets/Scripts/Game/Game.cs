using System.Collections.Generic;
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

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        foreach (Building building in buildings)
        {
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

    public void GameWon()
    {
        Debug.LogWarning("You have won");
    }
}
