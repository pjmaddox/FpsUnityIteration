using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Player_AmmoBox : MonoBehaviour
    {

        private Player_Master playerScript;
        public List<AmmoType> ammoBelt = new List<AmmoType>();

        [System.Serializable]
        public class AmmoType
        {
            public string ammoName;
            public int ammoCurrentCarried;
            public int ammoMax;

            public AmmoType(string name, int max, int current)
            {
                ammoName = name;
                ammoMax = max;
                ammoCurrentCarried = current;
            }
        }

		void OnEnable()
		{
			SetInitialReferences();
            playerScript.EventPickupAmmo += PickedUpAmmo;
		}

		void OnDisable()
		{
            playerScript.EventPickupAmmo -= PickedUpAmmo;
		}

		void SetInitialReferences()
		{
            playerScript = GetComponent<Player_Master>();
		}

        void PickedUpAmmo(string nameOfAmmoType, int quantity)
        {
            var ammo = ammoBelt.Find(x => x.ammoName == nameOfAmmoType);

            Debug.Log("Before: Ammo amount for " + nameOfAmmoType + "is: " + ammo.ammoCurrentCarried);

            if (ammo != null)
            {
                ammo.ammoCurrentCarried += quantity;

                if (ammo.ammoCurrentCarried > ammo.ammoMax)
                    ammo.ammoCurrentCarried = ammo.ammoMax;
            }

            Debug.Log("After: Ammo amount for " + nameOfAmmoType + "is: " + ammo.ammoCurrentCarried);
            playerScript.CallEventAmmoChanged();
        }
	}
}
