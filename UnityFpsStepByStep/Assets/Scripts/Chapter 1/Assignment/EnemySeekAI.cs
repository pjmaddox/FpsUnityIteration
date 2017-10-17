using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Chapter1Assignment
{
    public class EnemySeekAI : MonoBehaviour
    {
        private float targetCheckRate;
        private Transform myTransform;
        private NavMeshAgent myAgent;
        private float nextCheckTime;
        private float seekRadius = 20f;
        private LayerMask targetsLayer = (1 << 11);
        private EnemyManager_EnemyEventManager enemyManagerScript;

        // Use this for initialization
        void Start()
        {
            SetInitialReferences();
        }

        void SetInitialReferences()
        {
            myTransform = this.transform;
            myAgent = GetComponent<NavMeshAgent>();
            targetCheckRate = Random.Range(0.8f, 1.5f);
            enemyManagerScript = GameObject.Find("EnemyManager").GetComponent<EnemyManager_EnemyEventManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Time.time >= nextCheckTime && myAgent.enabled)
            {
                nextCheckTime = Time.time + nextCheckTime;
                SeekEnemyPosition();
            }
        }

        void SeekEnemyPosition()
        {
            var hits = Physics.OverlapSphere(myTransform.position, seekRadius, targetsLayer);

            if (hits.Length > 0)
                myAgent.SetDestination(hits[0].transform.position);
        }

        public void MarkEnemyKilled()
        {
            enemyManagerScript.EnemyCountDecrement();
        }
    }
}
