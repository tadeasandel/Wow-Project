using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WoW.CameraManagement;
using WoW.Movement;
using WoW.Targeting;

namespace WoW.Controllers
{
    public class PlayerInputController : MonoBehaviour
    {
        PlayerMovement playerMovement;
        CameraRotation cameraRotation;
        PlayerTargeting playerTargeting;

        float xInput;
        float yInput;

        float mouseX;
        float mouseY;

        float timeSinceLeftButtonDown = 0;
        float timeSinceRightButtonDown = 0;

        public float buttonHoldLimit = 0.8f;

        float mouseScroll;

        public float mouseSensitivity = 100f;

        public KeyCode jumpKey;

        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
            cameraRotation = GetComponent<CameraRotation>();
            playerTargeting = GetComponent<PlayerTargeting>();
        }

        private void Update()
        {
            xInput = Input.GetAxisRaw("Vertical") * Time.deltaTime;
            yInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime;

            mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
            mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;

            mouseScroll = Input.GetAxis("Mouse ScrollWheel");

            if (Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.Mouse1))
            {
                print("both pressed");
                cameraRotation.TurnCamera(mouseX, mouseY);
                cameraRotation.SetPlayerRotationToCamera();
                playerMovement.MovePlayerForward();
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                print("Right click down");
                Cursor.visible = false;
                timeSinceRightButtonDown = 0;
            }
            else if (Input.GetKey(KeyCode.Mouse1))
            {
                timeSinceRightButtonDown += Time.deltaTime;
                print("right click");
                cameraRotation.TurnCamera(mouseX, mouseY);
                cameraRotation.SetPlayerRotationToCamera();

            }
            else if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                Cursor.visible = true;
                print("right click up");
                if (timeSinceRightButtonDown <= buttonHoldLimit)
                {
                    playerTargeting.SetNewTarget();
                }
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                print("left click down");
                Cursor.visible = false;
            }
            else if (Input.GetKey(KeyCode.Mouse0))
            {
                cameraRotation.TurnCamera(mouseX, mouseY);
                print("left click");
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                print("left click up");
                Cursor.visible = true;
                playerTargeting.SetNewTarget();
            }
        }

        private void FixedUpdate()
        {
            playerMovement.ProcessPlayerMovement(xInput, yInput);
            if (Input.GetKeyDown(jumpKey)) { playerMovement.ProcessJumping(); }
        }
    }
}