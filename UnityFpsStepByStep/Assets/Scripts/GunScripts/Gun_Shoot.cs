using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Gun_Shoot : MonoBehaviour 
	{
        private Gun_Master gunMaster;
        private Transform myTransform;
        private Transform camTranf;
        private RaycastHit rayHit;
        public float range = 400f;
        private float offsetFactor = 7f;
        private Vector3 startPosition;


		void OnEnable()
		{
			SetInitialReferences();
            gunMaster.EventPlayerPressedFire += PerformFire;
            gunMaster.EventSpeedCaptured += SetStartOfShootingPosition;
		}

		void OnDisable()
		{
            gunMaster.EventPlayerPressedFire -= PerformFire;
            gunMaster.EventSpeedCaptured -= SetStartOfShootingPosition;
        }

		void SetInitialReferences()
		{
            gunMaster = GetComponent<Gun_Master>();
            myTransform = this.transform;
            camTranf = myTransform.parent;
		}

        void PerformFire()
        {
            Debug.DrawRay(camTranf.TransformPoint(startPosition), camTranf.forward, Color.red, range);
            if (Physics.Raycast(camTranf.TransformPoint(startPosition), camTranf.forward, out rayHit, range))
            {
                gunMaster.CallEventShotDefault(rayHit.point, rayHit.transform);

                if (rayHit.transform.root.CompareTag(GameManager_References._enemyTag))
                {
                    Debug.Log("shot enemy: " + rayHit.transform.root.name);
                    gunMaster.CallEventShotEnemy(rayHit.point, rayHit.transform);
                }
            }
        }

        void SetStartOfShootingPosition(float playerSPeed)
        {
            float offset = playerSPeed / offsetFactor;

            startPosition = new Vector3(Random.Range(-offset, offset), Random.Range(-offset, offset), 1);

            
        }
	}
}
