using UnityEngine;
using UnityEngine.UI;

namespace Overheat.Ui.WorldUi.OverheatUi
{
	internal class OverheatImage : MonoBehaviour
	{
		private Image image;

		internal float OverHeatAmount { get { return image.fillAmount; } }

		private void Start()
		{
			image = GetComponent<Image>();
		}

		internal void IncreaseOverheating( float amount )
		{
			image.fillAmount += amount;
		}

		internal void DecreaseOverheating( float amount )
		{
			if( amount == 0 )
			{
				return;
			}
			image.fillAmount -= amount;
		}
	}
}