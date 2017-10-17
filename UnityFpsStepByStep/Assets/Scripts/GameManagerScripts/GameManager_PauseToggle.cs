using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
    public class GameManager_PauseToggle : MonoBehaviour
    {
        private GameManager_Master gameManagerScript;
        private bool isPaused;

        void OnEnable()
        {
            SetInitialReferences();
            gameManagerScript.MenuToggleEvent += TogglePause;
            gameManagerScript.InventoryUiToggleEvent += TogglePause;
        }

        void OnDisable()
        {
            gameManagerScript.MenuToggleEvent += TogglePause;
            gameManagerScript.InventoryUiToggleEvent += TogglePause;
        }

        void SetInitialReferences()
        {
            gameManagerScript = GetComponent<GameManager_Master>();
        }

        void TogglePause()
        {
            if (isPaused)
            {
                Time.timeScale = 1;
                isPaused = false;
            }
            else
            {
                Time.timeScale = 0;
                isPaused = true;
            }
        }
    }

}
