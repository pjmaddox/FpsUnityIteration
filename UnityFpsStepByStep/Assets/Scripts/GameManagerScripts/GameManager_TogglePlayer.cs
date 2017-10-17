using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace s3
{
    public class GameManager_TogglePlayer : MonoBehaviour
    {
        public FirstPersonController playerController;
        private GameManager_Master gameManagerScript;

        void OnEnable()
        {
            SetInitialReferences();
            gameManagerScript.MenuToggleEvent += TogglePlayerController;
            gameManagerScript.InventoryUiToggleEvent += TogglePlayerController;
        }

        void OnDisable()
        {
            gameManagerScript.MenuToggleEvent -= TogglePlayerController;
            gameManagerScript.InventoryUiToggleEvent -= TogglePlayerController;
        }

        void SetInitialReferences()
        {
            gameManagerScript = GetComponent<GameManager_Master>();
        }

        void TogglePlayerController()
        {
            if (playerController)
            {
                playerController.enabled = !playerController.enabled;
            }
        }
    }
}
