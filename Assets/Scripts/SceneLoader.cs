namespace Overheat.Generel.Utitlity.SceneLoader
{
	using UnityEngine;
	using UnityEngine.SceneManagement;

	internal class SceneLoader : MonoBehaviour
	{
		public void LoadSceneByIndex( int index )
		{
			SceneManager.LoadScene( index );
		}
	}
}