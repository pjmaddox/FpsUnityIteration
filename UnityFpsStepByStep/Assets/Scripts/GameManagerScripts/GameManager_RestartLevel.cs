using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace s3
{
    public class GameManager_RestartLevel : MonoBehaviour
    {
        private GameManager_Master gameManagerScript;

        void OnEnable()
        {
            SetInitialReferences();
            gameManagerScript.RestartLevelEvent += RestartLevel;
        }

        void OnDisable()
        {
            gameManagerScript.RestartLevelEvent -= RestartLevel;
        }

        void SetInitialReferences()
        {
            gameManagerScript = GetComponent<GameManager_Master>();
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
