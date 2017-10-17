using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
    public class TestGameOver : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.O))
            {
                GetComponent<GameManager_Master>().CallGameOverEvent();
            }
        }
    }
}
