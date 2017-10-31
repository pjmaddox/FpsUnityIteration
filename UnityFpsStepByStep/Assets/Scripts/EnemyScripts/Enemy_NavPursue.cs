﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace s3
{
	public class Enemy_NavPursue : MonoBehaviour 
	{
        private Enemy_Master enemyMaster;
        private NavMeshAgent myNavMeshAgent;
        private float checkRate;
        private float nextCheck;
		
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
            if (GetComponent<NavMeshAgent>() != null)
                myNavMeshAgent = GetComponent<NavMeshAgent>();

            checkRate = Random.Range(0.1f, 0.2f);
        }
		
		void Update () 
		{
			if(Time.time >= nextCheck)
            {
                nextCheck = Time.time + checkRate;
                TryToChaseTarget();
            }

        }

        void TryToChaseTarget()
        {
            if (enemyMaster.myTarget != null && myNavMeshAgent != null & !enemyMaster.isNavPaused)
            {
                myNavMeshAgent.SetDestination(enemyMaster.myTarget.position);
                if (myNavMeshAgent.remainingDistance > myNavMeshAgent.stoppingDistance)
                {
                    enemyMaster.CallEventEnemyWalking();
                    enemyMaster.isOnRoute = true;
                }
            }
        }

        void DisableThis()
        {
            if (myNavMeshAgent)
                myNavMeshAgent.enabled = false;

            this.enabled = false;
        }
	}
}
