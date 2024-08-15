using UnityEngine;
namespace Overheat.Ui.WorldUi.OverheatUi
{
	internal class OverheatCanvas : MonoBehaviour
	{
		private OverheatImage overheatImage;

		private void Start()
		{
			overheatImage = GetComponentInChildren<OverheatImage>();
		}

		public void IncreaseOverheating( float amount )
		{
			overheatImage.IncreaseOverheating( amount );
		}

		public void DecreaseOverheating( float amount )
		{
			overheatImage.DecreaseOverheating( amount );
		}

		public float GetOverHeatAmount()
		{
			return overheatImage.OverHeatAmount;
		}
	}
}