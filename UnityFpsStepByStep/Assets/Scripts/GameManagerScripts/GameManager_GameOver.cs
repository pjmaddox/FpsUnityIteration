using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
    public class GameManager_GameOver : MonoBehaviour
    {
        private GameManager_Master gameManagerScript;
        public GameObject gameOverPanel;

        void OnEnable()
        {
            SetInitialReferences();
            gameManagerScript.GameOverEvent += EnableGameOverPanel;
        }

        void OnDisable()
        {
            gameManagerScript.GameOverEvent -= EnableGameOverPanel;
        }

        void SetInitialReferences()
        {
            gameManagerScript = GetComponent<GameManager_Master>();
        }

        void EnableGameOverPanel()
        {
            if (gameOverPanel)
            {
                gameOverPanel.SetActive(true);
            }
        }
    }
}
