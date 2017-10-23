using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Item_Animator : MonoBehaviour 
	{
        //Animators override normal physics behavior
        private Animator myAnimator;
        private Item_Master itemMaster;

		void OnEnable()
		{
			SetInitialReferences();
            itemMaster.EventObjectThrown += DisableAnimator;
            itemMaster.EventObjectPickedUp += EnableAnimator;
        }

		void OnDisable()
		{
            itemMaster.EventObjectThrown -= DisableAnimator;
            itemMaster.EventObjectPickedUp -= EnableAnimator;
        }

		void SetInitialReferences()
		{
            myAnimator = GetComponent<Animator>();
            itemMaster = GetComponent<Item_Master>();
        }

		void EnableAnimator()
        {
            if (myAnimator)
                myAnimator.enabled = true;
        }

        void DisableAnimator()
        {
            if (myAnimator)
                myAnimator.enabled = false;
        }
	}
}
