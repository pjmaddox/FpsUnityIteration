using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Item_SetPickupPosition : MonoBehaviour 
	{
        private Item_Master itemMater;
        public Vector3 itemLocalPosition = new Vector3(0,0,2.5f);
        private Transform myTransform;

		void OnEnable()
		{
			SetInitialReferences();
            itemMater.EventObjectPickedUp += SetPositionOnPlayer;
        }

		void OnDisable()
		{
            itemMater.EventObjectPickedUp -= SetPositionOnPlayer;
        }

        void Start()
        {
            SetPositionOnPlayer();
        }

		void SetInitialReferences()
		{
            myTransform = this.transform;
            itemMater = GetComponent<Item_Master>();
        }

        void SetPositionOnPlayer()
        {
            if (this.transform.root.CompareTag(GameManager_References._playerTag))
            {
                myTransform.localPosition = itemLocalPosition;
                myTransform.localRotation = Quaternion.identity;
            }
        }
	}
}
