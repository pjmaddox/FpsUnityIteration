using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter1
{
    public class FindEnemies : MonoBehaviour
    {
        GameObject[] enemies;

        // Use this for initialization
        void Start()
        {
            SearchForEnemies();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void SearchForEnemies()
        {
            //Find game object with tags is a slow operation
            //Try not to do it frequently or do it when you have a menu open or something

            //Deactivated game objects are not found with Find / FindWithTag
            //Thus, get references and then deactivate them if you want to activate things later
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (enemies.Length == 0)
                return;

            foreach (GameObject gox in enemies)
            {
                Debug.Log(gox.name + " Found in enemy search");
            }
        }
    }
}
