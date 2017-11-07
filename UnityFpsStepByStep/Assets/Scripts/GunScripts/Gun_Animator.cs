using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Gun_Animator : MonoBehaviour 
	{

        private Gun_Master gunMaster;
        private Animator myAnimator;
        	
		void OnEnable()
		{
			SetInitialReferences();
            gunMaster.EventPlayerPressedFire += PlayShootAnimation;
		}

		void OnDisable()
		{
            gunMaster.EventPlayerPressedFire -= PlayShootAnimation;
        }

		void SetInitialReferences()
		{
            gunMaster = GetComponent<Gun_Master>();

            var anim = GetComponent<Animator>();
            if (anim)
                myAnimator = anim;
		}

		void PlayShootAnimation()
        {
            if (myAnimator)
                myAnimator.SetTrigger("Shoot");
        }
	}
}
