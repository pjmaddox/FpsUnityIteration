using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Item_Colliders : MonoBehaviour 
	{
        private Item_Master itemMaster;
        public Collider[] colliders;
        public PhysicMaterial myPhysicMaterial;
        	
		void OnEnable()
		{
			SetInitialReferences();
            CheckIfStartsInInventory();
            itemMaster.EventObjectPickedUp += DisableColliders;
            itemMaster.EventObjectThrown += EnableColliders;
        }

		void OnDisable()
		{
            itemMaster.EventObjectPickedUp -= DisableColliders;
            itemMaster.EventObjectThrown -= EnableColliders;
        }

		void SetInitialReferences()
		{
            itemMaster = GetComponent<Item_Master>();

        }

		void Start () 
		{
			
		}
		
		void Update () 
		{
			
		}

        void CheckIfStartsInInventory()
        {
            if (transform.root.CompareTag(GameManager_References._playerTag))
                DisableColliders();
        }

        void EnableColliders()
        {
            foreach (Collider colx in colliders)
            {
                colx.enabled = true;

                if (myPhysicMaterial != null)
                {
                    colx.material = myPhysicMaterial;
                }
            }
        }

        void DisableColliders()
        {
            foreach (Collider colx in colliders)
                colx.enabled = false;
        }
	}
}
