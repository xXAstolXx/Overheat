using Overheat.Player.InteractionSystem.Collect;
using UnityEngine;

namespace Overheat.Interaction.Interactable
{
	internal class RessourceInteracable : MonoBehaviour
	{
		[SerializeField]
		private RessourceData data;
		private CircleCollider2D interactableCollider;

		private void Awake()
		{
			interactableCollider = GetComponent<CircleCollider2D>();
		}

		private void OnTriggerEnter2D( Collider2D other )
		{
			var collector = other.gameObject.GetComponent<Collector>();
			if( collector != null )
			{
				collector.TryCollect( this, data );
			}
			return;
		}
	}
}

