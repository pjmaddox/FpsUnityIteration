using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Chapter1
{
    public class Detection : MonoBehaviour
    {

        private RaycastHit hit;
        private Transform myTransform;
        private float nextCheck;

        //Serialize field attribute can be used to expose and manipulate 
        //[SerializeField]
        private LayerMask detectionLayer;

        //[SerializeField]
        private int detectionLayerNumber = 9;

        public float checkRate = 0.5f;
        public float checkRange = 1f;

        // Use this for initialization
        void Start()
        {
            SetInitialReferences();
        }

        void SetInitialReferences()
        {
            myTransform = this.transform;
            //Bitwise shift
            //Based on a 32-bit mask
            //So can have up to 32 layers. Each bit set to 1 represents a layer that is included in this mask.
            detectionLayer = 1 << detectionLayerNumber;
        }

        // Update is called once per frame
        void Update()
        {
            DetectItems();
        }

        void DetectItems()
        {
            if(Time.time >= nextCheck)
            {
                nextCheck = Time.time + checkRate;
                if (Physics.Raycast(myTransform.position, myTransform.forward, out hit, checkRange, detectionLayer))
                {
                    Debug.Log(hit.transform.name + " is an item");
                }
            }
        }
    }

}
