using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Item_Pickup : MonoBehaviour 
	{
        private Item_Master itemMaster;
		
		void OnEnable()
		{
			SetInitialReferences();
            itemMaster.EventPickupAction += CarryOutPickupActions;
		}

		void OnDisable()
		{
            itemMaster.EventPickupAction -= CarryOutPickupActions;
        }

		void SetInitialReferences()
		{
            itemMaster = GetComponent<Item_Master>();
		}

        void CarryOutPickupActions(Transform parent)
        {
            transform.SetParent(parent);
            itemMaster.CallEventObjectPickup();
            transform.gameObject.SetActive(false);
        }
	}
}
