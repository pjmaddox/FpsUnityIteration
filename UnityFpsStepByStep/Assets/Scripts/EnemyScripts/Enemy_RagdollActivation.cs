using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Enemy_RagdollActivation : MonoBehaviour 
	{
        private Enemy_Master enemyMaster;
        private Collider myCollider;
        private Rigidbody myRigidbody;
		
		void OnEnable()
		{
			SetInitialReferences();
            enemyMaster.EventEnemyDie += ActivateRagdoll;
		}

		void OnDisable()
		{
            enemyMaster.EventEnemyDie -= ActivateRagdoll;
        }

		void SetInitialReferences()
		{
            transform.root.GetComponent<Enemy_Master>();

            if (GetComponent<Collider>())
                myCollider = GetComponent<Collider>();

            if (GetComponent<Rigidbody>())
                myRigidbody = GetComponent<Rigidbody>();

        }

        void ActivateRagdoll()
        {
            if (myRigidbody)
            {
                myRigidbody.isKinematic = false;
                myRigidbody.useGravity = true;
            }

            if (myCollider)
            {
                myCollider.isTrigger = false;
                myCollider.enabled = true;
            }
        }
	}
}
