using System.IO;
using UnityEngine;

public class JSONSaveSystem : MonoBehaviour
{
    public static void SaveGameData(GameData gameData)
    {
        string jsonData = JsonUtility.ToJson(gameData);
        string filePath = Application.persistentDataPath + "/savedata.json";
        File.WriteAllText(filePath, jsonData);
    }

    public static GameData LoadGameData()
    {
        string filePath = Application.persistentDataPath + "/savedata.json";
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            GameData gameData = JsonUtility.FromJson<GameData>(jsonData);
            return gameData;
        }
        else
        {
            Debug.LogWarning("Save file not found in " + filePath);
            return null;
        }
    }
}
