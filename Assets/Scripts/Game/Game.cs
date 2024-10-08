namespace Overheat.Singletons.Game
{
	using Overheat.Buildings.Base;
	using Overheat.Game.ScoreSystem;
	using Overheat.Generel.SaveSystem.API;
	using Overheat.Singletons.Ui;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Events;

	internal class Game : MonoBehaviour
	{
		#region Singleton
		private static Game instance;

		internal static Game Instance
		{
			get
			{
				return instance;
			}
		}
		#endregion

		internal List<Building> buildings = new List<Building>();

		internal UnityEvent OnGameWon { get; private set; } = new UnityEvent();

		private void Awake()
		{
			instance = this;
			SetTimescale( 1.0f );
		}

		private void Update()
		{
			foreach( Building building in buildings )
			{
				if( building.isOverheated == false )
				{
					ScoreManager.Instance.IncreaseIncomeModifer();
					return;
				}
			}
			GameOver();
		}

		public void GameOver()
		{
			UI.Instance.GameOverMenu.ShowScreen();
			SetTimescale( 0f );
		}

		public void GameWon()
		{
			OnGameWon.Invoke();
			UI.Instance.WinMenu.ShowScreen();
			SaveManager.Instance.SaveGameScore();
			UI.Instance.EarningTxt.SetText( ScoreManager.Instance.Income.ToString() );
			SetTimescale( 0f );
		}

		private void SetTimescale( float timeScale )
		{
			Time.timeScale = timeScale;
		}
	}
}
