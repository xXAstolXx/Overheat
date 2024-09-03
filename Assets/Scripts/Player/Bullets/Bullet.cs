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
            AddDamageEffectTypeToDataDict();
            StartTravel();
        }

        private void AddDamageEffectTypeToDataDict()
        {
            damageEffectTypeToData.Add(DamageEffectType.Damage, damageEffectTypeData);
            damageEffectTypeToData.Add(DamageEffectType.Explosion, damageEffectTypeData);
            damageEffectTypeToData.Add(DamageEffectType.Freezing, damageEffectTypeData);
            damageEffectTypeToData.Add(DamageEffectType.Healing, damageEffectTypeData);
        }

        internal void StartTravel()
		{
			rb.velocity = transform.up * data.TravelSpeed;
		}
	}
}

