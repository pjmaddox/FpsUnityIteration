using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Player_BetterJump : MonoBehaviour {

        [Range(1,10)]
        public float jumpVelocity;

        public float fallMultiplier = 2.5f;
        public float lowJumpMultiplier = 2f;

        Rigidbody myRb;

        void OnEnable()
        {
            myRb = GetComponent<Rigidbody>();
        }

		void Update () {
            //Normal Jump
            if (Input.GetButtonDown("Jump"))
            {
                myRb.velocity = new Vector3(myRb.velocity.x, jumpVelocity, myRb.velocity.z);
            }

            //Better Jump Addition
            if (myRb.velocity.y > 0)
            {
                myRb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (myRb.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                myRb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
		}
	}
}
