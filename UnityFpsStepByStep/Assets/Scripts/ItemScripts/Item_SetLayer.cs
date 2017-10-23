using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Item_SetLayer : MonoBehaviour 
	{

        private Item_Master itemMaster;
        public string itemThrowLayer;
        public string itemPickupLayer;

		void OnEnable()
		{
			SetInitialReferences();
            SetLayerOnEnable();
            itemMaster.EventObjectPickedUp += SetItemToPickupLayer;
            itemMaster.EventObjectThrown += SetItemToThrowLayer;
        }

		void OnDisable()
		{
            itemMaster.EventObjectPickedUp += SetItemToPickupLayer;
            itemMaster.EventObjectThrown += SetItemToThrowLayer;
        }

		void SetInitialReferences()
		{
            itemMaster = GetComponent<Item_Master>();
        }

        void SetItemToThrowLayer()
        {
            SetLayer(this.transform, itemThrowLayer);
        }

        void SetItemToPickupLayer()
        {
            SetLayer(this.transform, itemPickupLayer);
        }

        void SetLayerOnEnable()
        {
            if(itemPickupLayer == "")
                itemPickupLayer = "Weapons";

            if (itemThrowLayer == "")
                itemThrowLayer = "Item";

            if (transform.root.CompareTag(GameManager_References._playerTag))
                SetItemToPickupLayer();
            else
                SetItemToThrowLayer();
        }

        void SetLayer(Transform form, string itemLayeName)
        {
            form.gameObject.layer = LayerMask.NameToLayer(itemLayeName);

            foreach(Transform child in form)
            {
                SetLayer(child, itemLayeName);
            }
        }
	}
}
