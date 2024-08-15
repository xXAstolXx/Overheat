using System.Collections.Generic;
using UnityEngine;

namespace Overheat.Player.InventorySystem
{
	internal class BackPack : MonoBehaviour
	{
		public List<RessourceData> ressourceDatas = new List<RessourceData>();
		[SerializeField]
		private int maxCapacity = 1;

		internal int MaxCapacity { get => maxCapacity; }

		public void DestroyItemInBackPack()
		{
			Destroy( gameObject.transform.GetChild( 0 ).gameObject );
		}
	}
}