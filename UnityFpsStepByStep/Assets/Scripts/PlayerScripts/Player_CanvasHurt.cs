using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Player_CanvasHurt : MonoBehaviour {

        public GameObject hurtCanvas;
        private Player_Master playerScript;
        private float secondsUntilHide = 2f;

		void OnEnable()
		{
			SetInitialReferences();
            playerScript.EventPlayerHealthChanged += DisplayHurtEffect;
        }

		void OnDisable()
		{
            playerScript.EventPlayerHealthChanged += DisplayHurtEffect;
		}

		void SetInitialReferences()
		{
            playerScript = GetComponent<Player_Master>();
		}

        void DisplayHurtEffect(int dummy)
        {
            if (hurtCanvas != null && dummy < 0)
            {
                StopAllCoroutines();
                hurtCanvas.SetActive(true);
                StartCoroutine(HideCanvasAfterDelay());
            }
        }

        IEnumerator HideCanvasAfterDelay()
        {
            yield return new WaitForSeconds(secondsUntilHide);
            hurtCanvas.SetActive(false);
        }
	}
}
