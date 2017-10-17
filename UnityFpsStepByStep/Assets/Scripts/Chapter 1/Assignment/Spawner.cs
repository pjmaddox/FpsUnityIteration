using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter1Assignment
{
    public class Spawner : MonoBehaviour
    {
        public GameObject enemyToSpawn;
        public float numEnemiesToSpawn;
        private float spawnRadius = 5f;
        private GameManager_EventMaster eventMasterScript;
        private EnemyManager_EnemyEventManager enemyManagerScript;

        void OnEnable()
        {
            SetInitialReferences();
            eventMasterScript.trapTriggeredEvent += SpawnEnemies;
        }

        void OnDisable()
        {
            eventMasterScript.trapTriggeredEvent -= SpawnEnemies;
        }

        void SetInitialReferences()
        {
            enemyManagerScript = GameObject.Find("EnemyManager").GetComponent<EnemyManager_EnemyEventManager>();
            eventMasterScript = GameObject.Find("GameManager").GetComponent<GameManager_EventMaster>();
        }

        void SpawnEnemies()
        {
            var myPosition = this.transform.position;

            for (int i = 0; i < numEnemiesToSpawn; ++i)
            {
                Instantiate(enemyToSpawn, myPosition + Random.insideUnitSphere, Quaternion.identity);
                enemyManagerScript.EnemyCountIncrement();
            }
        }
    }
}
