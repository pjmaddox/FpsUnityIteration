using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace s3
{
	public class Enemy_Detection : MonoBehaviour 
	{
        private Enemy_Master enemyMaster;
        private Transform myTransform;
        public LayerMask sightLayer;
        public Transform headTransform;
        public LayerMask playerLayer;
        private float checkRate;
        private float nextCheck;
        public float detectRadius = 80f;

        private RaycastHit hit;

		void OnEnable()
		{
			SetInitialReferences();
            enemyMaster.EventEnemyDie += DisableThis;
		}

		void OnDisable()
		{
            enemyMaster.EventEnemyDie -= DisableThis;
        }

		void SetInitialReferences()
		{
            enemyMaster = GetComponent<Enemy_Master>();
            myTransform = this.transform;

            if (headTransform == null)
                headTransform = myTransform;

            checkRate = Random.Range(0.8f, 1.2f);
		}
		
		void Update () 
		{
            CarryOutDetection();
        }

        void CarryOutDetection()
        {
            if (Time.time >= nextCheck)
            {
                nextCheck = Time.time + checkRate;

                Collider[] colliders = Physics.OverlapSphere(myTransform.position, detectRadius, playerLayer);

                if (colliders.Length > 0)
                {
                    foreach (Collider potentialTarget in colliders)
                    {
                        if (potentialTarget.CompareTag(GameManager_References._playerTag))
                            if (CanPotentialTargetBeSeen(potentialTarget.transform))
                                break;
                    }
                }
                else
                    enemyMaster.CallEventEnemyLostTarget();
            }
        }

        void DisableThis()
        {
            this.enabled = false;
        }

        bool CanPotentialTargetBeSeen(Transform potentialTarget)
        {
            if(Physics.Linecast(headTransform.position, potentialTarget.position, out hit, sightLayer))
            {
                if (hit.transform == potentialTarget)
                {
                    enemyMaster.CallEventEnemySetNavTarget(potentialTarget);
                    return true;
                }
                else
                {
                    enemyMaster.CallEventEnemyLostTarget();
                    return false;
                }
            }
            return false;
        }
	}
}
