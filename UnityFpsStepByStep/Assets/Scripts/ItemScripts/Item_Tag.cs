using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Item_Tag : MonoBehaviour 
	{
        public string itemTag;
		
		void OnEnable()
		{
            SetTag();
        }

        void SetTag()
        {
            if (itemTag == "")
            {
                itemTag = "Untaggged";
            }

            this.transform.tag = itemTag;
        }
	}
}
