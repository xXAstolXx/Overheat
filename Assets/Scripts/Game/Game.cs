using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    #region Singleton
    private static Game instance;

    public static Game Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion

    [SerializeField]
    private int scoreModifer;
    [SerializeField]
    private int scoreDecreaseAmount;
    private int scoreValue;
    public int ScoreValue { get => scoreValue; }

    public List<Building> buildings = new List<Building>();

    private void Awake()
    {
        instance = this;
        SetTimescale(1.0f);
        scoreValue = 0;
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

    private void CalculateScore() // extract that into a class e.g. ScoreManager
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
        UI.Instance.GameOverMenu.ShowScreen();
        SetTimescale(0f);
    }

    public void GameWon()
    {
        CalculateScore();
        UI.Instance.WinMenu.ShowScreen();
        SaveScore();
        UI.Instance.EarningTxt.SetText(scoreValue.ToString());
        SetTimescale(0f);
    }

    private void SetTimescale(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    // extract Load and Save Score into a class e.g. SaveManager
    private void LoadGameScore()
    {
        if (SaveSystem.LoadGameData() != null)
        {
            var loadedScore = SaveSystem.LoadGameData().playerScore;
            Debug.Log("UI:  " +  UI.Instance);
            UI.Instance.EarningTxt.SetText(loadedScore.ToString());
        }
    }

    //remodel the Save Func in the Game

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
