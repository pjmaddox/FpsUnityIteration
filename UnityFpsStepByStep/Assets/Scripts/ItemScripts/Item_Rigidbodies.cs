using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Item_Rigidbodies : MonoBehaviour 
	{
        private Item_Master itemMaster;
        public Rigidbody[] myRigidBodies;

		void OnEnable()
		{
			SetInitialReferences();
            itemMaster.EventObjectPickedUp += DisableRigidfBodies;
            itemMaster.EventObjectThrown += EnableRigidBodies;
		}

		void OnDisable()
		{
            itemMaster.EventObjectPickedUp -= DisableRigidfBodies;
            itemMaster.EventObjectThrown -= EnableRigidBodies;
        }

		void SetInitialReferences()
		{
            itemMaster = GetComponent<Item_Master>();
        }

        void Start()
        {
            if (StartsInPlayerInventory())
                DisableRigidfBodies();
        }

        bool StartsInPlayerInventory()
        {
            return this.transform.root.CompareTag(GameManager_References._playerTag);
        }

        void DisableRigidfBodies()
        {
            foreach (Rigidbody x in myRigidBodies)
            {
                x.useGravity = false;
                x.isKinematic = true;
            }
        }

        void EnableRigidBodies()
        {
            foreach (Rigidbody x in myRigidBodies)
            {
                x.useGravity = true;
                x.isKinematic = false;
            }
        }
	}
}
