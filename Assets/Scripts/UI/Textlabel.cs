namespace Overheat.Ui.UiScreen.Component
{
	using TMPro;
	using UnityEngine;

	public class Textlabel : MonoBehaviour
	{
		private TextMeshProUGUI text;

		private void Awake()
		{
			text = GetComponent<TextMeshProUGUI>();
		}

		public void SetText( string textToSet )
		{
			text.text = textToSet;
		}
	}
}

