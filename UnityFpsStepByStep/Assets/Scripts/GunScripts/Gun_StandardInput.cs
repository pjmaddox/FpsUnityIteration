﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Gun_StandardInput : MonoBehaviour 
	{
        private Gun_Master gunMaster;
        private float nextAttack;
        public float attackRate = 0.5f;
        private Transform myTransform;
        public bool isAutomatic;
        public bool hasBurstFire;
        public int shotsInBurst = 3;
        public float burstAttackDelay = .01f;
        private bool isBurstFireActive;
        public string attackButtonName;
        public string reloadButtonName;
        public string fireModeChangeButtonName;

        void CheckIfWeaponShouldAttack()
        {
            if (Time.time > nextAttack && Time.timeScale > 0 && myTransform.root.CompareTag(GameManager_References._playerTag))
            {
                if(isAutomatic && !isBurstFireActive)
                {
                    if (Input.GetButton(attackButtonName))
                    {
                        AttemptAttack();
                    }
                }
                else if (isAutomatic && isBurstFireActive)
                {
                    if (Input.GetButtonDown(attackButtonName))
                    {
                        StartCoroutine(RunBurstFire());
                    }
                }
                else if (!isAutomatic)
                {
                    if (Input.GetButtonDown(attackButtonName))
                    {
                        AttemptAttack();
                    }
                }
            }
        }

        void AttemptAttack()
        {
            nextAttack = Time.time + attackRate;
            if(gunMaster.isGunLoaded)
            {
                gunMaster.CallEventPlayerInput();
            }
            else
            {
                gunMaster.CallEventGunNotUsable();
            }
        }

        void CheckForReloadRequest()
        {
            if (Input.GetButtonDown(reloadButtonName) && Time.timeScale > 0 && myTransform.root.CompareTag(GameManager_References._playerTag))
            {
                gunMaster.CallEventRequestReload();
            }
        }

        void CheckForBurstFireToggle()
        {
            if (Input.GetButtonDown(fireModeChangeButtonName) && Time.timeScale > 0 && myTransform.root.CompareTag(GameManager_References._playerTag))
            {
                isBurstFireActive = !isBurstFireActive;
                gunMaster.CallEventToggleBurstFire();
            }
        }

        IEnumerator RunBurstFire()
        {
            for(int i = 0; i < shotsInBurst; ++i)
            {
                AttemptAttack();
                yield return new WaitForSeconds(burstAttackDelay);
            }
        }
		
		void OnEnable()
		{
			SetInitialReferences();
		}

		void SetInitialReferences()
		{
            gunMaster = GetComponent<Gun_Master>();
            myTransform = this.transform;
            gunMaster.isGunLoaded = true; // so player can attempt shooting as soon as they pick it up
		}

		void Update () 
		{
            CheckIfWeaponShouldAttack();
            CheckForBurstFireToggle();
            CheckForReloadRequest();
		}
	}
}
