using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3
{
	public class Player_Movement : MonoBehaviour {

        public float moveSpeed = 5f;
        public float mouseSensitivity = 2f;

        //Vertical Movement
        public float jumpForce = 25f;
        public float fallMultiplier = 2.5f;
        public float shortJumpfallMultiplier = 1.5f;
        public float gravityForce = 5;

        private Transform myTransform;
        private Camera myCamera;
        private Rigidbody myRigidBody;
        private CharacterController controller;

        void OnEnable()
		{
			SetInitialReferences();
		}

		void OnDisable()
		{

		}

		void SetInitialReferences()
		{
            
            myCamera = GetComponentInChildren<Camera>();
            myTransform = this.transform;
            controller = GetComponent<CharacterController>();
        }

		void Start () {
			
		}
		
		void Update () {
            //Gross - might be necesary
            controller.Move(Vector3.down * 0.001f * Time.deltaTime);

            HandleLook();
            HandleMovement();
        }

        void HandleLook()
        {
            var mouseX = Input.GetAxis("Mouse X");
            var mouseY = Input.GetAxis("Mouse Y");

            myTransform.Rotate(new Vector3(0, mouseX * mouseSensitivity, 0));
            myCamera.transform.Rotate(new Vector3(-mouseY * mouseSensitivity, 0, 0));
        }

        void HandleMovement()
        {
            var xInput = Input.GetAxis("Horizontal");
            var yInput = Input.GetAxis("Vertical");

            var moveTarget = (new Vector3(xInput, 0, yInput) * moveSpeed * Time.deltaTime);
            moveTarget += GetVerticalMovement();
            moveTarget = myTransform.TransformDirection(moveTarget);

            controller.Move(moveTarget);
            Debug.Log("grounded was: " + controller.isGrounded);
        }

        Vector3 GetVerticalMovement()
        {
            var gravityValue = controller.isGrounded? 0 : gravityForce;
            var jumpValue = DetermineJumpValue();

            return new Vector3(0, jumpValue - gravityValue, 0) * Time.deltaTime;
        }

        float DetermineJumpValue()
        {
            var jumpValue = 0f;

            //Normal Jump
            if (Input.GetButtonDown("Jump") && controller.isGrounded)
            {
                jumpValue = jumpForce;
            }

            //Maye need to SmoothDamp/SLERP the jump value

            //Better Jump Addition
            //if (myRb.velocity.y > 0)
            //{
            //    myRb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            //}
            //else if (myRb.velocity.y > 0 && !Input.GetButton("Jump"))
            //{
            //    myRb.velocity += Vector3.up * Physics.gravity.y * (shortJumpfallMultiplier - 1) * Time.deltaTime;
            //}

            return jumpValue;
        }
    }
}
