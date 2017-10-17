using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
    public class GameManager_ToggleInventoryUi : MonoBehaviour
    {

        public GameObject inventoryCanvas;

        [Tooltip("Does this game mode have an inventory?")]
        public bool hasInventory;

        public string toggleInventoryButtonName;
        private GameManager_Master gameManagerScript;

        // Use this for initialization
        void Start()
        {
            SetInitialReferences();
        }

        void SetInitialReferences()
        {
            gameManagerScript = GetComponent<GameManager_Master>();

            if (toggleInventoryButtonName == "")
            {
                Debug.LogWarning("You must assign a inventory button name on the TogglInventoryUi script");
                this.enabled = false;
            }
        }

        void ToggleInventory()
        {
            if (inventoryCanvas)
            {
                inventoryCanvas.SetActive(!inventoryCanvas.activeSelf);
                gameManagerScript.isInventoryOpen = !gameManagerScript.isInventoryOpen;
                gameManagerScript.CallEventInventoryUiToggle();
            }
        }

        void CheckForToggleInventoryRequest()
        {
            if (Input.GetButtonUp(toggleInventoryButtonName) && !gameManagerScript.isMenuOn && !gameManagerScript.isGameOver && hasInventory)
            {
                ToggleInventory();
            }
        }

        // Update is called once per frame
        void Update()
        {
            CheckForToggleInventoryRequest();
        }
    }
}
