using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
    public class GameManager_References : MonoBehaviour
    {
        public string playerTag;
        public static string _playerTag;

        public string enemyTag;
        public static string _enemyTag;

        public static GameObject _player;

        void OnEnable()
        {
            if (playerTag == "")
            {
                Debug.LogWarning("PlayerTag should contain a value");
            }

            if (enemyTag == "")
            {
                Debug.LogWarning("EnemyTag should contain a value");
            }

            _playerTag = playerTag;
            _enemyTag = enemyTag;
            _player = GameObject.FindWithTag(_playerTag);
        }
    }
}
