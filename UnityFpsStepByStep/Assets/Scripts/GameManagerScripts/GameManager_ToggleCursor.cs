using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
    public class GameManager_ToggleCursor : MonoBehaviour
    {
        private bool isCursorLocked = true;
        private GameManager_Master gameManagerScript;

        void OnEnable()
        {
            SetInitialReferences();
            gameManagerScript.InventoryUiToggleEvent += ToggleCursorState;
            gameManagerScript.MenuToggleEvent += ToggleCursorState;
        }

        void OnDisable()
        {
            gameManagerScript.InventoryUiToggleEvent -= ToggleCursorState;
            gameManagerScript.MenuToggleEvent -= ToggleCursorState;
        }

        void Update()
        {
            EnforceCursorLockState();
        }

        void SetInitialReferences()
        {
            gameManagerScript = GetComponent<GameManager_Master>();
        }

        void ToggleCursorState()
        {
            isCursorLocked = !isCursorLocked;
        }

        void EnforceCursorLockState()
        {
            if (isCursorLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}
