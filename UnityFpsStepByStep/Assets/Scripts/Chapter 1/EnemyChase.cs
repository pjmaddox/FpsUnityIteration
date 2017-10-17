using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Chapter1
{
    public class EnemyChase : MonoBehaviour
    {
        private Transform myTransform;
        private NavMeshAgent myAgent;
        private Collider[] targets;
        private LayerMask targetLayersMask;
        private float checkRate;
        private float nextCheck;
        private float detectionRadius = 20f;

        // Use this for initialization
        void Start()
        {
            SetInitialReferences();
        }

        // Update is called once per frame
        void Update()
        {
            CheckIfPlayerInRange();
        }
        void SetInitialReferences()
        {
            myTransform = this.transform;
            myAgent = GetComponent<NavMeshAgent>();
            checkRate = Random.Range(0.8f, 1.2f);
            targetLayersMask = 1 << 11;
        }
        void CheckIfPlayerInRange()
        {
            if(Time.time >= nextCheck && myAgent.enabled)
            {
                nextCheck = Time.time + checkRate;

                targets = Physics.OverlapSphere(myTransform.position, detectionRadius, targetLayersMask);

                if(targets.Length > 0)
                {
                    myAgent.SetDestination(targets[0].transform.position);
                }
            }
        }
    }
}
