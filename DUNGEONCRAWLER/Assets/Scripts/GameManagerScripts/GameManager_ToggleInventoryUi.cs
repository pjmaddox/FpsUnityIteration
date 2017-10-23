using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class GameManager_ToggleInventoryUi : MonoBehaviour
    {

        private Player_Master playerMaster;
        public GameObject inventoryCanvas;

        void OnEnable()
		{
			SetInitialReferences();
            playerMaster.EventPlayerToggledInventoryUi += ToggleInventoryUi;
		}

		void OnDisable()
		{
            playerMaster.EventPlayerToggledInventoryUi -= ToggleInventoryUi;
        }

		void SetInitialReferences()
		{
            playerMaster = GetComponent<Player_Master>();
        }
		
		void Update ()
        {
            CheckForInventoryToggleKeyPress();
		}

        void CheckForInventoryToggleKeyPress()
        {
            if (Input.GetButtonDown("ToggleInventory") && !playerMaster.isMenuVisible)
            {
                playerMaster.CallEventPlayerToggledInventory();
            }
        }

        void ToggleInventoryUi()
        { 
            if (inventoryCanvas)
                inventoryCanvas.SetActive(!inventoryCanvas.activeSelf);
        }
	}
}
