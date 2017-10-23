using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Item_Master : MonoBehaviour {

        private Player_Master playerScript;

        public delegate void GeneralEventHandler();
        public event GeneralEventHandler EventObjectThrown;
        public event GeneralEventHandler EventObjectPickedUp;

        public delegate void PickupActionEventHandler(Transform item);
        public event PickupActionEventHandler EventPickupAction;

		void OnEnable()
		{
            SetInitialReferences();

        }

        void Start()
        {
            SetInitialReferences();
        }

		void SetInitialReferences()
		{
            if(GameManager_References._player != null)
            {
                playerScript = GameManager_References._player.GetComponent<Player_Master>();
            }
		}

        public void CallEventObjectThrow()
        {
            if(EventObjectThrown != null)
            {
                EventObjectThrown();
            }

            playerScript.CallEventEmptyHands();
            playerScript.CallEventInventoryChanged();
        }

        public void CallEventObjectPickup()
        {
            if (EventObjectPickedUp != null)
            {
                EventObjectPickedUp();
            }

            playerScript.CallEventInventoryChanged();
        }

        public void CallEventPickupAction(Transform pickedUp)
        {
            if (EventPickupAction != null)
            {
                EventPickupAction(pickedUp);
            }
        }

	}
}
