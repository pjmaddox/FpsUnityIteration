using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter1
{
    public class GameManager_EventMaster : MonoBehaviour
    {
        public delegate void GeneralEvent();
        public event GeneralEvent myGeneralEvent;

        public void CallMyGeneralEvent()
        {
            //Make sure something is subscribed to the event
            if (myGeneralEvent != null)
            {
                myGeneralEvent();
            }
        }
    }
}
