namespace Overheat.Weapon.Bullet
{
	using Overheat.Weapon.Bullet.Data;
	using Overheat.Weapon.DamageEffectType.Data;
	using System.Collections.Generic;
	using UnityEngine;

	internal class Bullet : MonoBehaviour
	{
		[SerializeField]
		private Bullet[] bulletsPrefab = new Bullet[3];

		[SerializeField]
		private Rigidbody2D rb;

		[SerializeField]
		private BulletData data;

		[SerializeField]
		private DamageEffectTypeData damageEffectTypeData;

		private Dictionary<ResourceType, int> bulletType = new Dictionary<ResourceType, int>()
		{
			{ResourceType.TRIANGLE, 0 },
			{ResourceType.SQUARE, 1 },
			{ResourceType.DIAMOND, 2 },
		};

		private Dictionary<DamageEffectType, DamageEffectTypeData> damageEffectTypeToData = new Dictionary<DamageEffectType, DamageEffectTypeData>();

		private void Start()
		{
			damageEffectTypeToData.Add( DamageEffectType.Damage, damageEffectTypeData );
			damageEffectTypeToData.Add( DamageEffectType.Explosion, damageEffectTypeData );
			damageEffectTypeToData.Add( DamageEffectType.Freezing, damageEffectTypeData );
			damageEffectTypeToData.Add( DamageEffectType.Healing, damageEffectTypeData );

			StartTravel();
		}

		internal void StartTravel()
		{
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
			mousePosition.z = 0;

			Vector2 shootdirection = ( mousePosition - transform.position ).normalized;

			float angle = Mathf.Atan2( shootdirection.y, shootdirection.x ) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler( new Vector3( 0, 0, angle ) );

			rb.velocity = shootdirection * data.TravelSpeed;
		}
	}
}

