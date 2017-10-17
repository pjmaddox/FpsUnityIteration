using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class GameManager_PanelInstructions : MonoBehaviour {

        public GameObject panelInstructions;
        private GameManager_Master gameManagerScript;

		void OnEnable()
		{
			SetInitialReferences();
            gameManagerScript.GameOverEvent += TurnOffPanelInstructions;
		}

		void OnDisable()
		{
            gameManagerScript.GameOverEvent -= TurnOffPanelInstructions;
        }

		void SetInitialReferences()
		{
            gameManagerScript = GetComponent<GameManager_Master>();
		}

        void TurnOffPanelInstructions()
        {
            panelInstructions.SetActive(false);
        }
	}
}
