using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WoW.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        public Transform playerTransform;

        public float movementSpeed = 100f;

        Rigidbody playerRigidBody;

        [SerializeField] KeyCode jumpKey;

        [SerializeField] float jumpForce;

        public LayerMask groundLayers;

        bool isGrounded = true;
        public bool airControl;
        public bool airLittleControl;
        public bool usingDoubleJump;
        public bool usingMagnetic;

        public float magnetDistance = 10;

        public float characterRadius;

        public GameObject groundCheck;

        public Vector3 antiGravityVelocity;

        void Awake()
        {
            playerRigidBody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            ProcessGroundCheck();
        }

        private void ProcessGroundCheck()
        {
            if (Physics.CheckSphere(groundCheck.transform.position, characterRadius, groundLayers))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
        }

        public void ProcessPlayerMovement(float xInput, float yInput)
        {
            Vector3 xVelocity = playerTransform.forward * movementSpeed * xInput;
            Vector3 zVelocity = playerTransform.right * movementSpeed * yInput;

            Vector3 velocity = xVelocity + zVelocity + new Vector3(0, playerRigidBody.velocity.y, 0);
            playerRigidBody.velocity = velocity;
        }

        public void ProcessJumping()
        {
            if (isGrounded)
            {
                playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

        public void MovePlayerForward()
        {
            playerRigidBody.velocity = playerTransform.forward * Time.deltaTime * movementSpeed + new Vector3(0, playerRigidBody.velocity.y, 0);
        }

        //if (usingMagnetic)
        //{
        //  ProcessMagnetBoots();
        //}

        //private void ProcessMagnetBoots()
        //{
        //  RotateAroundMagnetic();
        //  GravityAroundMagnetic();
        //}

        //private void GravityAroundMagnetic()
        //{

        //}

        //private void RotateAroundMagnetic()
        //{
        //  RaycastHit hit;
        //  if (Physics.Raycast(transform.position, -playerTransform.up, out hit, magnetDistance))
        //  {
        //    Vector3 direction = hit.point - playerTransform.position;
        //  }
        //}

        // to be done magnetic boots
        //private void OnDrawGizmos()
        //{
        //  RaycastHit hit;
        //  if (Physics.Raycast(transform.position, -playerTransform.up, out hit, magnetDistance))
        //  {
        //    Vector3 direction = hit.point - playerTransform.position;

        //    // transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.y));

        //    Gizmos.color = Color.gray;
        //    Gizmos.DrawLine(hit.point, hit.normal + hit.point);
        //    Vector3 newDirection = hit.point - hit.normal + hit.point;
        //    playerTransform.rotation = Quaternion.LookRotation(newDirection);

        //    print(hit.point);


        //  }
        //}
    }
}