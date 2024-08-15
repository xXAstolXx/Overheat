using System.IO;
using UnityEngine;

namespace Overheat.Generel.SaveSystem
{
	internal class JSONSaveSystem : MonoBehaviour
	{
		internal static void SaveGameData( GameData gameData )
		{
			string jsonData = JsonUtility.ToJson( gameData );
			string filePath = Application.persistentDataPath + "/savedata.json";
			File.WriteAllText( filePath, jsonData );
		}

		internal static GameData LoadGameData()
		{
			string filePath = Application.persistentDataPath + "/savedata.json";
			if( File.Exists( filePath ) )
			{
				string jsonData = File.ReadAllText( filePath );
				GameData gameData = JsonUtility.FromJson<GameData>( jsonData );
				return gameData;
			}
			else
			{
				Debug.LogWarning( "Save file not found in " + filePath );
				return null;
			}
		}
	}
}