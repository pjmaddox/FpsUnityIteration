using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Gun_MuzzleFlash : MonoBehaviour 
	{

        public ParticleSystem muzzleFlashParticles;
        private Gun_Master gunMaster;
        	
		void OnEnable()
		{
			SetInitialReferences();
            gunMaster.EventPlayerPressedFire += PlayMuzzleFlash;
		}

		void OnDisable()
		{
            gunMaster.EventPlayerPressedFire -= PlayMuzzleFlash;
        }

		void SetInitialReferences()
		{
            gunMaster = GetComponent<Gun_Master>();
		}

        void PlayMuzzleFlash()
        {
            if (muzzleFlashParticles)
                muzzleFlashParticles.Play();
        }
	}
}
