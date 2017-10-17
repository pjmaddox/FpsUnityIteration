using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter1
{
    public class WalkThroughWall : MonoBehaviour
    {

        private GameManager_EventMaster eventMasterScript;
        private Color myColor = new Color(0.5f, 1, 0.5f, .3f);

        void OnEnable()
        {
            SetInitialReferences();
            eventMasterScript.myGeneralEvent += SetLayerToNotSolid;
        }

        void OnDisable()
        {
            eventMasterScript.myGeneralEvent -= SetLayerToNotSolid;
        }

        public void SetLayerToNotSolid()
        {
            gameObject.layer = LayerMask.NameToLayer("NotSolid");
            GetComponent<Renderer>().material.SetColor("_Color", myColor);
        }

        public void SetLayerToDefault()
        {
            gameObject.layer = LayerMask.NameToLayer("Default");
            GetComponent<Renderer>().material.color = Color.green;
        }

        void SetInitialReferences()
        {
            eventMasterScript = GameObject.Find("GameManager").GetComponent<GameManager_EventMaster>();
        }
    }
}