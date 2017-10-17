using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter1
{
    public class GameManager_CursorToggle : MonoBehaviour
    {
        private bool isCursorLocked;

        void Start()
        {
            ToggleCursorLockState();
        }

        // Update is called once per frame
        void Update()
        {
            CheckForInput();
            EnforceCursorState();
        }
        void CheckForInput()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ToggleCursorLockState();
            }
        }

        void ToggleCursorLockState()
        {
            isCursorLocked = !isCursorLocked;
        }

        void EnforceCursorState()
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