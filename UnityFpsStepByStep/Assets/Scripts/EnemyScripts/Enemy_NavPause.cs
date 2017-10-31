using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace s3
{
	public class Enemy_NavPause : MonoBehaviour 
	{
        private Enemy_Master enemymaster;
        private NavMeshAgent myNavMeshAgent;
        private float pauseTime = 1f;
		
		void OnEnable()
		{
			SetInitialReferences();
            enemymaster.EventEnemyDeductHealth += PauseNavMeshAgent;
		}

		void OnDisable()
		{
            enemymaster.EventEnemyDeductHealth -= PauseNavMeshAgent;
        }

		void SetInitialReferences()
		{
            enemymaster = GetComponent<Enemy_Master>();
            if (GetComponent<NavMeshAgent>())
                myNavMeshAgent = GetComponent<NavMeshAgent>();
        }

        void PauseNavMeshAgent(int dummy)
        {
            if (myNavMeshAgent != null && myNavMeshAgent.enabled)
            {
                enemymaster.isNavPaused = true;
                myNavMeshAgent.ResetPath();
                StartCoroutine(RestartNavMeshAgentAfterSZeconds());
            }
        }

        IEnumerator RestartNavMeshAgentAfterSZeconds()
        {
            yield return new WaitForSeconds(pauseTime);
            enemymaster.isNavPaused = false;
        }

        void DisableThis()
        {
            StopAllCoroutines();
            this.enabled = false;
        }
	}
}
