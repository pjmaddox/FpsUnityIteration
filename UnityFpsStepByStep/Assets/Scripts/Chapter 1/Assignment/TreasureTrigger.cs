using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter1Assignment
{
    public class TreasureTrigger : MonoBehaviour
    {
        private GameManager_EventMaster eventManagerScript;

        void OnEnable()
        {
            SetInitialReferences();
        }

        void SetInitialReferences()
        {
            eventManagerScript = GameObject.Find("GameManager").GetComponent<GameManager_EventMaster>();
        }

        void OnTriggerEnter(Collider other)
        {
            eventManagerScript.CallTrapTriggered();
            Destroy(gameObject);
        }
    }
}