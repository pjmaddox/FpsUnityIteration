using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
    public class GameManager_ToggleMenu : MonoBehaviour
    {
        private GameManager_Master gameManagerScript;
        public GameObject menuToToggle;

        void OnEnable()
        {
            SetInitialReferences();
            gameManagerScript.GameOverEvent += ToggleMenu;
        }

        void OnDisable()
        {
            gameManagerScript.GameOverEvent -= ToggleMenu;
        }

        void SetInitialReferences()
        {
            gameManagerScript = GetComponent<GameManager_Master>();
        }

        void CheckForMenuToggleRequest()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !gameManagerScript.isGameOver && !gameManagerScript.isInventoryOpen)
            {
                ToggleMenu();
            }
        }

        void ToggleMenu()
        {
            if (menuToToggle != null)
            {
                menuToToggle.SetActive(!menuToToggle.activeSelf);
                gameManagerScript.isMenuOn = !gameManagerScript.isMenuOn;
                gameManagerScript.CallEventMenuToggle();
            }
            else
            {
                Debug.LogWarning("You need to slot a UI Menu for ToggleMenu Script");
            }
        }

        // Use this for initialization
        void Start()
        {
            ToggleMenu();
        }

        // Update is called once per frame
        void Update()
        {
            CheckForMenuToggleRequest();
        }
    }
}
