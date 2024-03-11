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
        LoadGameScore();
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
            Debug.Log($"scoreValue: {scoreValue}");
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
        winMenu.ShowScreen();
        SaveScore();
        earningTxt.text = scoreValue.ToString();
        SetTimescale(0f);
    }

    private void SetTimescale(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    private void LoadGameScore()
    {
        if (SaveSystem.LoadGameData() != null)
        {
            var loadedScore = SaveSystem.LoadGameData().playerScore;
            earningTxt.text = loadedScore.ToString();
        }
    }

    private void SaveScore()
    {
        if (SaveSystem.LoadGameData() != null)
        {
            var loadedScore = SaveSystem.LoadGameData().playerScore;
            Debug.Log("loaded score: " + loadedScore.ToString());
            scoreValue += loadedScore;
        }
        GameData dataToSave = new GameData();
        dataToSave.playerScore = scoreValue;
        SaveSystem.SaveGameData(dataToSave);
    }
}
