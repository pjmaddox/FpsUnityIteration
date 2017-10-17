using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Chapter1Assignment
{
    public class MessageManager : MonoBehaviour
    {
        private string introMessage = "A treasure awaits those who dare seek it...";
        private string defeatedMessage = "NOOOOOO I HAVE BEEN DEFEATED BY A FOOLISH ADVENTURER!";
        private string trapTriggeredMessage = "FOOL! YOU HAVE TRIGGERED MY WRATH!";
        private GameManager_EventMaster eventMasterScript;

        public Text textField;
        public Canvas canvasElement;
        
        void OnEnable()
        {
            SetInitialReferences();
            SubscribeToEvents();
            canvasElement.GetComponent<Canvas>().enabled = true;
            displayIntroMessage();
        }

        void OnDisable()
        {
            eventMasterScript.trapTriggeredEvent -= displayTrapTriggeredMessage;
            eventMasterScript.defeatedAllEnemiesEvent -= displayDefeatedMessage;
        }

        void SubscribeToEvents()
        {
            eventMasterScript.trapTriggeredEvent += displayTrapTriggeredMessage;
            eventMasterScript.defeatedAllEnemiesEvent += displayDefeatedMessage;
        }

        void SetInitialReferences()
        {
            eventMasterScript = GameObject.Find("GameManager").GetComponent<GameManager_EventMaster>();
        }

        void DisplayMessageForTime(string message, float time = 2f)
        {
            canvasElement.GetComponent<Canvas>().enabled = true;
            textField.text = message;
            StartCoroutine(disableCanvasAfterDelay(time));
        }

        void displayIntroMessage()
        {
            DisplayMessageForTime(introMessage);
        }

        void displayTrapTriggeredMessage()
        {
            DisplayMessageForTime(trapTriggeredMessage);
        }

        void displayDefeatedMessage()
        {
            DisplayMessageForTime(defeatedMessage);
        }

        IEnumerator disableCanvasAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            canvasElement.GetComponent<Canvas>().enabled = false;
        }
    }
}
