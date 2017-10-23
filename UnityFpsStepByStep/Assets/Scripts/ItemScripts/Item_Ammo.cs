using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Item_Ammo : MonoBehaviour 
	{
        private Item_Master itemMaster;
        private GameObject player;
        public string ammoName;
        public int quantity;
        public bool isTrigggerPickup;
		
		void OnEnable()
		{
			SetInitialReferences();
            itemMaster.EventObjectPickedUp += TakeAmmo;
		}

        void Start()
        {
            SetInitialReferences();
        }

		void OnDisable()
		{
            itemMaster.EventObjectPickedUp -= TakeAmmo;
        }

		void SetInitialReferences()
		{
            itemMaster = GetComponent<Item_Master>();
            player = GameManager_References._player;

            if(isTrigggerPickup)
            {
                if (GetComponent<Collider>() != null)
                    GetComponent<Collider>().isTrigger = true;

                if (GetComponent<Rigidbody>() != null)
                    GetComponent<Rigidbody>().isKinematic = true;
            }
		}

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(GameManager_References._playerTag) && isTrigggerPickup)
                TakeAmmo();
        }

        void TakeAmmo()
        {
            player.GetComponent<Player_Master>().CallEventPickupAmmo(ammoName, quantity);
            Destroy(this.gameObject);
        }
	}
}
