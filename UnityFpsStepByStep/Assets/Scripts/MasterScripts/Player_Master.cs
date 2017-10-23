using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Player_Master : MonoBehaviour {
        public delegate void GeneralEventHandler();

        public event GeneralEventHandler EventInventoryChanged;
        public event GeneralEventHandler EventEmptyHands;
        public event GeneralEventHandler EventAmmoChanged;

        public delegate void AmmoPickupEventHandler(string ammoName, int quantity);
        public event AmmoPickupEventHandler EventPickupAmmo;

        public delegate void PlayerHealthEventHandler(int healthDelta);
        public event PlayerHealthEventHandler EventPlayerHealthChanged;

        public void CallEventInventoryChanged()
        {
            if (EventInventoryChanged != null)
                EventInventoryChanged();
        }

        public void CallEventEmptyHands()
        {
            if (EventEmptyHands != null)
                EventEmptyHands();
        }

        public void CallEventAmmoChanged()
        {
            if (EventAmmoChanged != null)
                EventAmmoChanged();
        }

        public void CallEventPickupAmmo(string ammoName, int quantity)
        {
            if (EventPickupAmmo != null)
                EventPickupAmmo(ammoName, quantity);
        }

        public void CallEventPlayerHealthChanged(int healthDelta)
        {
            if (EventPlayerHealthChanged != null)
                EventPlayerHealthChanged(healthDelta);
        }

    }
}
