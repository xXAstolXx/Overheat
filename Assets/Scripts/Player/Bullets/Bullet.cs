namespace Overheat.Weapon.Bullet
{
	using Overheat.Weapon.Bullet.Data;
	using Overheat.Weapon.DamageEffectType.Data;
	using System.Collections.Generic;
	using UnityEngine;

	internal class Bullet : MonoBehaviour
	{
		[SerializeField]
		private Rigidbody2D rb;

		[SerializeField]
		private BulletData data;

		[SerializeField]
		private DamageEffectTypeData damageEffectTypeData;

		private Dictionary<DamageEffectType, DamageEffectTypeData> damageEffectTypeToData = new Dictionary<DamageEffectType, DamageEffectTypeData>();

		private void Start()
		{
			damageEffectTypeToData.Add( DamageEffectType.Damage, damageEffectTypeData );
			damageEffectTypeToData.Add( DamageEffectType.Explosion, damageEffectTypeData );
			damageEffectTypeToData.Add( DamageEffectType.Freezing, damageEffectTypeData );
			damageEffectTypeToData.Add( DamageEffectType.Healing, damageEffectTypeData );
		}
		private void Update()
		{
			Debug.Log( "Bullet velocity: " + rb.velocity );
		}
		internal void StartTravel( Vector2 moveDirection )
		{
			rb.AddForceAtPosition( Vector2.up, gameObject.transform.position );
		}
	}
}

