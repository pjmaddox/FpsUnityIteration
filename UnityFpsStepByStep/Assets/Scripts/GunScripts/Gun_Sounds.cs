using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Gun_Sounds : MonoBehaviour 
	{
        public Gun_Master gunMaster;
        private Transform myTransform;
        public float shootVolume = 0.4f;
        public float reloadVolume = 0.5f;
        public AudioClip[] shootSound;
        public AudioClip reloadSound;

		void OnEnable()
		{
			SetInitialReferences();
            gunMaster.EventPlayerPressedFire += PlayShootSound;
		}

		void OnDisable()
		{
            gunMaster.EventPlayerPressedFire -= PlayShootSound;
        }

		void SetInitialReferences()
		{
            gunMaster = GetComponent<Gun_Master>();
            myTransform = this.transform;
		}

		void PlayShootSound()
        {
            if (shootSound.Length > 0)
            {
                int index = Random.Range(0, shootSound.Length);
                AudioSource.PlayClipAtPoint(shootSound[index], myTransform.position, shootVolume);
            }
        }

        public void PlayReloadSound() //Called by the reload animation event
        {
            if(reloadSound != null)
            {
                AudioSource.PlayClipAtPoint(reloadSound, myTransform.position, reloadVolume);
            }
        }
	}
}
