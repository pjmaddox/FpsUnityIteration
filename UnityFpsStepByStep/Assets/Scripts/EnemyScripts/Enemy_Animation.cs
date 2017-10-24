using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Enemy_Animation : MonoBehaviour 
	{
        private Enemy_Master enemyMaster;
        private Animator myAnimator;

		void OnEnable()
		{
			SetInitialReferences();
            enemyMaster.EventEnemyAttack += SetAnimationToAttack;
            enemyMaster.EventEnemyDie += DisableAnimator;
            enemyMaster.EventEnemyDeductHealth += SetAnimationToStruck;
            enemyMaster.EventEnemyReachedNavTarget += SetAnimationToIdle;
            enemyMaster.EventEnemyLostTarget += SetAnimationToIdle;
            enemyMaster.EventEnemyWalking += SetAnimationToWalk;
		}

		void OnDisable()
		{
            enemyMaster.EventEnemyAttack -= SetAnimationToAttack;
            enemyMaster.EventEnemyDie -= DisableAnimator;
            enemyMaster.EventEnemyDeductHealth -= SetAnimationToStruck;
            enemyMaster.EventEnemyReachedNavTarget -= SetAnimationToIdle;
            enemyMaster.EventEnemyLostTarget -= SetAnimationToIdle;
            enemyMaster.EventEnemyWalking -= SetAnimationToWalk;
        }

		void SetInitialReferences()
		{
            enemyMaster = GetComponent<Enemy_Master>();
            if (GetComponent<Animator>() != null)
                myAnimator = GetComponent<Animator>();
		}

        void SetAnimationToWalk()
        {
            if (myAnimator != null)
            {
                if (myAnimator.enabled)
                {
                    myAnimator.SetBool("isPursuing", true);
                }
            }
        }

        void SetAnimationToAttack()
        {
            if (myAnimator != null)
            {
                if (myAnimator.enabled)
                {
                    myAnimator.SetTrigger("Attack");
                }
            }
        }

        void SetAnimationToIdle()
        {
            if (myAnimator != null)
            {
                if (myAnimator.enabled)
                {
                    myAnimator.SetBool("isPursuing", false);
                }
            }
        }

        void SetAnimationToStruck(int dummyHealthDeduection)
        {
            if (myAnimator != null)
            {
                if (myAnimator.enabled)
                {
                    myAnimator.SetTrigger("Struck");
                }
            }
        }

        void DisableAnimator()
        {
            if (myAnimator != null)
            {
                myAnimator.enabled = false;
            }
        }
    }
}
