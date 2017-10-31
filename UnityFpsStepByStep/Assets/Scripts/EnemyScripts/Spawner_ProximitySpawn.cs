using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Spawner_ProximitySpawn : MonoBehaviour 
	{
        public GameObject objectToSpawn;
        public int numberToSpawn = 5;
        public float proximity = 10f;
        private float checkRate;
        private float nextCheck;
        private Transform myTransform;
        private Transform playerTransform;
        private Vector3 spawnPosition;

		void SetInitialReferences()
		{
            myTransform = transform;
            playerTransform = GameManager_References._player.transform;
            checkRate = Random.Range(0.2f, 0.5f);
		}

		void Start () 
		{
            SetInitialReferences();
		}
		
		void Update () 
		{
            CheckDistance();
		}

        void CheckDistance()
        {
            if(Time.time >= nextCheck)
            {
                nextCheck = Time.time + checkRate;
                if (Vector3.Distance(myTransform.position, playerTransform.position) < proximity)
                {
                    SpawnObjects();
                    this.enabled = false;
                }
            }
        }

        void SpawnObjects()
        {
            for (int i = 0; i < numberToSpawn; ++i)
            {
                spawnPosition = myTransform.position + Random.insideUnitSphere * 5;
                var go = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
                go.name = "Enemy-" + i;
            }
        }
	}
}
