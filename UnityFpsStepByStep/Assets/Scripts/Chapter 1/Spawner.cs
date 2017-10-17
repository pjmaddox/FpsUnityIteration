using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Chapter1
{
    public class Spawner : MonoBehaviour
    {
        public GameObject enemyToSpawn;
        public int numEnemies = 5;

        private GameManager_EventMaster eventMasterScript;
        private float spawnRadius = 10;
        private Vector3 spawnPosition;

        void OnEnable()
        {
            SetInitialReferences();

            //Subscribe SpawnEnemy method to an event
            eventMasterScript.myGeneralEvent += SpawnEnemy;
        }

        void OnDisable()
        {
            eventMasterScript.myGeneralEvent -= SpawnEnemy;
        }

        void SpawnEnemy()
        {
            for(int i = 0; i < numEnemies; ++i)
            {
                spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
                spawnPosition = new Vector3(spawnPosition.x, .5f, spawnPosition.z);
                Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
            }
        }

        void SetInitialReferences()
        {
            eventMasterScript = GameObject.Find("GameManager").GetComponent<GameManager_EventMaster>();
        }
    }
}
