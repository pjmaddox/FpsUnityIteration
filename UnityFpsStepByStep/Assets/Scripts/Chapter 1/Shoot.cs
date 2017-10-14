using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter1
{
    public class Shoot : MonoBehaviour
    {

        float fireRate = 0.3f;
        float nextTime;
        RaycastHit hit;
        float range = 300f;
        Transform myTransform;

        // Use this for initialization
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
            if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextTime)
            {
                Fire();
                nextTime = Time.time + fireRate;
            }
        }
        void Fire()
        {
            if(Physics.Raycast(myTransform.TransformPoint(0,0,1), myTransform.forward, out hit, range))
            {
                Debug.DrawRay(myTransform.TransformPoint(0,0,1), myTransform.forward, Color.cyan, 2f);
                Debug.Log(hit.transform.name);
            }
        }
    }
}
