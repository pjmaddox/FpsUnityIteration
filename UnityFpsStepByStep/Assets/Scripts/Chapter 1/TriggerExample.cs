using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter1
{
    public class TriggerExample : MonoBehaviour
    {
        private WalkThroughWall walkThroughWallScript;
        private GameManager_EventMaster eventMasterScript;

        void Start()
        {
            SetInitialReferences();
        }

        void SetInitialReferences()
        {
            var initialTarget = GameObject.Find("Wall");
            if (initialTarget != null)
                walkThroughWallScript = initialTarget.GetComponent<WalkThroughWall>();
            eventMasterScript = GameObject.Find("GameManager").GetComponent<GameManager_EventMaster>();
        }

        void OnTriggerEnter(Collider other)
        {
            walkThroughWallScript.SetLayerToNotSolid();
            eventMasterScript.CallMyGeneralEvent();
        }
        void OnTriggerExit(Collider other)
        {
            StartCoroutine(DelayThenMakeWallSolid(.5f));
            Destroy(gameObject, 5f);
        }

        IEnumerator DelayThenMakeWallSolid(float delay)
        {
            yield return new WaitForSeconds(delay);
            MakeWallSolid();
        }

        void MakeWallSolid()
        {
            walkThroughWallScript.SetLayerToDefault();
        }
    }
}
