using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class GameManager_ToggleMenuUi : MonoBehaviour
    {
        private Player_Master playerMaster;
        public GameObject menuCanvas;

        void OnEnable()
        {
            SetInitialReferences();
            playerMaster.EventPlayerToggledMenuUi += ToggleMenuUi;
        }

        void OnDisable()
        {
            playerMaster.EventPlayerToggledMenuUi -= ToggleMenuUi;
        }

        void SetInitialReferences()
        {
            playerMaster = GetComponent<Player_Master>();
        }

        void Update()
        {
            CheckForMenuToggleKeyPress();
        }

        void CheckForMenuToggleKeyPress()
        {
            if (Input.GetButtonDown("ToggleMenu"))
            {
                //Toggle off inventory if Menu is being opened and inventory is opened
                if (playerMaster.isInventoryVisible)
                    playerMaster.CallEventPlayerToggledInventory();

                playerMaster.CallEventPlayerToggledMenu();
            }
        }

        void ToggleMenuUi()
        {
            if (menuCanvas)
                menuCanvas.SetActive(!menuCanvas.activeSelf);
        }
    }
}
