using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Gun_Ammo : MonoBehaviour 
	{
        private Player_Master playerMaster;
        private Gun_Master gunMaster;
        private Player_AmmoBox ammoBox;
        private Animator myAnimator;

        public int clipSize;
        public int currentAmmo;
        public string ammoName;
        public float reloadTime;
		
		void OnEnable()
		{
			SetInitialReferences();
            StartingSanityCheck();
            CheckAmmoStatus();

            gunMaster.EventPlayerPressedFire += DeductAmmo;
            gunMaster.EventPlayerPressedFire += CheckAmmoStatus;
            gunMaster.EventRequestReload += TryToReload;
            gunMaster.EventGunNotUsable += TryToReload;
            gunMaster.EventRequestGunReset += ResetGunReloading;

            if(playerMaster != null)
            {
                playerMaster.EventAmmoChanged += UiAmmoUpdateRequest;
            }

            if(ammoBox != null)
            {
                StartCoroutine(UpdateAmmoUiWhenEnabling());
            }
        }

		void OnDisable()
		{
            gunMaster.EventPlayerPressedFire -= DeductAmmo;
            gunMaster.EventPlayerPressedFire -= CheckAmmoStatus;
            gunMaster.EventRequestReload -= TryToReload;
            gunMaster.EventGunNotUsable -= TryToReload;
            gunMaster.EventRequestGunReset -= ResetGunReloading;

            if (playerMaster != null)
            {
                playerMaster.EventAmmoChanged -= UiAmmoUpdateRequest;
            }
        }

		void SetInitialReferences()
		{
            gunMaster = GetComponent<Gun_Master>();
            var anim = GetComponent<Animator>();
            if (anim)
                myAnimator = anim;
            if (GameManager_References._player != null)
            {
                playerMaster = GameManager_References._player.GetComponent<Player_Master>();
                ammoBox = GameManager_References._player.GetComponent<Player_AmmoBox>();
            }
            
		}

		void Start () 
		{
            SetInitialReferences();

            if (playerMaster != null)
            {
                playerMaster.EventAmmoChanged += UiAmmoUpdateRequest;
            }

            if (ammoBox != null)
            {
                StartCoroutine(UpdateAmmoUiWhenEnabling());
            }
        }
		
		void Update () 
		{
			
		}

        void DeductAmmo()
        {
            currentAmmo--;
            UiAmmoUpdateRequest();
        }

        void TryToReload()
        {
            for (int i = 0; i < ammoBox.ammoBelt.Count; ++i)
            {
                if (ammoBox.ammoBelt[i].ammoName == ammoName)
                {
                    var desiredAmmo = ammoBox.ammoBelt[i];
                    if (desiredAmmo.ammoCurrentCarried > 0 && currentAmmo != clipSize && !gunMaster.isReloading)
                    {
                        gunMaster.isReloading = true;
                        gunMaster.isGunLoaded = false;
                    }

                    if(myAnimator != null)
                    {
                        myAnimator.SetTrigger("Reload");
                    }
                    else
                    {
                        StartCoroutine(ReloadWithoutAnimation());
                    }
                    break;
                }
            }
            myAnimator.Play("Reload");
        }

        void CheckAmmoStatus()
        {
            if (currentAmmo <= 0)
            {
                currentAmmo = 0;
                gunMaster.isGunLoaded = false;
            }
            else if (currentAmmo > 0)
            {
                gunMaster.isGunLoaded = true;
            }
        }

        void StartingSanityCheck()
        {
            if(currentAmmo > clipSize)
            {
                currentAmmo = clipSize;
            }
        }

        void UiAmmoUpdateRequest()
        {
            for(int i = 0; i < ammoBox.ammoBelt.Count; ++i)
            {
                if(ammoBox.ammoBelt[i].ammoName == ammoName)
                {
                    gunMaster.CallEventAmmoChanged(currentAmmo, ammoBox.ammoBelt[i].ammoCurrentCarried);
                    break;
                }
            }
        }

        void ResetGunReloading()
        {
            gunMaster.isReloading = false;
            CheckAmmoStatus();
            UiAmmoUpdateRequest();
        }

        public void OnReloadComplete() //Called by the reload animation
        {
            //Attempt to add ammo to current
            for (int i = 0; i < ammoBox.ammoBelt.Count; ++i)
            {
                if(ammoBox.ammoBelt[i].ammoName == ammoName)
                {
                    var ammoTopOff = (clipSize - currentAmmo);

                    if (ammoBox.ammoBelt[i].ammoCurrentCarried >= ammoTopOff)
                    {
                        currentAmmo += ammoTopOff;
                        ammoBox.ammoBelt[i].ammoCurrentCarried -= ammoTopOff;
                    }
                    else if (ammoBox.ammoBelt[i].ammoCurrentCarried < ammoTopOff)
                    {
                        currentAmmo += ammoBox.ammoBelt[i].ammoCurrentCarried;
                        ammoBox.ammoBelt[i].ammoCurrentCarried = 0;
                    }
                    break;
                }
                ResetGunReloading();
            }
            //Alternative to this looping nonsense
            //var desiredAmmo = ammoBox.ammoBelt.Find(x => x.ammoName == ammoName);
            //if (desiredAmmo == null)
            //    return;


        }

        IEnumerator ReloadWithoutAnimation()
        {
            yield return new WaitForSeconds(reloadTime);
            OnReloadComplete();
        }

        IEnumerator UpdateAmmoUiWhenEnabling()
        {
            yield return new WaitForSeconds(0.05f); // this is a fudge factor to ensure that the ui is updated when changing weapons
            UiAmmoUpdateRequest();
        }
	}
}
