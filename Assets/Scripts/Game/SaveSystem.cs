using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static void SaveGameData(GameData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string filePath = Application.persistentDataPath + "/savedata.dat";
        FileStream stream = new FileStream(filePath, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Game data saved successfully.");
    }

    public static GameData LoadGameData()
    {
        string filePath = Application.persistentDataPath + "/savedata.dat";
        if(File.Exists(filePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream (filePath, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            Debug.Log($"Loaded Data from: {filePath} ");
            return data;
        }
        else
        {
            Debug.LogWarning($"Save file not found in: {filePath}");
            return null;
        }
    }
}
