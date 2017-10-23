using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace s3
{
	public class Player_Health : MonoBehaviour
    {

        private GameManager_Master gameManagerScript;
        private Player_Master playerScript;
        public Text healthText;
        public int currentHealth;
        public int playerMaxHealth = 100;


        void OnEnable()
		{
			SetInitialReferences();
            playerScript.EventPlayerHealthChanged += HandleHealthChange;
		}

		void OnDisable()
		{
            playerScript.EventPlayerHealthChanged -= HandleHealthChange;
		}

		void SetInitialReferences()
		{
            gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager_Master>();
            playerScript = GetComponent<Player_Master>();
		}

		void Start () {
            //Health Deduction test
            //StartCoroutine( TestHealthDeduction());
            //AmmoPickup test
            //StartCoroutine(TestAmmoPickup());
        }

        //IEnumerator TestAmmoPickup()
        //{
        //    yield return new WaitForSeconds(2);
        //    playerScript.CallEventPickupAmmo("TestGun", 19);
        //}

        //IEnumerator TestHealthDeduction()
        //{
        //    yield return new WaitForSeconds(3);
        //    playerScript.CallEventPlayerHealthChanged(-50);
        //    Debug.LogWarning("A test method in Player_Health reduced hp for the character.");
        //}

        void HandleHealthChange(int healthDelta)
        {
            currentHealth += healthDelta;

            NormalizeHealthAndCheckForGameOver();

            SetUi();
        }

        void NormalizeHealthAndCheckForGameOver()
        {
            if (currentHealth >= playerMaxHealth)
                currentHealth = playerMaxHealth;

            if (currentHealth <= 0)
                gameManagerScript.CallGameOverEvent();
        }

        void SetUi()
        {
            if(healthText != null) 
                healthText.text = currentHealth.ToString();
        }
    }
}
