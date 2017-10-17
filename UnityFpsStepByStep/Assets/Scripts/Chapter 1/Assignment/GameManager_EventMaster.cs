using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter1Assignment
{
    public class GameManager_EventMaster : MonoBehaviour
    {
        public delegate void TrapTriggered();
        public event TrapTriggered trapTriggeredEvent;

        public void CallTrapTriggered()
        {
            if (trapTriggeredEvent != null)
                trapTriggeredEvent();
        }

        public delegate void DefeatedAllEnemies();
        public event DefeatedAllEnemies defeatedAllEnemiesEvent;

        public void CallDefeatedAllEnemies()
        {
            if (defeatedAllEnemiesEvent != null)
                defeatedAllEnemiesEvent();
        }
    }
}
