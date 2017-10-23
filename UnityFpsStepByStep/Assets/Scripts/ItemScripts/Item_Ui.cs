using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Item_Ui : MonoBehaviour 
	{
        public GameObject itemUi;
        private Item_Master itemMaster;

        void OnEnable()
        {
            SetInitialReferences();
            itemMaster.EventObjectThrown += DisableItemUi;
            itemMaster.EventObjectPickedUp += EnableItemUi;
        }

        void OnDisable()
        {
            itemMaster.EventObjectThrown -= DisableItemUi;
            itemMaster.EventObjectPickedUp -= EnableItemUi;
        }

        void SetInitialReferences()
        {
            itemMaster = GetComponent<Item_Master>();
        }

        void EnableItemUi()
        {
            if (itemUi)
                itemUi.SetActive(true);
        }

        void DisableItemUi()
        {
            if (itemUi)
                itemUi.SetActive(false);
        }
    }
}
