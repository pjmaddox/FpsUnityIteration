using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Enemy_CollisionField : MonoBehaviour 
	{
        private Enemy_Master enemyZMaster;
        private Rigidbody strikingMe;
        private int damageToApply;
        public float massRquirement = 50;
        public float speedRequirement;
        private float damageFac = 0.1f;

		void OnEnable()
		{
			SetInitialReferences();
            enemyZMaster.EventEnemyDie += DisableThis;
		}

		void OnDisable()
		{
            enemyZMaster.EventEnemyDie -= DisableThis;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Rigidbody>())
            {
                strikingMe = other.GetComponent<Rigidbody>();

                if (strikingMe.mass > massRquirement && strikingMe.velocity.sqrMagnitude > speedRequirement * speedRequirement)
                {
                    var damageToApply = (int)(damageFac * strikingMe.mass * strikingMe.velocity.magnitude);
                    enemyZMaster.CallEventEnemyHealthDeduction(-damageToApply);
                }
            }
        }

        void DisableThis()
        {
            gameObject.SetActive(false);
        }

		void SetInitialReferences()
		{
            enemyZMaster = transform.root.GetComponent<Enemy_Master>();
		}
	}
}
