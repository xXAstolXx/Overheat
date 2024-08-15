using UnityEngine;

namespace Overheat.Weapon.Bullet.Data
{
	[CreateAssetMenu( fileName = nameof( BulletData ), menuName = "Overheat/" + nameof( BulletData ), order = 1 )]
	internal class BulletData : ScriptableObject
	{
		[SerializeField]
		private float travelSpeed;

		[SerializeField]
		private DamageEffectType damageEffectType;

		internal float TravelSpeed { get => travelSpeed; }
		internal DamageEffectType DamageEffectType { get => damageEffectType; }
	}

	internal enum DamageEffectType
	{
		Damage = 1,
		Explosion = 2,
		Freezing = 3,
		Healing = 4,
	}
}