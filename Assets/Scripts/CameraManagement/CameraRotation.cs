using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WoW.Movement;

namespace WoW.CameraManagement
{
    public class CameraRotation : MonoBehaviour
    {
        public float maxDistance = 10f;
        [Range(-10f, 0f)] public float cameraDistanceFromPlayer;

        public Transform rotationObjectTransform;
        public Transform playerTransform;

        PlayerMovement playerMovement;

        Quaternion previousPlayerRotation = new Quaternion();

        float xRotation = 0;
        float yRotation = 0;

        void Awake()
        {
            playerMovement = FindObjectOfType<PlayerMovement>();
        }

        void Update()
        {
            Vector3 newCameraPosition = Camera.main.transform.localPosition;

            cameraDistanceFromPlayer += Input.mouseScrollDelta.y;
            cameraDistanceFromPlayer = Mathf.Clamp(cameraDistanceFromPlayer, maxDistance, 0);
            float cameraFinalDistance = cameraDistanceFromPlayer;

            RaycastHit collidingObstacle;
            if (Physics.Raycast(rotationObjectTransform.position, Camera.main.transform.position - rotationObjectTransform.position, out collidingObstacle, -maxDistance))
            {
                cameraFinalDistance = Mathf.Max(-collidingObstacle.distance, cameraDistanceFromPlayer);
            }

            cameraFinalDistance = Mathf.Clamp(cameraFinalDistance, maxDistance, 0);

            newCameraPosition.z = cameraFinalDistance;

            Camera.main.transform.localPosition = newCameraPosition;
        }

        public void TurnCamera(float mouseX, float mouseY)
        {
            xRotation += mouseX;
            yRotation -= mouseY;

            rotationObjectTransform.localRotation = Quaternion.Euler(yRotation, xRotation, 0);
        }

        public void SetPlayerRotationToCamera()
        {
            if (previousPlayerRotation != Quaternion.Euler(playerTransform.localRotation.x, xRotation, playerTransform.localRotation.z))
            {
                playerTransform.localRotation = Quaternion.Euler(playerTransform.localRotation.x, xRotation, playerTransform.localRotation.z);
                previousPlayerRotation = Quaternion.Euler(playerTransform.localRotation.x, xRotation, playerTransform.localRotation.z);
            }
        }
    }
}