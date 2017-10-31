using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Enemy_Health : MonoBehaviour 
	{
        public int maxHealth = 100;
        public int currentHealth;
        private Enemy_Master enemyMaster;


		
		void OnEnable()
		{
			SetInitialReferences();
            enemyMaster.EventEnemyDeductHealth += HealthChanged;
		}

		void OnDisable()
		{
            enemyMaster.EventEnemyDeductHealth -= HealthChanged;
        }

		void SetInitialReferences()
		{
            enemyMaster = GetComponent<Enemy_Master>();
            currentHealth = maxHealth;

        }

        void HealthChanged(int healthDelta)
        {
            currentHealth += healthDelta;

            if(currentHealth <= 0)
            {
                currentHealth = 0;
                enemyMaster.CallEventEnemyDie();
                Destroy(this.gameObject, Random.Range(10f, 20f));
            }

            if (currentHealth > maxHealth)
                currentHealth = maxHealth;

        }
	}
}
