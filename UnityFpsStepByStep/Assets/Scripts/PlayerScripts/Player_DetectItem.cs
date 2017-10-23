using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Player_DetectItem : MonoBehaviour
    {
        public LayerMask layerToDetect;
        [Tooltip("WHat transform will the ray be fired from?")]
        public Transform rayTransformPivot;
        [Tooltip("The editor input button that will be used foir picking up items")]
        public string pickupButton;

        private Transform itemAvailableForPickup;
        private RaycastHit hit;
        private float detectRange = 3f;
        private float detectRadius = 0.7f;
        private bool isItemInRange;

        private float labelWidth = 200;
        private float labelHeight = 200;

		void OnEnable()
		{
			SetInitialReferences();
		}

		void OnDisable()
		{

		}

		void SetInitialReferences()
		{

		}

		void Start () {
			
		}
		
		void Update () {
            CastRayForDetectingItems();
            CheckForItemPickupAttempt();
		}

        void CastRayForDetectingItems()
        {
            if (Physics.SphereCast(rayTransformPivot.position, detectRadius, rayTransformPivot.forward, out hit, detectRange, layerToDetect))
            {
                itemAvailableForPickup = hit.transform;
                isItemInRange = true;
            }
            else
                isItemInRange = false;
        }

        void CheckForItemPickupAttempt()
        {
            if (Input.GetButtonDown(pickupButton) && Time.timeScale > 0 && isItemInRange && itemAvailableForPickup.root.tag != GameManager_References._playerTag)
            {
                itemAvailableForPickup.GetComponent<Item_Master>().CallEventPickupAction(rayTransformPivot);
            }
                
        }

        void OnGUI()
        {
            if (isItemInRange && itemAvailableForPickup != null && itemAvailableForPickup.root.tag != GameManager_References._playerTag)
                GUI.Label(new Rect(Screen.width/2 - labelWidth, Screen.height/2 - labelHeight, labelWidth, labelHeight), itemAvailableForPickup.name);
        }

    }
}
