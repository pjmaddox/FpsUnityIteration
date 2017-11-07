using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Gun_ApplyDamage : MonoBehaviour 
	{
        private Gun_Master gunMaster;
        public int damageToInflict = 40;

		void OnEnable()
		{
			SetInitialReferences();
            gunMaster.EventShotEnemy += ApplyDamage;
		}

		void OnDisable()
		{
            gunMaster.EventShotEnemy -= ApplyDamage;
        }

		void SetInitialReferences()
		{
            gunMaster = GetComponent<Gun_Master>();
		}

        void ApplyDamage(Vector3 dummyHitPosition, Transform targetTransform)
        {
            var damageScript = targetTransform.GetComponent<Enemy_TakeDamage>();
            if (damageScript)
                damageScript.ProcessDamge(damageToInflict);
        }
	}
}
