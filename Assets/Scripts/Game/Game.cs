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

    [SerializeField]
    private int scoreModifer;
    [SerializeField]
    private int scoreDecreaseAmount;
    private int scoreValue;
    private WinMenu winMenu;
    private GameOverMenu gameOverMenu;

    public int ScoreValue { get => scoreValue; }


    private void Awake()
    {
        instance = this;
        scoreValue = 0;
        winMenu = GetComponentInChildren<WinMenu>();
        gameOverMenu = GetComponentInChildren<GameOverMenu>();
    }

    private void Update()
    {
        foreach (Building building in buildings)
        {
            if(building.isOverheated == false)
            {
                scoreValue++;
                return;
            }
        }
        GameOver();
    }

    private void CalculateScore()
    {
        if(scoreModifer !=0)
        {
            scoreValue *= scoreModifer;
            scoreValue /= scoreDecreaseAmount;
        }
    }


    public void GameOver()
    {
        Debug.LogWarning("GameOver all Buildings Overheated");
        gameOverMenu.ShowScreen();
        SetTimescale(0f);
    }

    public void GameWon()
    {
        Debug.LogWarning("You have won");
        CalculateScore();
        winMenu.ShowScreen();
        SetTimescale(0f);
    }

    private void SetTimescale(float timeScale)
    {
        Time.timeScale = timeScale;
    }
}
