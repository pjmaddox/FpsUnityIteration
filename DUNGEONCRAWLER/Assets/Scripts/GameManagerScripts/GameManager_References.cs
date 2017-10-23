using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class GameManager_References : MonoBehaviour 
	{
        public static GameObject[] _players;
        public static GameObject _gameManager;
        public static string _playerTag;
        public static string _enemyTag;

		void OnEnable()
		{
			SetInitialReferences();

		}

        void OnDisable()
        {

        }

        void AddNewPlayer()
        {

        }

        void RemovePlayer()
        {

        }

		void SetInitialReferences()
		{
            if (_playerTag != "")
            {
                _players = GameObject.FindGameObjectsWithTag(_playerTag);
            }
            else
            {
                Debug.LogWarning("You must assign a player tag in the GameManagerReferences Script");
            }

            _gameManager = GameObject.Find("GameManager"); ;
		}
	}
}
