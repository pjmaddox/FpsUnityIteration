using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Gun_HitEffects : MonoBehaviour 
	{
        private Gun_Master gunMaster;
        public ParticleSystem defaultHitEffect;
        public ParticleSystem enemyHitEffect;

		void OnEnable()
		{
			SetInitialReferences();
            gunMaster.EventShotDefault += SpawnDefaultHitEffect;
            gunMaster.EventShotEnemy += SpawnEnemyHitEffect;
		}

		void OnDisable()
		{
            gunMaster.EventShotDefault -= SpawnDefaultHitEffect;
            gunMaster.EventShotEnemy -= SpawnEnemyHitEffect;
        }

		void SetInitialReferences()
		{
            gunMaster = GetComponent<Gun_Master>();
		}

        void SpawnDefaultHitEffect(Vector3 hitPosition, Transform hitTransform)
        {
            if (defaultHitEffect)
                Instantiate(defaultHitEffect, hitPosition, Quaternion.identity);
        }

        void SpawnEnemyHitEffect(Vector3 hitPosition, Transform hitTransform)
        {
            if (enemyHitEffect)
                Instantiate(enemyHitEffect, hitPosition, Quaternion.identity);
        }
    }
}
