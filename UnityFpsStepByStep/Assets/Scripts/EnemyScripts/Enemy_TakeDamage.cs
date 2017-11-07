using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Enemy_TakeDamage : MonoBehaviour 
	{
        private Enemy_Master enemyMaster;
        public int damageMultiplier = 1;
        public bool shouldRemoveColllider;

		void OnEnable()
		{
			SetInitialReferences();
            enemyMaster.EventEnemyDie += RemoveThis;
        }

		void OnDisable()
		{
            enemyMaster.EventEnemyDie -= RemoveThis;
        }

		void SetInitialReferences()
		{
            enemyMaster = transform.root.GetComponent<Enemy_Master>();
		}

        public void ProcessDamge(int baseDamage)
        {
            var damageToApply = baseDamage * damageMultiplier;
            enemyMaster.CallEventEnemyHealthDeduction(-damageToApply);
        }

        void RemoveThis()
        {
            if (shouldRemoveColllider)
            {
                if (GetComponent<Collider>())
                {
                    Destroy(GetComponent<Collider>());
                }

                if (GetComponent<Rigidbody>())
                {
                    Destroy(GetComponent<Rigidbody>());
                }
            }

            Destroy(this);
        }
	}
}
