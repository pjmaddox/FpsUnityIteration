using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter1Assignemnt
{
    public class ShootGrenade : MonoBehaviour
    {
        public GameObject grenadePrefab;
        private float launchForce = 30f;
        private Transform myTransform;

        void Start()
        {
            SetInitialReferences();
        }

        void SetInitialReferences()
        {
            myTransform = this.transform;
        }

        // Update is called once per frame
        void Update()
        {
            CheckForInput();
        }

        void CheckForInput()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SpawnGrenadeWithForce();
            }
        }

        void SpawnGrenadeWithForce()
        {
            var go = Instantiate(grenadePrefab, myTransform.TransformPoint(0, 0, 1f), Quaternion.identity);
            go.GetComponent<Rigidbody>().AddForce(myTransform.forward * launchForce, ForceMode.Impulse);
        }
    }
}
