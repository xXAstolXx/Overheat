using System.Collections.Generic;
using TMPro;
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

    [SerializeField]
    private TextMeshProUGUI earningTxt;


    private void Awake()
    {
        instance = this;
        scoreValue = 0;
        winMenu = GetComponentInChildren<WinMenu>();
        gameOverMenu = GetComponentInChildren<GameOverMenu>();
    }
    private void Start()
    {
        SaveSystem.LoadGameData();
        if(SaveSystem.LoadGameData() != null)
        {
            earningTxt.text = SaveSystem.LoadGameData().playerScore.ToString();

        }
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
        gameOverMenu.ShowScreen();
        SetTimescale(0f);
    }

    public void GameWon()
    {
        CalculateScore();
        GameData dataToSave = new GameData();
        dataToSave.playerScore = scoreValue;
        SaveSystem.SaveGameData(dataToSave);
        earningTxt.text = scoreValue.ToString();
        winMenu.ShowScreen();
        SetTimescale(0f);
    }

    private void SetTimescale(float timeScale)
    {
        Time.timeScale = timeScale;
    }
}
