using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace s3
{
	public class GameManager_HandleCurosrLock : MonoBehaviour 
	{
        //private GameManager_Master gameManagerScript;
        private Player_Master playerScript;
        private FirstPersonController fpsController;
        private bool isCursorLocked = true;
		
		void OnEnable()
		{
			SetInitialReferences();
            playerScript.EventPlayerToggledInventoryUi += ToggleCursorLock;
            playerScript.EventPlayerToggledMenuUi += ToggleCursorLock;
            SetCursorLocked();
		}

		void OnDisable()
		{
            playerScript.EventPlayerToggledInventoryUi -= ToggleCursorLock;
            playerScript.EventPlayerToggledMenuUi -= ToggleCursorLock;
        }

		void SetInitialReferences()
		{
            playerScript = GetComponent<Player_Master>();
            fpsController = playerScript.gameObject.GetComponent<FirstPersonController>();
        }

        void ToggleCursorLock()
        {
            if (isCursorLocked)
                SetCursorUnlocked();
            else
                SetCursorLocked();

            isCursorLocked = !isCursorLocked;
        }

        void SetCursorLocked()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            fpsController.enabled = true;
        }

        void SetCursorUnlocked()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            fpsController.enabled = false;
        }
	}
}
