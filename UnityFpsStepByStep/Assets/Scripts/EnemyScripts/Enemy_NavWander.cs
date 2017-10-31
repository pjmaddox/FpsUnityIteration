using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace s3
{
	public class Enemy_NavWander : MonoBehaviour 
	{
        private Enemy_Master enemyMaster;
        private NavMeshAgent myNavMeshAgent;
        private float checkRate;
        private float nextCheck;
        private Transform myTrasform;
        public float wanderRange = 15f;
        private NavMeshHit navHIt;
        private Vector3 result;

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
            if (GetComponent<NavMeshAgent>())
                myNavMeshAgent = GetComponent<NavMeshAgent>();
            checkRate = Random.Range(.3f, .6f);
            if (wanderRange == 0)
                wanderRange = 15f;
            myTrasform = this.transform;
		}

        void Update()
        {
            CheckIfShouldWander();
        }

        void CheckIfShouldWander()
        {
            if (enemyMaster.myTarget == null && !enemyMaster.isOnRoute && !enemyMaster.isNavPaused)
            {
                if (RanodmWanderTarget(myTrasform.position, wanderRange, out result))
                {
                    myNavMeshAgent.SetDestination(result);
                    enemyMaster.isOnRoute = true;
                    enemyMaster.CallEventEnemyWalking();
                }
            }
        }

        bool RanodmWanderTarget(Vector3 center, float range, out Vector3 result)
        {
            Vector3 randomPOint = center + Random.insideUnitSphere * wanderRange;

            if(NavMesh.SamplePosition(randomPOint, out navHIt, 1.0f, NavMesh.AllAreas))
            {
                result = navHIt.position;
                return true;
            }
            else
            {
                result = center;
                return false;
            }
        }

        void DisableThis()
        {
            this.enabled = false;
        }
	}
}
