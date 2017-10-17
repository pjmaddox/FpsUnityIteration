using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter1
{
    public class ThrowGrenade : MonoBehaviour
    {
        public GameObject grenadePrefab;
        public float grenadeThrowForce = 30f;
        private Transform myTransform;

        // Use this for initialization
        void Start()
        {
            SetInitialReferences();
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
                SpawnGrenade();
            }
        }

        void SpawnGrenade()
        {
            GameObject go = (GameObject)Instantiate(grenadePrefab, myTransform.TransformPoint(0, 0, .5f), myTransform.rotation);
            go.GetComponent<Rigidbody>().AddForce(myTransform.forward * grenadeThrowForce, ForceMode.Impulse);
            GameObject.Destroy(go, 10f);
        }

        void SetInitialReferences()
        {
            myTransform = transform;
        }
    }

}
