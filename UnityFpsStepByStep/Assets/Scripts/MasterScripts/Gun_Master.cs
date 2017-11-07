using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Gun_Master : MonoBehaviour 
	{
        public delegate void GeneralEventHandler();
        public event GeneralEventHandler EventPlayerPressedFire;
        public event GeneralEventHandler EventGunNotUsable;
        public event GeneralEventHandler EventRequestReload;
        public event GeneralEventHandler EventRequestGunReset;
        public event GeneralEventHandler EventToggleBurstFire;

        public delegate void GunHitEventHandler(Vector3 hitpositiion, Transform hitTarget);
        public event GunHitEventHandler EventShotDefault;
        public event GunHitEventHandler EventShotEnemy;

        public delegate void GunAmmoEventHandler(int currentAmmo, int carriedAmmo);
        public event GunAmmoEventHandler EventAmmoChanged;

        public delegate void GunCrosshairEventHandler(float speed);
        public event GunCrosshairEventHandler EventSpeedCaptured;

        public bool isGunLoaded;
        public bool isReloading;

        public void CallEventPlayerInput()
        {
            if (EventPlayerPressedFire != null)
                EventPlayerPressedFire();
        }

        public void CallEventGunNotUsable()
        {
            if (EventGunNotUsable != null)
                EventGunNotUsable();
        }

        public void CallEventRequestReload()
        {
            if (EventRequestReload != null)
                EventRequestReload();
        }

        public void CallEventRequestGunReset()
        {
            if (EventRequestGunReset != null)
                EventRequestGunReset();
        }

        public void CallEventToggleBurstFire()
        {
            if (EventToggleBurstFire != null)
                EventToggleBurstFire();
        }

        public void CallEventShotEnemy(Vector3 hPos, Transform hTransform)
        {
            if (EventShotEnemy != null)
                EventShotEnemy(hPos, hTransform);
        }

        public void CallEventShotDefault(Vector3 hPos, Transform hTransform)
        {
            if (EventShotDefault != null)
                EventShotDefault(hPos, hTransform);
        }


        public void CallEventAmmoChanged(int current, int carried)
        {
            if (EventAmmoChanged != null)
                EventAmmoChanged(current, carried);
        }

        public void CallEventSpeedCaptured(float speed)
        {
            if (EventSpeedCaptured != null)
                EventSpeedCaptured(speed);
        }
	}
}
