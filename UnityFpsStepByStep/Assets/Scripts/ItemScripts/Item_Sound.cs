using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Item_Sound : MonoBehaviour 
	{
        private Item_Master itemMaster;
        public float volume = 5;
        public AudioClip throwSound;

		void OnEnable()
		{
			SetInitialReferences();
            itemMaster.EventObjectThrown += PlayThrowSound;
		}

		void OnDisable()
		{
            itemMaster.EventObjectThrown -= PlayThrowSound;
        }

		void SetInitialReferences()
		{
            itemMaster = GetComponent<Item_Master>();
		}
		
        void PlayThrowSound()
        {
            PlayClip(throwSound);
        }

        void PlayClip(AudioClip clip)
        {
            AudioSource.PlayClipAtPoint(throwSound, transform.position, volume);
        }
	}
}
