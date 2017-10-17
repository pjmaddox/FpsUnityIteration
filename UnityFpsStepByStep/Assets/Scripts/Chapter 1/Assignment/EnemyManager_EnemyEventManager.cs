using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter1Assignment
{
    public class EnemyManager_EnemyEventManager : MonoBehaviour
    {
        private GameManager_EventMaster eventManagerScript;
        private int currentEnemyCount = 0;

        void Start()
        {
            SetInitialReferences();
        }

        void SetInitialReferences()
        {
            eventManagerScript = GameObject.Find("GameManager").GetComponent<GameManager_EventMaster>();
        }

        void CheckForAllEnemiesDefeated()
        {
            if (currentEnemyCount <= 0)
                eventManagerScript.CallDefeatedAllEnemies(); 
        }

        public void EnemyCountIncrement()
        {
            Debug.Log("Enemy Spawned!");
            currentEnemyCount++;
        }

        public void EnemyCountDecrement()
        {
            currentEnemyCount--;
            Debug.Log("Enemy Slain! Only " + currentEnemyCount + " enemies remaining!");
            CheckForAllEnemiesDefeated();
        }
    }
}
