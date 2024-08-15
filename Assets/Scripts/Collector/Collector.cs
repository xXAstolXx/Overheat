using Overheat.Interaction.Interactable;
using UnityEngine;

namespace Overheat.Player.InteractionSystem.Collect
{
	internal abstract class Collector : MonoBehaviour
	{
		internal virtual void TryCollect( RessourceInteracable ressourceInteracable, RessourceData data )
		{ }
		protected abstract void Collect( GameObject target, RessourceData data );
		public virtual void TryInteract( ResourceType resourceType )
		{ }

	}
}


