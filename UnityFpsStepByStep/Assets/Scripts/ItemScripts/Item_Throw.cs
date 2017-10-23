using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Item_Throw : MonoBehaviour
    {
        private Transform myTransform;
        private Rigidbody myRigidBody;
        private Item_Master itemScript;
        private Vector3 throwDirection;

        public bool canBeThrown;
        public string throwButtonName;
        public float throwForce;

		void OnEnable()
		{
			SetInitialReferences();
		}

		void OnDisable()
		{
        }

		void SetInitialReferences()
		{
            itemScript = GetComponent<Item_Master>();
            myTransform = this.transform;
            myRigidBody = GetComponent<Rigidbody>();
        }

		void Start () {
			
		}
		
		void Update () {
            CheckForThrowCommand();
		}

        void CheckForThrowCommand()
        {
            if(Input.GetButtonDown(throwButtonName) && Time.timeScale > 0 && canBeThrown && myTransform.root.CompareTag(GameManager_References._playerTag))
            {
                PerformThrowAction();
            }
        }

        void PerformThrowAction()
        {
            throwDirection = myTransform.parent.forward;
            myTransform.parent = null;
            myRigidBody.isKinematic = false;
            itemScript.CallEventObjectThrow();
            HurtlItem();
        }

        void HurtlItem()
        {
            myRigidBody.AddForce(throwDirection * throwForce, ForceMode.Impulse);
        }

    }
}
