using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Item_Name : MonoBehaviour 
	{
        public string itemName;

        void Start()
        {
            SetName();
        }

        void SetName()
        {
            this.transform.name = itemName;
        }
        
	}
}
