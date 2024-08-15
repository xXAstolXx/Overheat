using UnityEngine;

namespace Overheat.Weapon.DamageEffectType.Data
{
	[CreateAssetMenu( fileName = nameof( DamageEffectTypeData ), menuName = "Overheat/" + nameof( DamageEffectTypeData ), order = 1 )]
	internal class DamageEffectTypeData : ScriptableObject
	{
		[SerializeField]
		private float damageValue;

		[SerializeField]
		private float explosionDamage;
		[SerializeField]
		private float explosionRange;

		[SerializeField]
		private float freezingDuration;

		[SerializeField]
		private float healingAmount;

		internal float DamageValue { get => damageValue; }
		internal float ExplosionDamage { get => explosionDamage; }
		internal float ExplosionRange { get => explosionRange; }
		internal float FreezingDuration { get => freezingDuration; }
		internal float HealingAmount { get => healingAmount; }

	}
}