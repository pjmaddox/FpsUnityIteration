using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Enemy_Attack : MonoBehaviour 
	{
        private Enemy_Master enemyMaster;
        private Transform myTransform;
        private Transform attackTarget;
        private float nextAttack;
        private float attackRate = 1f;
        public float attackRange = 3.5f;
        public int attackDamage = 10;

		void OnEnable()
		{
			SetInitialReferences();
            enemyMaster.EventEnemyDie += DisableThis;
            enemyMaster.EventEnemySetNavTarget += SetAttackTarget;
        }

		void OnDisable()
		{
            enemyMaster.EventEnemyDie -= DisableThis;
            enemyMaster.EventEnemySetNavTarget -= SetAttackTarget;
        }

		void SetInitialReferences()
		{
            enemyMaster = GetComponent<Enemy_Master>();
            myTransform = this.transform;
		}

        void Update()
        {
            TryAttack();
        }

        void TryAttack()
        {
            if(attackTarget != null && Time.time >= nextAttack)
            {
                nextAttack = Time.time + attackRate;
                if(Vector3.Distance(myTransform.position, attackTarget.position) <= attackRange)
                {
                    Vector3 lookAtVector = new Vector3(attackTarget.position.x, myTransform.position.y, attackTarget.position.z);
                    myTransform.LookAt(lookAtVector);
                    enemyMaster.CallEventEnemyAttack();
                    enemyMaster.isOnRoute = false;
                }
            }
        }

        void SetAttackTarget(Transform newTarget)
        {
            attackTarget = newTarget;
        }

        public void OnEnemyAttack() //Called by high punch animation
        {
            if (attackTarget != null)
            {
                if (attackTarget.GetComponent<Player_Master>() != null && Vector3.Distance(myTransform.position, attackTarget.position) <= attackRange)
                {
                    Vector3 toOther = attackTarget.position - myTransform.position;

                    //DEBUGGING
                    Debug.Log(toOther);

                    if (Vector3.Dot(toOther, myTransform.forward) > 0.5f)
                        attackTarget.GetComponent<Player_Master>().CallEventPlayerHealthChanged(-attackDamage);
                }
            }
        }

        void DisableThis()
        {
            this.enabled = false;
        }
	}
}
