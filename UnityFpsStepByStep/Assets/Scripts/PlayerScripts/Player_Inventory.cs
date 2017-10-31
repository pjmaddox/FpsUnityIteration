using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace s3
{
	public class Player_Inventory : MonoBehaviour
    {
        public Transform inventoryPlayerParent;
        public Transform inventoryUiParent;
        public GameObject uiButton;

        private Player_Master playerScript;
        private GameManager_ToggleInventoryUi inventoryUiScript;
        private float timeToPlaceInHands = .1f;
        private Transform currentlyHEldItem;
        private int counter;
        private string buttonText;
        private List<Transform> inventoryItems = new List<Transform>();

		void OnEnable()
		{
			SetInitialReferences();

            DeactivateAllInventoryItems();

            UpdateInventoryListAndUi();
            CheckIfHandsEmpty();

            playerScript.EventEmptyHands += ClearHands;
            playerScript.EventInventoryChanged += UpdateInventoryListAndUi;
            playerScript.EventInventoryChanged += CheckIfHandsEmpty;
        }

		void OnDisable()
		{
            playerScript.EventEmptyHands -= ClearHands;
            playerScript.EventInventoryChanged -= UpdateInventoryListAndUi;
            playerScript.EventInventoryChanged -= CheckIfHandsEmpty;
        }

		void SetInitialReferences()
		{
            inventoryUiScript = GameObject.Find("GameManager").GetComponent<GameManager_ToggleInventoryUi>();
            playerScript = GetComponent<Player_Master>();
		}
    
        void UpdateInventoryListAndUi()
        {
            counter = 0;
            inventoryItems.Clear();
            inventoryItems.TrimExcess();
            ClearInventoryUi();
            foreach (Transform itemX in inventoryPlayerParent)
            {
                if (itemX.CompareTag("Item"))
                {
                    inventoryItems.Add(itemX);
                    GameObject go = Instantiate(uiButton);
                    buttonText = itemX.name;
                    go.GetComponentInChildren<Text>().text = buttonText;
                    int index = counter;

                    //!!!!!!!!!!!!!!!
                    //This seems really potent and important!
                    go.GetComponent<Button>().onClick.AddListener(delegate { ActivateInventoryItem(index); });
                    go.GetComponent<Button>().onClick.AddListener(delegate { inventoryUiScript.ToggleInventory(); } );

                    go.transform.SetParent(inventoryUiParent, false);
                    counter++;
                }
            }
        }

        void CheckIfHandsEmpty()
        {
            if (currentlyHEldItem == null && inventoryItems.Count > 0)
                StartCoroutine(PlaceItemInHands(inventoryItems[inventoryItems.Count - 1]));
        }

        void ClearHands()
        {
            currentlyHEldItem = null;
        }

        void ClearInventoryUi()
        {
            foreach(Transform itemX in inventoryUiParent)
            {
                //Destroys all buttons
                Destroy(itemX.gameObject);
            }
        }

        public void ActivateInventoryItem(int inventoryIndex)
        {
            DeactivateAllInventoryItems();
            StartCoroutine(PlaceItemInHands(inventoryItems[inventoryIndex]));
        }

        void DeactivateAllInventoryItems()
        {
            foreach(Transform itemX in inventoryItems)
            {
                if(itemX.CompareTag("Item"))
                    itemX.gameObject.SetActive(false);
            }
        }

        IEnumerator PlaceItemInHands(Transform itemTransform)
        {
            yield return new WaitForSeconds(timeToPlaceInHands);
            currentlyHEldItem = itemTransform;

            var rb = currentlyHEldItem.gameObject.GetComponent<Rigidbody>();
            if (rb)
                rb.isKinematic = true;

            currentlyHEldItem.gameObject.SetActive(true);
        }
	}
}
