namespace Overheat.Ui.UiScreen
{
	using Overheat.Game.ScoreSystem;
	using Overheat.Ui.UiScreen.Component;
	using Screen = Component.Screen;

	public class WinMenu : Screen
	{
		private Textlabel earningText;

		private void Awake()
		{
			earningText = GetComponentInChildren<Textlabel>();
		}

		public override void ShowScreen()
		{
			base.ShowScreen();
			SetEarningText( ScoreManager.Instance.Income );
		}

		private void SetEarningText( int value )
		{
			earningText.SetText( $"You got: {value}" );
		}
	}
}

