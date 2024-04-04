using UnityEngine;

public class SaveManager : MonoBehaviour
{
    #region Singleton
    private static SaveManager instance;

    public static SaveManager Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        LoadGameScore();    
    }

    public void LoadGameScore()
    {
        if(JSONSaveSystem.LoadGameData() != null)
        {
            var loadedScore = JSONSaveSystem.LoadGameData().playerScore;
            UI.Instance.EarningTxt.SetText(loadedScore.ToString());
            Debug.Log("Loaded Savefile");
        }
    }

    public void SaveGameScore()
    {
        if(JSONSaveSystem.LoadGameData() != null)
        {
            var loadedScore = JSONSaveSystem.LoadGameData().playerScore;
            Debug.Log($"loaded score: {loadedScore}");
            ScoreManager.Instance.Income += loadedScore;
        }
        GameData dataToSave = new GameData();
        dataToSave.playerScore = ScoreManager.Instance.Income;
        JSONSaveSystem.SaveGameData(dataToSave);
    }

}
